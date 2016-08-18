using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using PeerToPeerTcpUdp;

namespace PeerToPeerTcpUdp
{
	public partial class PeerToPeerUdp : Component
	{
		#region "Declaraciones"

		public delegate void ConexionEventHandler(object sender, SockEventArgs e);

		public event ConexionEventHandler ConexionEstablecida;
		public event ConexionEventHandler ConexionCancelada;
		public event ConexionEventHandler EscuchaIniciada;
		public event ConexionEventHandler EscuchaIniciando;
		public event ConexionEventHandler EscuchaCancelada;
		public event ConexionEventHandler DatosRecibidos;
		public event ConexionEventHandler ComandoRecibido;
		public event ConexionEventHandler ConexionPerdida;

		/// <summary>
		/// Enumera los estados del sock de escucha
		/// </summary>
		public enum eEstadosListen
		{
			/// <summary>
			/// El sock de escucha se encuentra cerrado
			/// </summary>
			Cerrado = 0,

			/// <summary>
			/// El sock de escucha se encuentra en estado de escucha
			/// </summary>
			Escuchando = 2,
		}

		private enum eEstadoComando
		{
			SinComando = 0,
			GuardandoComando = 1,
			GuardandoDatos = 2,
			ComandoFinalizado = 3,
		}

		private enum eCaracteresEsp
		{
			Barra = 0,
			Ok = 1,
			Commando = 2,
			Data = 3,
			Fin = 4,
			CaracterNulo = 255,
		}

		private System.Net.Sockets.TcpListener mSockTcpEscucha;
		private System.Net.Sockets.UdpClient mSockUdpSender;
		private System.Net.Sockets.UdpClient mSockUdpReceive;

		// Tareas
		private Task mTareaEscuchaUDP;
		private System.Threading.CancellationToken mTokenCancelmTareaEscuchaUDP;
		private System.Threading.CancellationTokenSource mTokenSourceCancelmTareaEscuchaUDP;
		private Task mTareaEnvioUDP;
		private System.Threading.CancellationToken mTokenCancelmTareaEnvioUDP;
		private System.Threading.CancellationTokenSource mTokenSourceCancelmTareaEnvioUDP;
		private System.Threading.Semaphore mSempBufferEntrada = new System.Threading.Semaphore(1, 1);
		private System.Threading.Semaphore mSempBufferSalida = new System.Threading.Semaphore(1, 1);

		/// <summary>
		/// Este semaforo sirve para que no se puedan ejecutar metodos simultaneamente como Disconnect y Listen en simultaneo.
		/// </summary>
		private System.Threading.Semaphore mSempAccionesDeEntrada = new System.Threading.Semaphore(1, 1);

		private System.Threading.ManualResetEvent mSempManualEsperadeApagadoEnvioUDP = new ManualResetEvent(true);
		private System.Threading.ManualResetEvent mSempManualEsperadeApagadoEscuchaUDP = new ManualResetEvent(true);

		private System.Net.IPEndPoint mIpRemota = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7006);
		private eEstadosListen mEstadoListen = eEstadosListen.Cerrado;
		private System.Timers.Timer mTimer;
		private List<byte> mBufferEntrada = new List<byte>();
		private List<byte> mBufferSalida = new List<byte>();
		private ushort mPuertoEscucha = 80;
		private bool mEscuchando = false;
		private bool mReListenAutomatico = false;
		private bool mEnvioCheckConexion = false;
		private bool mTestearConexion = false;
		private bool mReConexionAutomatica = false;
		private long mCantBytesTrasmitidos;
		private long mCantBytesRecibidos;
		private int mTiempomSegTestConexion = 1000;
		private readonly Commando mComandoRecibidos = new Commando();
		private eEstadoComando mEstadoComandos = eEstadoComando.SinComando;
		private eCaracteresEsp mUltimoCaracterEspecialRecibido = eCaracteresEsp.CaracterNulo;

		private readonly System.Timers.Timer mTimerVelocidad = new System.Timers.Timer(200);
		private Single mVelocidadDeSubida = 0;
		private Single mVelocidadDeBajada = 0;

		#endregion "Declaraciones"

		#region "Propiedades"

		/// <summary>
		/// Devuelve el estado del sock de escucha
		/// </summary>
		public eEstadosListen EstadoListen
		{
			get
			{
				return mEstadoListen;
			}
		}

		/// <summary>
		/// Devuelve true si el sock se encuentra escuchando algun puerto. sino devuelve false.
		/// </summary>
		public bool Escuchando
		{
			get
			{
				return mEscuchando;
			}
		}

		/// <summary>
		/// Devuelve o establece el numero de puerto usado para escucha.
		/// </summary>
		public ushort PuertoEscucha
		{
			get
			{
				return mPuertoEscucha;
			}
			set
			{
				mPuertoEscucha = value;
			}
		}

