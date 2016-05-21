using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeerToPeerTcpUdp
{
	public class SockEventArgs : EventArgs
	{
		public System.Net.Sockets.UdpClient Socket = null;
		public readonly Commando ComandoRecibido;
		private readonly byte[] mDatosRecibidos = new byte[0];


		public SockEventArgs(System.Net.Sockets.UdpClient socket, byte[] datosRecibidos = null)
		{
			Socket = socket;
			if (datosRecibidos != null)
			{
				this.mDatosRecibidos = datosRecibidos;
			}
		}

		public SockEventArgs(System.Net.Sockets.UdpClient socket, Commando comandoRecibido)
		{
			Socket = socket;
			ComandoRecibido = comandoRecibido;
		}

		public byte[] DatosRecibidos
		{
			get { return mDatosRecibidos; }
		}

		public string DatosRecibidosString
		{
			get
			{
				return Encoding.UTF8.GetString(mDatosRecibidos);
			}
		}
	}
}
