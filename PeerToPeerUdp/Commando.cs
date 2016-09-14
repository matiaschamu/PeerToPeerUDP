using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeerToPeerUdp
{
	public class Commando
	{
		public List<byte> Comando = new List<byte>();
		public List<byte> Dato = new List<byte>();

		public Commando()
		{
			//Comando = new byte[0];
			//Dato = new byte[0];
		}

		//public void AddComando(byte[] comando)
		//{
		//	if ((comando != null) && (comando.Length > 0))
		//	{
		//		Array.Resize(ref Comando, Comando.Length + comando.Length);
		//		Array.Copy(comando, 0, Comando, Comando.Length - comando.Length, comando.Length);
		//	}
		//}

		//public void AddDato(byte[] datos)
		//{
		//	if ((datos != null) && (datos.Length > 0))
		//	{
		//		Array.Resize(ref Dato, Dato.Length + datos.Length);
		//		Array.Copy(datos, 0, Dato, Dato.Length - datos.Length, datos.Length);
		//	}
		//}

		public byte[] CommandoBytes
		{
			get
			{
				return Comando.ToArray();
			}
		}

		public string CommandoString
		{
			get
			{
				return System.Text.Encoding.ASCII.GetString(CommandoBytes);
			}
		}

		public byte[] DatosBytes
		{
			get
			{
				return Dato.ToArray();
			}
		}

		public string DatosString
		{
			get
			{
				return System.Text.Encoding.ASCII.GetString(DatosBytes);
			}
		}

		public void Clear()
		{
			Comando.Clear();
			Dato.Clear();
		}
	}
}