		/// <summary>
		/// Devuelve la cantidad de bytes en el buffer de envio
		/// </summary>
		public long CantidadDatosBufferEnvio
		{
			get
			{
				return mBufferSalida.Count;
			}
		}

		/// <summary>
		/// Devuelve la cantidad de bytes en el buffer de recepcion.
		/// </summary>
		public long CantidadDatosBufferRecepcion
		{
			get
			{
				return mBufferEntrada.Count;
			}
		}

		/// <summary>
		/// Devuelve o establece el End Point remoto
		/// </summary>
		public System.Net.IPEndPoint EndPointRemoto
		{
			get
			{
				return mIpRemota;
			}
			set
			{
				if (value != null)
				{
					if (mIpRemota.ToString() != value.ToString())
					{
						mIpRemota = value;
						Console.WriteLine("Ip Remoto Cambiado");
						ClearAll();
					}
				}
			}
		}

		/// <summary>
		/// Devuelve o establece un valor que indica si el control se pone a la escucha automaticamente en caso de perdida de conexion.
		/// </summary>
		public bool ReListenAutomatico
		{
			get
			{
				return mReListenAutomatico;
			}
			set
			{
				mReListenAutomatico = value;
			}
		}

		/// <summary>
		/// Devuelve o establece un valor que indica si el control debe testear la conexion para detectar posibles desconexiones.
		/// </summary>
		public bool TestearConexion
		{
			get
			{
				return mTestearConexion;
			}
			set
			{
				mTestearConexion = value;
			}
		}

		/// <summary>
		/// Devuelve o establece un valor que indica si el control se reconecta automaticamente en caso de perdida de conexion.
		/// </summary>
		public bool ReConexionAutomatica
		{
			get
			{
				return mReConexionAutomatica;
			}
			set
			{
				mReConexionAutomatica = value;
			}
		}

		/// <summary>
		/// Devuelve la cantidad de bytes trasmitidos por el control.
		/// </summary>
		public long CantBytesTrasmitidos
		{
			get
			{
				return mCantBytesTrasmitidos;
			}
		}

		/// <summary>
		/// Devuelve la cantidad de bytes recibidos por el control
		/// </summary>
		public long CantBytesRecibidos
		{
			get
			{
				return mCantBytesRecibidos;
			}
		}

		/// <summary>
		/// Devuelve o establece el tiempo que transcurre entre cada test de conexion.
		/// </summary>
		public int TiempomSegTestConexion
		{
			get
			{
				return mTiempomSegTestConexion;
			}
			set
			{
				mTiempomSegTestConexion = value;
				try
				{
					if (mTimer != null)
					{
						mTimer.Interval = mTiempomSegTestConexion;
					}
				}
				catch
				{
				}
			}
		}

		/// <summary>
		/// Devuelve la velocidad de subida en bit/s para pasar a kb/s divida este valor por 1000
		/// o dividalo por  1000000 para obtenerla en mb/s
		/// </summary>
		public float VelocidadDeSubida
		{
			get
			{
				return mVelocidadDeSubida;
			}
		}

		/// <summary>
		/// Devuelve la velocidad de bajada en bit/s para pasar a kb/s divida este valor por 1000
		/// o dividalo por  1000000 para obtenerla en mb/s
		/// </summary>
		public float VelocidadDeBajada
		{
			get
			{
				return mVelocidadDeBajada;
			}
		}

		#endregion "Propiedades"

		#region "Rutinas Publicas"

		public PeerToPeerUdp()
		{
			InitializeComponent();
		}

		private void PrepararTimerVelocidad()
		{
			if (mTimerVelocidad.Enabled == false)
			{
				mTimerVelocidad.AutoReset = false;
				mTimerVelocidad.Elapsed += mTimerVelocidad_Elapsed;
				mTimerVelocidad.Start();
			}
		}

		private long mCantBytesTransmitidosTemp = -1;
		private long mCantBytesRecibidosTemp = -1;
		private DateTime mTiempoUltimaMuestra;

		private struct ByteTimeData
		{
			public readonly long Bytes;
			public DateTime TimeStamp;

			public ByteTimeData(long bytesCount, DateTime timeStamp)
			{
				Bytes = bytesCount;
				TimeStamp = timeStamp;
			}
		}

		private List<ByteTimeData> mTamañoUltimasTransmisiones = new List<ByteTimeData>();
		private List<ByteTimeData> mTamañoUltimasRecepciones = new List<ByteTimeData>();

