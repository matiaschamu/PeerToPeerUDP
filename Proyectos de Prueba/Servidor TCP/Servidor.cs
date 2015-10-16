using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Servidor_TCP
{
	public partial class Servidor : Form
	{
		private int mBytesRecibidosCount = 0;
		private int mComandosRecibidosCount = 0;
		//int mNumeromSegServidor = 0;
		//int mPuertoCliente = 7006;
		private delegate void EscribirLabel(String Mensajes);

		//private struct SocketsClientes
		//{
		//	public System.Net.Sockets.TcpClient Clientes;
		//	public string DatoInicial;
		//}
//private void LanzarSubProceso()
		//{
		//	mP = new System.Threading.Thread(SubprocesoTcpIp);
		//	mP.IsBackground = true;
		//	mP.Name = "Escucha";
		//	mP.Start();
		//}

		//private void SubprocesoTcpIp()
		//{
		//	//int mEnviados = 0;
		//	IPHostEntry mHost = Dns.GetHostEntry("localhost");
		//	byte[] mDirec = {127, 0, 0, 1};
		//	IPAddress mIpAddresss = IPAddress.Any;
		//	System.Net.Sockets.TcpListener mEscuchaTcp = null;
		//	SocketsClientes[] mListaClientes = new SocketsClientes[0];
		//	NetworkStream mCanal = null;
		//	EscribirLabelBytesCount("Escuchando: " + mListaClientes.Length + " Usuarios Conectados");


		//	System.Net.Sockets.UdpClient mClienteUdp = null;

		//	try
		//	{
		//		while (true)
		//		{
		//			if (mEsTcp)
		//			{
		//				if (mEscuchaTcp == null)
		//				{
		//					mEscuchaTcp = new System.Net.Sockets.TcpListener(mIpAddresss, mPuertoServidor);
		//					mEscuchaTcp.ExclusiveAddressUse = false;
		//					mEscuchaTcp.Start();
		//				}
		//			}
		//			else
		//			{
		//				if (mClienteUdp == null)
		//				{
		//					mClienteUdp = new UdpClient(new IPEndPoint(mIpAddresss, mPuertoServidor));
		//				}
		//			}
		//			//bool mClientesNuevos = false;
		//			do
		//			{
		//				if (mEsTcp)
		//				{

		//					if (mEscuchaTcp.Pending() == true)
		//					{
		//						System.Array.Resize(ref mListaClientes, mListaClientes.Length + 1);
		//						mListaClientes[mListaClientes.Length - 1].Clientes = mEscuchaTcp.AcceptTcpClient();
		//						mListaClientes[mListaClientes.Length - 1].DatoInicial = textBoxServidor.Text;
		//						//mClientesNuevos = true;
		//						EscribirLabelBytesCount("Escuchando: " + mListaClientes.Length + " Usuarios Conectados");
		//					}
		//					else
		//					{
		//						break;
		//					}
		//				}
		//				else
		//				{

		//					bool done = false;
		//					//ClienteUDP = new UdpClient(mPuertoServidor);
		//					IPEndPoint mGroupEp = new IPEndPoint(mIpAddresss, mPuertoServidor);
		//					try
		//					{
		//						while (!done)
		//						{
		//							if (mClienteUdp.Available > 0)
		//							{
		//								byte[] bytes = mClienteUdp.Receive(ref mGroupEp);
		//								EscribirTextoDatosRecibidos(Encoding.ASCII.GetString(bytes, 0, bytes.Length) + " - UDP");
		//							}
		//						}
		//					}
		//					catch (Exception e)
		//					{
		//						Console.WriteLine(e.ToString());
		//					}
		//					finally
		//					{
		//						mClienteUdp.Close();
		//					}
		//				}
		//			} while (true);




		//			if (mEsTcp)
		//			{
		//				System.Text.ASCIIEncoding Tex = new ASCIIEncoding();
		//				bool mError = false;
		//				for (int i = 0; i < mListaClientes.Length; i++)
		//				{
		//					NetworkStream mStream = null;
		//					try
		//					{

		//						mStream = mListaClientes[i].Clientes.GetStream();

		//						if (mStream.DataAvailable == true)
		//						{
		//							byte[] mDatos = new byte[1024];
		//							int mLeidos = mStream.Read(mDatos, 0, 1024);
		//							Array.Resize(ref mDatos, mLeidos);
		//							EscribirTextoDatosRecibidos(Tex.GetString(mDatos) + " - TCP");
		//						}
		//					}
		//					catch (Exception e)
		//					{
		//						if (mStream != null)
		//						{
		//							mStream.Dispose();
		//							mStream = null;
		//						}
		//						mListaClientes[i].Clientes.Close();
		//						mListaClientes[i].Clientes = null;
		//						mError = true;
		//					}
		//				}

		//				if (mError == true)
		//				{
		//					SocketsClientes[] mListaClientesTemp = new SocketsClientes[0];
		//					foreach (SocketsClientes C in mListaClientes)
		//					{
		//						if (C.Clientes != null)
		//						{
		//							Array.Resize(ref mListaClientesTemp, mListaClientesTemp.Length + 1);
		//							mListaClientesTemp[mListaClientesTemp.Length - 1] = C;
		//						}
		//					}
		//					mListaClientes = mListaClientesTemp;
		//					mListaClientesTemp = null;
		//				}

		//			}
		//		}
		//	}
		//	catch (System.Threading.ThreadAbortException e)
		//	{
		//		EscribirLabelBytesCount("Abortado");
		//	}
		//	catch (Exception e)
		//	{
		//		EscribirLabelBytesCount("Puerto no disponible");
		//	}
		//	finally
		//	{
		//		if (mEscuchaTcp != null)
		//		{
		//			mEscuchaTcp.Stop();
		//			mEscuchaTcp = null;
		//		}
		//		if (mCanal != null)
		//		{
		//			mCanal.Close();
		//			//mCanal.Dispose();
		//			mCanal = null;
		//		}
		//		if (mClienteUdp != null)
		//		{
		//			mClienteUdp.Close();
		//			mClienteUdp = null;
		//		}
		//	}
		//}
		public Servidor()
		{
			InitializeComponent();
		}

		private void EscribirTextoComando(string texto)
		{
			if (textBoxComandoRecibido.InvokeRequired == true)
			{
				EscribirLabel D = new EscribirLabel(EscribirTextoComando);
				this.Invoke(D, texto);
			}
			else
			{
				textBoxComandoRecibido.Text = textBoxComandoRecibido.Text + texto;
			}
		}

		private void EscribirTextoDatosRecibidos(string texto)
		{
			if (textBoxDatosRecibidos.InvokeRequired == true)
			{
				EscribirLabel D = new EscribirLabel(EscribirTextoDatosRecibidos);
				this.Invoke(D, texto);
			}
			else
			{
				textBoxDatosRecibidos.Text = textBoxDatosRecibidos.Text + texto;
			}
		}

		private void EscribirLabelBytesCount(string mensaje)
		{
			if (labelBytesCount.InvokeRequired == true)
			{
				EscribirLabel D = new EscribirLabel(EscribirLabelBytesCount);
				this.Invoke(D, mensaje);
			}
			else
			{
				labelBytesCount.Text = mensaje;
				//labelBytesCount.Refresh();
			}
		}

		private void EscribirLabelInformacion(string mensaje)
		{
			if (labelBytesCount.InvokeRequired == true)
			{
				EscribirLabel D = new EscribirLabel(EscribirLabelInformacion);
				this.BeginInvoke(D, mensaje);
			}
			else
			{
				labelInformacion.Text = mensaje;
				//labelBytesCount.Refresh();
			}
		}

		private void EscribirLabelComandosCount(string mensaje)
		{
			if (labelComandosCount.InvokeRequired == true)
			{
				EscribirLabel D = new EscribirLabel(EscribirLabelComandosCount);
				this.Invoke(D, mensaje);
			}
			else
			{
				labelComandosCount.Text = mensaje;
				//labelComandosCount.Refresh();
			}
		}

		private void buttonEnviarCliente_Click(object sender, EventArgs e)
		{
			clienteServidorTCP_UDP1.Send(textBoxDatosEnviados.Text);
			textBoxDatosEnviados.Clear();
		}

		private void buttonEnviarCommando_Click(object sender, EventArgs e)
		{
			clienteServidorTCP_UDP1.SendComando(textBoxEnviarComando.Text, textBoxEnviarDato.Text);
			textBoxEnviarDato.Clear();
		}


		private void buttonSetPuerto_Click(object sender, EventArgs e)
		{
			clienteServidorTCP_UDP1.Listen(ushort.Parse(textBoxPuertoServidor.Text));
		}

		private void buttonunSet_Click(object sender, EventArgs e)
		{
			clienteServidorTCP_UDP1.ListenStop();
		}

		private void buttonConectar_Click(object sender, EventArgs e)
		{
			clienteServidorTCP_UDP1.Connect(new IPEndPoint(IPAddress.Parse(textBox1.Text), int.Parse(textBoxPuertoCliente.Text)));
		}

		private void buttonDesConectar_Click(object sender, EventArgs e)
		{
			clienteServidorTCP_UDP1.Disconnect();
		}

		private void buttonSetInterval_Click(object sender, EventArgs e)
		{
			clienteServidorTCP_UDP1.TiempomSegTestConexion = int.Parse(textBoxIntervalTest.Text);
		}

		private void checkBoxTestConnect_CheckedChanged(object sender, EventArgs e)
		{
			clienteServidorTCP_UDP1.TestearConexion = checkBoxTestConnect.Checked;
		}

		private void checkBoxReConnect_CheckedChanged(object sender, EventArgs e)
		{
			clienteServidorTCP_UDP1.ReConexionAutomatica = checkBoxReConnect.Checked;
		}

		private void checkBoxReListen_CheckedChanged(object sender, EventArgs e)
		{
			clienteServidorTCP_UDP1.ReListenAutomatico = checkBoxReListen.Checked;
		}






		private void clienteServidorTCP_UDP1_ConexionEstablecida(object sender, PeerToPeerTcpUdp.SockEventArgs e)
		{
			EscribirLabelInformacion("Conectado");
		}

		private void clienteServidorTCP_UDP1_ConexionPerdida(object sender, PeerToPeerTcpUdp.SockEventArgs e)
		{
			EscribirLabelInformacion("Conexion Perdida");
		}

		private void clienteServidorTCP_UDP1_ConexionCancelada(object sender, PeerToPeerTcpUdp.SockEventArgs e)
		{
			EscribirLabelInformacion("Conexion cancelada");
		}

		private void clienteServidorTCP_UDP1_DatosRecibidos(object sender, PeerToPeerTcpUdp.SockEventArgs e)
		{
			mBytesRecibidosCount += e.DatosRecibidos.Length;
			EscribirLabelBytesCount("recibido: " + mBytesRecibidosCount);
			clienteServidorTCP_UDP1.ClearBufferEntrada();
			//EscribirTextoDatosRecibidos(clienteServidorTCP_UDP1.GetDataString() + "\r\n");
		}

		private void clienteServidorTCP_UDP1_ComandoRecibido(object sender, PeerToPeerTcpUdp.SockEventArgs e)
		{
			mComandosRecibidosCount++;
			EscribirLabelComandosCount("recibido: " + mComandosRecibidosCount);

			if (e.ComandoRecibido.CommandoString == "Archivo.zip")
			{
				System.IO.FileStream F = new FileStream("archivo2.rar", FileMode.Append);
				F.Write(e.ComandoRecibido.DatosBytes, 0, e.ComandoRecibido.DatosBytes.Length);
				F.Close();
			}

			


			//EscribirTextoComando(e.ComandoRecibido.CommandoString + " -> " + e.ComandoRecibido.DatosString + "\r\n");
		}

		private void clienteServidorTCP_UDP1_EscuchaIniciada(object sender, PeerToPeerTcpUdp.SockEventArgs e)
		{
			EscribirLabelInformacion("Escuchando");
		}

		private void clienteServidorTCP_UDP1_EscuchaCancelada(object sender, PeerToPeerTcpUdp.SockEventArgs e)
		{
			EscribirLabelInformacion("Escuha cancelada");
		}

		private void clienteServidorTCP_UDP1_EscuchaIniciando(object sender, PeerToPeerTcpUdp.SockEventArgs e)
		{
			EscribirLabelInformacion("Iniciando escucha...");
		}

		private void timerStatus_Tick(object sender, EventArgs e)
		{
			textBoxStatusControl.Text = clienteServidorTCP_UDP1.Status();
		}









		private void buttonEnviarRafaga_Click(object sender, EventArgs e)
		{
			Byte[] mData = new byte[1000000];
			for (int mI = 0; mI < mData.Length; mI++)
			{
				mData[mI] = (byte) mI;
			}
			clienteServidorTCP_UDP1.Send(mData);
		}

		private void buttonEnviarArchivo_Click(object sender, EventArgs e)
		{
			System.IO.FileStream S = null;
			try
			{
				S = new FileStream("Archivo.zip", FileMode.Open);
				int mBytesLeidos = 0;
				byte[] Data = new byte[10000];
				int offset = 0;
				mBytesLeidos = S.Read(Data, offset, 10000);
				do
				{
					if (mBytesLeidos == 10000)
					{
						clienteServidorTCP_UDP1.SendComando("Archivo.zip", Data);
					}
					else
					{
						byte[] mD = Data;
						Array.Resize(ref mD, mBytesLeidos);
						clienteServidorTCP_UDP1.SendComando("Archivo.zip", mD);
					}
					mBytesLeidos = S.Read(Data, offset, 10000);
				} while (mBytesLeidos > 0);
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				if (S != null) S.Close();
			}

		}




	}
}