		private void mTimerVelocidad_Elapsed(object sender, ElapsedEventArgs e)
		{
			const byte cTiempoIntegral = 15;

			mTamañoUltimasTransmisiones.Add(new ByteTimeData(CantBytesTrasmitidos, DateTime.Now));
			mTamañoUltimasRecepciones.Add(new ByteTimeData(CantBytesRecibidos, DateTime.Now));

			if (mTamañoUltimasTransmisiones.Count > cTiempoIntegral)
			{
				mTamañoUltimasTransmisiones.RemoveRange(0, mTamañoUltimasTransmisiones.Count - cTiempoIntegral);
			}

			if (mTamañoUltimasRecepciones.Count > cTiempoIntegral)
			{
				mTamañoUltimasRecepciones.RemoveRange(0, mTamañoUltimasRecepciones.Count - cTiempoIntegral);
			}

			int mBytesTransmitidos = 0;
			for (int i = 1; i < mTamañoUltimasTransmisiones.Count; i++)
			{
				mBytesTransmitidos = mBytesTransmitidos + ((int)(mTamañoUltimasTransmisiones[i].Bytes - mTamañoUltimasTransmisiones[i - 1].Bytes));
			}
			if (mBytesTransmitidos > 0)
			{
				TimeSpan mTiempoUsado = new TimeSpan(mTamañoUltimasTransmisiones[mTamañoUltimasTransmisiones.Count - 1].TimeStamp.Ticks - mTamañoUltimasTransmisiones[0].TimeStamp.Ticks);
				mVelocidadDeSubida = ((Single)(((mBytesTransmitidos) * 8) / (mTiempoUsado.TotalMilliseconds / 1000)));
			}
			else
			{
				mVelocidadDeSubida = 0;
			}

			int mBytesRecibidos = 0;
			for (int i = 1; i < mTamañoUltimasRecepciones.Count; i++)
			{
				mBytesRecibidos = mBytesRecibidos + ((int)(mTamañoUltimasRecepciones[i].Bytes - mTamañoUltimasRecepciones[i - 1].Bytes));
			}
			if (mBytesRecibidos > 0)
			{
				TimeSpan mTiempoUsado = new TimeSpan(mTamañoUltimasRecepciones[mTamañoUltimasRecepciones.Count - 1].TimeStamp.Ticks - mTamañoUltimasRecepciones[0].TimeStamp.Ticks);
				mVelocidadDeBajada = ((Single)(((mBytesRecibidos) * 8) / (mTiempoUsado.TotalMilliseconds / 1000)));
			}
			else
			{
				mVelocidadDeSubida = 0;
			}
			mTimerVelocidad.Start();
		}

		public PeerToPeerUdp(IContainer container)
		{
			container.Add(this);
			InitializeComponent();
			PrepararTimerVelocidad();
		}

		/// <summary>
		/// Devuelve un string con el estado completo del control
		/// </summary>
		/// <returns>Devuelve un string con el estado completo del control</returns>
		public String Status()
		{
			string mT = "Tipo de Sock: " + "UDP" + "\r\n";
			mT = mT + "Datos Buffer Recepcion: " + this.CantidadDatosBufferRecepcion + "\r\n";
			mT = mT + "Datos Buffer Transmision: " + this.CantidadDatosBufferEnvio + "\r\n";
			mT = mT + "Bytes Recibidos: " + this.CantBytesRecibidos + "\r\n";
			mT = mT + "Vel Bajada: " + this.VelocidadDeBajada.ToString("F") + " bit/s" + "\r\n";
			mT = mT + "Bytes Transmitidos: " + this.CantBytesTrasmitidos + "\r\n";
			mT = mT + "Vel Subida: " + this.VelocidadDeSubida.ToString("F") + " bit/s" + "\r\n";

			mT = mT + "\r\n";
			if (this.EndPointRemoto != null)
			{
				mT = mT + "end point remoto: " + this.EndPointRemoto.ToString() + "\r\n";
			}
			else
			{
				mT = mT + "end point remoto: " + "\r\n";
			}
			mT = mT + "\r\n";
			mT = mT + "Estadolisten: " + this.EstadoListen.ToString() + "\r\n";
			mT = mT + "Escuchando: " + this.Escuchando + "\r\n";
			mT = mT + "Puerto escucha: " + this.PuertoEscucha + "\r\n";
			mT = mT + "RelistenAuto: " + this.ReListenAutomatico + "\r\n";
			mT = mT + "\r\n";
			mT = mT + "ReconexionAuto: " + this.ReConexionAutomatica.ToString() + "\r\n";
			mT = mT + "TestConexion: " + this.TestearConexion.ToString() + " cada: " + this.TiempomSegTestConexion.ToString() + " mSeg" + "\r\n";
			return mT;
		}

		/// <summary>
		/// Conectar a un endpoint remoto siempre y cuando no este ya conectado a un endpoint
		/// </summary>
		/// <param name="ipEndPoint">EndPoint remoto</param>
		public void Connect(System.Net.IPEndPoint ipEndPoint = null)
		{
			try
			{
				mSempAccionesDeEntrada.WaitOne();
				Console.WriteLine("Metodo connect");
				EndPointRemoto = ipEndPoint;
				CrearSubProcesoEnvio();
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				mSempAccionesDeEntrada.Release();
			}
		}

		private bool IsConnect()
		{
			if (mTareaEnvioUDP != null)
			{
				if (mTareaEnvioUDP.Status == TaskStatus.Running)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Cierra todos los socket abiertos
		/// </summary>
		/// <param name="clearAll">Si es true borra todos los buferes usados</param>
		public void Disconnect(bool clearAll = false)
		{
			try
			{
				mSempAccionesDeEntrada.WaitOne();
				Console.WriteLine("Metodo disconect");
				mTokenSourceCancelmTareaEnvioUDP.Cancel();
				Console.WriteLine("Apagando...");
				mSempManualEsperadeApagadoEnvioUDP.WaitOne();
				if (clearAll == true)
				{
					ClearAll();
				}

			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				mSempAccionesDeEntrada.Release();
			}
		}

		/// <summary>
		/// Borra el buffer de Entrada.
		/// </summary>
		public void ClearBufferEntrada()
		{
			try
			{
				mSempBufferEntrada.WaitOne();
				mBufferEntrada.Clear();
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				mSempBufferEntrada.Release();
			}
		}

		/// <summary>
		/// Borra el buffer de Salida.
		/// </summary>
		public void ClearBufferSalida()
		{
			try
			{
				mSempBufferSalida.WaitOne();
				mBufferSalida.Clear();
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				mSempBufferSalida.Release();
			}
		}

		/// <summary>
		/// Borra el buffer de entrada y el de salida y restable a 0 la cantidad de bytes recibidos y bytes transmitidos.
		/// </summary>
		public void ClearAll()
		{
			try
			{
				Console.WriteLine("Metodo ClearAll");
				ClearBufferEntrada();
				ClearBufferSalida();
				mCantBytesRecibidos = 0;
				mCantBytesTrasmitidos = 0;
				mTamañoUltimasTransmisiones.Clear();
				mTamañoUltimasRecepciones.Clear();
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Pone al Sock en estado de escucha siempre y cuando el sock se encuentre apagado
		/// </summary>
		public void Listen()
		{
			try
			{
				mSempAccionesDeEntrada.WaitOne();
				Console.WriteLine("Metodo Listen");
				PonerAEscucharElSock();
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				mSempAccionesDeEntrada.Release();
			}
		}

		/// <summary>
		/// Pone al Sock en estado de escucha siempre y cuando el sock se encuentre apagado
		/// </summary>
		/// <param name="puerto">Numero del puerto de escucha</param>
		public void Listen(ushort puerto)
		{
			try
			{
				mSempAccionesDeEntrada.WaitOne();
				Console.WriteLine("Metodo Listen2");
				if (EstadoListen == eEstadosListen.Cerrado)
				{
					mPuertoEscucha = puerto;
					PonerAEscucharElSock();
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				mSempAccionesDeEntrada.Release();
			}
		}

		/// <summary>
		/// Detiene la eschucha
		/// </summary>
		public void ListenStop()
		{
			try
			{
				mSempAccionesDeEntrada.WaitOne();
				Console.WriteLine("Metodo ListenStop");
				//mListenPedidoUsuario = false;
				mEstadoListen = eEstadosListen.Cerrado;
				mEscuchando = false;
				mTokenSourceCancelmTareaEscuchaUDP.Cancel();
				if (mSockUdpReceive != null)
				{
					mSockUdpReceive.Close();
				}
				mSempManualEsperadeApagadoEscuchaUDP.WaitOne();
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				mSempAccionesDeEntrada.Release();
			}
		}

		/// <summary>
		/// Envia datos a traves del sock a un sock remoto
		/// </summary>
		/// <param name="datosEnvio">String que va a ser enviado</param>
		public void Send(string datosEnvio)
		{
			Send(Encoding.UTF8.GetBytes(datosEnvio));
		}

		/// <summary>
		/// Envia datos a traves del sock a un sock remoto
		/// </summary>
		/// <param name="datosEnvio">Array de byte que va a ser enviado</param>
		public void Send(byte[] datosEnvio)
		{
			try
			{
				mSempAccionesDeEntrada.WaitOne();
				if (datosEnvio != null)
				{
					if (datosEnvio.Length > 0)
					{
						AgregarCaracterEspecial(ref datosEnvio);
						try
						{
							mSempBufferSalida.WaitOne();
							mBufferSalida.AddRange(datosEnvio);
						}
						catch (Exception)
						{
							throw;
						}
						finally
						{
							mSempBufferSalida.Release();
						}
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				mSempAccionesDeEntrada.Release();
				if (IsConnect() == false)
				{
					Connect();
				}
			}
		}

		/// <summary>
		/// Envia datos a traves del sock a un sock remoto
		/// </summary>
		/// <param name="comando">Array de bytes personalizados para el comando a enviar</param>
		/// <param name="datos">Array de bytes personalizados para el dato a enviar</param>
		public void SendComando(byte[] comando, byte[] datos)
		{
			try
			{
				mSempAccionesDeEntrada.WaitOne();
				if (comando != null && datos != null)
				{
					AgregarCaracterEspecial(ref comando);
					AgregarCaracterEspecial(ref datos);
					try
					{
						mSempBufferSalida.WaitOne();
						mBufferSalida.Add((byte)eCaracteresEsp.Commando);
						mBufferSalida.AddRange(comando);
						mBufferSalida.Add((byte)eCaracteresEsp.Data);
						mBufferSalida.AddRange(datos);
						mBufferSalida.Add((byte)eCaracteresEsp.Fin);
					}
					catch (Exception)
					{
						throw;
					}
					finally
					{
						mSempBufferSalida.Release();
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				mSempAccionesDeEntrada.Release();
				if (IsConnect() == false)
				{
					Connect();
				}
			}
		}

		/// <summary>
		/// Envia datos a traves del sock a un sock remoto
		/// </summary>
		/// <param name="comando">String personalizado para el comando a enviar</param>
		public void SendComando(String comando)
		{
			SendComando(comando, new byte[0]);
		}

		/// <summary>
		/// Envia datos a traves del sock a un sock remoto
		/// </summary>
		/// <param name="comando">String personalizado para el comando a enviar</param>
		/// <param name="datos">Array de bytes personalizados para el dato a enviar</param>
		public void SendComando(String comando, byte[] datos)
		{
			SendComando(System.Text.ASCIIEncoding.ASCII.GetBytes(comando), datos);
		}

		/// <summary>
		/// Envia datos a traves del sock a un sock remoto
		/// </summary>
		/// <param name="comando">Array de bytes personalizados para el comando a enviar</param>
		/// <param name="datos">String personalizado para el dato a enviar</param>
		public void SendComando(byte[] comando, string datos)
		{
			SendComando(comando, System.Text.ASCIIEncoding.ASCII.GetBytes(datos));
		}

		/// <summary>
		/// Envia datos a traves del sock a un sock remoto
		/// </summary>
		/// <param name="comando">String personalizado para el comando a enviar</param>
		/// <param name="datos">String personalizado para el dato a enviar</param>
		public void SendComando(string comando, string datos)
		{
			SendComando(System.Text.ASCIIEncoding.ASCII.GetBytes(comando), System.Text.ASCIIEncoding.ASCII.GetBytes(datos));
		}

		/// <summary>
		/// Recupera los bytes que se encuentran en el buffer de recepcion como una cadena string
		/// </summary>
		/// <param name="count">Cantidad de bytes a recuperar</param>
		/// <returns>Retorna una cadena en formato string</returns>
		public string GetDataString(int count = 0)
		{
			return Encoding.UTF8.GetString(GetData(count));
		}

		/// <summary>
		/// Recupera los bytes que se encuentran en el buffer de recepcion
		/// </summary>
		/// <param name="count">Cantidad de bytes a recuperar</param>
		/// <returns>Retorna una matriz unidimensional de bytes</returns>
		public byte[] GetData(int count = 0)
		{
			try
			{
				mSempAccionesDeEntrada.WaitOne();
				mSempBufferEntrada.WaitOne();
				if (mBufferEntrada.Count > 0)
				{
					if (count > 0)
					{
						if (mBufferEntrada.Count > count)
						{
							byte[] mTemp = new byte[count];
							mBufferEntrada.CopyTo(0, mTemp, 0, count);
							mBufferEntrada.RemoveRange(0, count);
							return mTemp;
						}
						else
						{
							byte[] mTemp = new byte[mBufferEntrada.Count];
							mBufferEntrada.CopyTo(mTemp);
							mBufferEntrada.Clear();
							return mTemp;
						}
					}
					else
					{
						byte[] mTemp = new byte[mBufferEntrada.Count];
						mBufferEntrada.CopyTo(mTemp);
						mBufferEntrada.Clear();
						return mTemp;
					}
				}
				else
				{
					return new byte[0];
				}
			}
			finally
			{
				mSempBufferEntrada.Release();
				mSempAccionesDeEntrada.Release();
			}
		}

		/// <summary>
		/// Desencadena el evento conexion establecida
		/// </summary>
		public void OnConexionEstablecidad()
		{
			Console.WriteLine("Evento Conexion Exitosa lanzado");
			if (ConexionEstablecida != null)
			{
				try
				{
					ConexionEstablecida(this, new SockEventArgs(mSockUdpSender));
				}
				catch
				{
				}
			}
		}

		/// <summary>
		/// Desencadena el evento conexion cancelada
		/// </summary>
		public void OnConexionCancelada()
		{
			Console.WriteLine("Evento Conexion Cancelada lanzado");
			if (ConexionCancelada != null)
			{
				try
				{
					ConexionCancelada(this, new SockEventArgs(mSockUdpSender));
				}
				catch
				{
				}
			}
		}

		/// <summary>
		/// Desencadena el evento escucha iniciada
		/// </summary>
		public void OnEscuchaIniciada()
		{
			Console.WriteLine("Evento Escucha Iniciada lanzado");
			if (EscuchaIniciada != null)
			{
				try
				{
					EscuchaIniciada(this, new SockEventArgs(mSockUdpReceive));
				}
				catch
				{
				}
			}
		}

		/// <summary>
		/// Desencadena el evento iniciando escucha
		/// </summary>
		public void OnEscuchaIniciando()
		{
			Console.WriteLine("Evento Escucha Iniciando lanzado");
			if (EscuchaIniciando != null)
			{
				try
				{
					EscuchaIniciando(this, new SockEventArgs(mSockUdpReceive));
				}
				catch
				{
				}
			}
		}

		/// <summary>
		/// Desencadena el evento escucha cancelada
		/// </summary>
		public void OnEscuchaCancelada()
		{
			Console.WriteLine("Evento Escucha Cancelada lanzado");
			if (EscuchaCancelada != null)
			{
				try
				{
					EscuchaCancelada(this, new SockEventArgs(mSockUdpReceive));
				}
				catch
				{
				}
			}
		}

		public void OnDatosRecibidos(byte[] datos)
		{
			//Console.WriteLine("Evento Datos Recibidos");
			if (DatosRecibidos != null)
			{
				try
				{
					DatosRecibidos(this, new SockEventArgs(mSockUdpReceive, datos));
				}
				catch
				{
				}
			}
		}

		/// <summary>
		/// Desencadena el evento conexion perdida
		/// </summary>
		public void OnConexionPerdida()
		{
			Console.WriteLine("Evento Conexion Perdida lanzado");
			if (ConexionPerdida != null)
			{
				try
				{
					ConexionPerdida(this, new SockEventArgs(mSockUdpSender));
				}
				catch
				{
				}
			}
		}

		/// <summary>
		/// Desencadena el evento comando recibido
		/// </summary>
		public void OnComandoRecibido()
		{
			//Console.WriteLine("Evento Comando recibido lanzado");
			if (ComandoRecibido != null)
			{
				try
				{
					ComandoRecibido(this, new SockEventArgs(mSockUdpReceive, mComandoRecibidos));
				}
				catch
				{
				}
			}
		}

		#endregion "Rutinas Publicas"

		#region "Rutinas Privadas"

		private void DetenerSockEscucha()
		{
			if (mSockTcpEscucha != null)
			{
				mSockTcpEscucha.Stop();
				mSockTcpEscucha = null;
				mEscuchando = false;
				Console.WriteLine("Sock de escucha detenido");
				OnEscuchaCancelada();
			}
			mEscuchando = false;
			mSempManualEsperadeApagadoEscuchaUDP.Set();
		}

		private void IniciarSockescucha()
		{
			if (mSockTcpEscucha == null)
			{
				Console.WriteLine("Sock de escucha creado");
				try
				{
					OnEscuchaIniciando();
					mSempManualEsperadeApagadoEscuchaUDP.Reset();
					mEscuchando = true;
					mEstadoListen = eEstadosListen.Escuchando;
					Console.WriteLine("Escuchando... Puerto " + mPuertoEscucha);
					OnEscuchaIniciada();
				}
				catch
				{
					DetenerSockEscucha();
				}
			}
		}

		private void DetenerSock()
		{
			if (mSockUdpSender != null)
			{
				mSockUdpSender.Close();
				mSockUdpSender = null;
				OnConexionCancelada();
				Console.WriteLine("Sock detenido");
			}
		}

		private void PonerAEscucharElSock()
		{
			CrearSubProcesoEscuchaUDP();
		}

		private void RutinaConectado()
		{
			List<byte> mEnvioTemp2 = new List<byte>();
			try
			{
				mSempBufferSalida.WaitOne();
				if (mBufferSalida.Count > 0)
				{
					mEnvioTemp2.AddRange(mBufferSalida.ToArray());
					mBufferSalida.Clear();
				}
			}
			finally
			{
				mSempBufferSalida.Release();
			}

			int mCantidadPorCadaEnvio = 65505;

			do
			{
				if (mEnvioTemp2.Count > 0)
				{
					if ((mEnvioTemp2.Count) >= mCantidadPorCadaEnvio)
					{
						try
						{
							byte[] T = mEnvioTemp2.GetRange(0, mCantidadPorCadaEnvio).ToArray();
							mSockUdpSender.Send(T, T.Length, EndPointRemoto);
							mEnvioTemp2.RemoveRange(0, mCantidadPorCadaEnvio);
						}
						catch (Exception)
						{
						}
						finally
						{
							mCantBytesTrasmitidos = mCantBytesTrasmitidos + mCantidadPorCadaEnvio;
						}
					}
					else
					{
						int mCantEnviado = mEnvioTemp2.Count;
						try
						{
							mSockUdpSender.Send(mEnvioTemp2.ToArray(), mEnvioTemp2.Count, EndPointRemoto);
							mEnvioTemp2.Clear();
						}
						catch (Exception)
						{
						}
						finally
						{
							mCantBytesTrasmitidos = mCantBytesTrasmitidos + mCantEnviado;
						}

					}
				}
				else
				{
					if (mTestearConexion)
					{
						if (mEnvioCheckConexion)
						{
							mEnvioCheckConexion = false;
							byte[] mTest = new byte[1] { (byte)eCaracteresEsp.Ok };

							try
							{
								mSockUdpSender.Send(mTest, 1, EndPointRemoto);
							}
							catch (Exception)
							{
								throw;
							}
							mCantBytesTrasmitidos = mCantBytesTrasmitidos + mTest.Length;
						}
					}
				}
			} while (mEnvioTemp2.Count > 0);
		}

		private void mTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			mEnvioCheckConexion = true;
		}

		private void AgregarCaracterEspecial(ref byte[] buffer)
		{
			int mRecuentoCaracteresEspeciales = 0;

			for (int i = 0; i < buffer.Length; i++)
			{
				if (buffer[i] < 5)
				{
					mRecuentoCaracteresEspeciales++;
				}
			}

			byte[] mEnvioTemp = new byte[buffer.Length + mRecuentoCaracteresEspeciales];

			int mPosicionTemp = 0;

			foreach (byte mT in buffer)
			{
				if (mT < 5)
				{
					mEnvioTemp[mPosicionTemp] = (byte)eCaracteresEsp.Barra;
					mPosicionTemp++;
				}
				mEnvioTemp[mPosicionTemp] = mT;
				mPosicionTemp++;
			}

			buffer = mEnvioTemp;
		}

		/// <summary>
		/// Esta rutina quita los caracteres especiales de la secuencia y se encarga de procesar los comandos
		/// </summary>
		/// <param name="recibido">Datos recibidos</param>
		private void ProcesarComandos(ref byte[] recibido)
		{
			if (recibido.Length == 0)
			{
				recibido = new byte[0];
				return;
			}

			List<byte> mRecibidosTemp = new List<byte>();
			List<byte> mComandos = new List<byte>();
			List<byte> mDatos = new List<byte>();

			for (int i = 0; i < recibido.Length; i++)
			{
				if (RevisarCaracteresIndices(ref recibido[i]))
				{
					mRecibidosTemp.Add(recibido[i]);
					switch (mEstadoComandos)
					{
						case eEstadoComando.GuardandoComando:
							mComandos.Add(recibido[i]);
							break;
						case eEstadoComando.GuardandoDatos:
							mDatos.Add(recibido[i]);
							break;
					}
				}
				else
				{
					if (mEstadoComandos == eEstadoComando.ComandoFinalizado)
					{
						mEstadoComandos = eEstadoComando.SinComando;
						mComandoRecibidos.Comando.AddRange(mComandos);
						mComandoRecibidos.Dato.AddRange(mDatos);
						//disparar evento
						OnComandoRecibido();
						mComandoRecibidos.Clear();
						mComandos.Clear();
						mDatos.Clear();
					}
				}
			}
			mComandoRecibidos.Comando.AddRange(mComandos);
			mComandoRecibidos.Dato.AddRange(mDatos);
			recibido = new byte[mRecibidosTemp.Count];
			mRecibidosTemp.CopyTo(recibido);
		}

		/// <summary>
		/// Esta rutina retorna true si el caracter pasado es valido, o falso si el caracter pasado debe suprimirse
		/// </summary>
		/// <param name="caracterAnalizado">Byte analizado</param>
		/// <returns></returns>
		private bool RevisarCaracteresIndices(ref byte caracterAnalizado)
		{
			if (caracterAnalizado < 5)
			{
				if (mUltimoCaracterEspecialRecibido != eCaracteresEsp.Barra)
				{
					switch (caracterAnalizado)
					{
						case (byte)eCaracteresEsp.Commando:
							mEstadoComandos = eEstadoComando.GuardandoComando;
							break;
						case (byte)eCaracteresEsp.Data:
							mEstadoComandos = eEstadoComando.GuardandoDatos;
							break;
						case (byte)eCaracteresEsp.Fin:
							if (mEstadoComandos == eEstadoComando.GuardandoComando || mEstadoComandos == eEstadoComando.GuardandoDatos)
							{
								mEstadoComandos = eEstadoComando.ComandoFinalizado;
							}
							break;
						case (byte)eCaracteresEsp.Ok:
							break;
					}
					mUltimoCaracterEspecialRecibido = (eCaracteresEsp)caracterAnalizado;
					return false;
				}
				else
				{
					mUltimoCaracterEspecialRecibido = eCaracteresEsp.CaracterNulo;
					return true;
				}
			}
			else
			{
				return true;
			}
		}

		#endregion "Rutinas Privadas"

		#region "Control Sub Procesos"

		private void CrearSubProcesoEnvio()
		{
			if (IsDesignMode() == false)
			{
				if (mTareaEnvioUDP == null || mTareaEnvioUDP.Status != TaskStatus.Running)
				{
					mTokenSourceCancelmTareaEnvioUDP = new CancellationTokenSource();
					mTokenCancelmTareaEnvioUDP = mTokenSourceCancelmTareaEnvioUDP.Token;
					mTareaEnvioUDP = new System.Threading.Tasks.Task(new Action(SubProcesoEnvioUDP), mTokenCancelmTareaEnvioUDP);
					mTareaEnvioUDP.Start();
				}
			}
		}

		private void CrearSubProcesoEscuchaUDP()
		{
			if (IsDesignMode() == false)
			{
				if (mTareaEscuchaUDP == null || mTareaEscuchaUDP.Status != TaskStatus.Running)
				{
					mTokenSourceCancelmTareaEscuchaUDP = new CancellationTokenSource();
					mTokenCancelmTareaEscuchaUDP = mTokenSourceCancelmTareaEscuchaUDP.Token;
					mTareaEscuchaUDP = new System.Threading.Tasks.Task(new Action(SupProcesoEscuchaUDP), mTokenCancelmTareaEscuchaUDP);
					mTareaEscuchaUDP.Start();
				}
			}
		}

		#endregion "Control Sub Procesos"

		#region "SubProcesos"

		private void SubProcesoEnvioUDP()
		{
			try
			{
				Console.WriteLine("SubProcesoEnvioUDP() Iniciado");
				Thread.CurrentThread.Name = "SubProcesoEnvioUDP";
				mSempManualEsperadeApagadoEnvioUDP.Reset();

				if (mTimer == null)
				{
					mTimer = new System.Timers.Timer(mTiempomSegTestConexion);
					mTimer.Elapsed += mTimer_Elapsed;
					mTimer.Start();
				}
				if (mSockUdpSender == null)
				{
					mSockUdpSender = new UdpClient();
				}

				while (mTokenCancelmTareaEnvioUDP.IsCancellationRequested == false) //mCancelarSubProceso == false
				{
					RutinaConectado();
					System.Threading.Thread.Sleep(10);
				}

				if (mTimer != null)
				{
					mTimer.Stop();
					mTimer = null;
				}
			}
			catch (Exception)
			{

			}
			finally
			{
				mEstadoListen = eEstadosListen.Cerrado;
				DetenerSock();
				mSempManualEsperadeApagadoEnvioUDP.Set();
				Console.WriteLine("SubProcesoEnvioUDP() Terminado");
			}
		}

		private void SupProcesoEscuchaUDP()
		{
			try
			{
				mSempManualEsperadeApagadoEscuchaUDP.Reset();
				Console.WriteLine("SupProcesoEscuchaUDP() Iniciado");
				Thread.CurrentThread.Name = "SubProcesoEscuchaUDP";

				if (mSockUdpReceive == null)
				{
					try
					{
						mSockUdpReceive = new UdpClient(new IPEndPoint(IPAddress.Any, PuertoEscucha));
						mEstadoListen = eEstadosListen.Escuchando;
						mEscuchando = true;
					}
					catch (Exception)
					{
						return;
					}
				}


				IPEndPoint mIpSender = new IPEndPoint(IPAddress.Any, 0);

				while (mTokenCancelmTareaEscuchaUDP.IsCancellationRequested == false)
				{



					byte[] datos = new byte[0];
					try
					{
						datos = mSockUdpReceive.Receive(ref mIpSender);
					}
					catch (Exception)
					{
						mSockUdpReceive = null;
					}

					mCantBytesRecibidos = mCantBytesRecibidos + datos.Length;
					ProcesarComandos(ref datos);

					if (datos.Length > 0)
					{
						mSempBufferEntrada.WaitOne();
						mBufferEntrada.AddRange(datos);
						mSempBufferEntrada.Release();
						OnDatosRecibidos(datos);
					}
				}
			}
			finally
			{
				Console.WriteLine("SupProcesoEscuchaUDP() Terminado");
				mSempManualEsperadeApagadoEscuchaUDP.Set();
			}
		}

		#endregion "SubProcesos"

		#region "ModoDiseño"

		private static bool? isDesignMode;

		private static bool IsDesignMode()
		{
			if (isDesignMode == null)
				isDesignMode = (Process.GetCurrentProcess().ProcessName.ToLower().Contains("devenv"));

			return isDesignMode.Value;
		}

		#endregion "ModoDiseño"
	}
}
