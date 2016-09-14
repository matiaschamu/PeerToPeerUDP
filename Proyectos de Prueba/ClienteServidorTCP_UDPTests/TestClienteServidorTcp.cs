﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClienteServidorTCP_UDPTests
{
	[TestClass]
	public class TestClienteServidorUDP
	{
		[TestMethod]
		public void TestProcesarComandos()
		{
			PrivateObject mObj = new PrivateObject(typeof( PeerToPeerUdp.PeerToPeerUdp));
			byte[] mRecibidos =
			{
				0x48, 0x6F, 0x6C, 0x01, 0x61, 0x20, 0x4D, 0x61, 0x74, 0x6F, 0x3F, 0x20, 0x54, 0x6F, 0x64, 0x6F, 0x20, 0x62, 0x69,
				0x65, 0x6E, 0x00, 0x04, 0x00, 0x04, 0x3F, 0x20, 0x45, 0x73, 0x70, 0x00, 0x03, 0x00, 0x03, 0x65, 0x72, 0x6F, 0x20,
				0x71, 0x75, 0x65, 0x20, 0x02, 0x6C, 0x61, 0x01, 0x20, 0x03, 0x04, 0x70, 0x72, 0x75, 0x65, 0x62, 0x61, 0x20, 0x71,
				0x75, 0x65, 0x20, 0x65, 0x73, 0x74, 0x61, 0x73, 0xFF, 0xFF, 0x20, 0x68, 0x00, 0x02, 0x61, 0x63, 0x02, 0x03, 0x04, 0x69, 0x65,
				0x6E, 0x64, 0x6F, 0x20, 0x00, 0x00, 0x73, 0x61, 0x6C, 0x01, 0x67, 0x61, 0x20, 0x63, 0x6F, 0x02, 0x03, 0x72, 0x72,
				0x65, 0x04, 0x63, 0x74, 0x61, 0x6D, 0x65, 0x6E, 0x74, 0x00, 0x01, 0x65, 0x2E
			};

			byte[] mEsperado =
			{
				0x48, 0x6F, 0x6C, 0x61, 0x20, 0x4D, 0x61, 0x74, 0x6F, 0x3F, 0x20, 0x54, 0x6F, 0x64, 0x6F, 0x20, 0x62, 0x69, 0x65,
				0x6E, 0x04, 0x04, 0x3F, 0x20, 0x45, 0x73, 0x70, 0x03, 0x03, 0x65, 0x72, 0x6F, 0x20, 0x71, 0x75, 0x65, 0x20, 0x6C,
				0x61, 0x20, 0x70, 0x72, 0x75, 0x65, 0x62, 0x61, 0x20, 0x71, 0x75, 0x65, 0x20, 0x65, 0x73, 0x74, 0x61, 0x73, 0xFF, 0xFF, 0x20,
				0x68, 0x02, 0x61, 0x63, 0x69, 0x65, 0x6E, 0x64, 0x6F, 0x20, 0x00, 0x73, 0x61, 0x6C, 0x67, 0x61, 0x20, 0x63, 0x6F,
				0x72, 0x72, 0x65, 0x63, 0x74, 0x61, 0x6D, 0x65, 0x6E, 0x74, 0x01, 0x65, 0x2E
			};

			Type[] mTypes = {typeof (byte[]).MakeByRefType()};
			object[] mArgs = {mRecibidos};
			mObj.Invoke("ProcesarComandos", mTypes, mArgs);

			Assert.AreEqual(mEsperado.Length, ((byte[]) (mArgs[0])).Length);
			for (int mI = 0; mI < mEsperado.Length; mI++)
			{
				Assert.AreEqual(mEsperado[mI], ((byte[]) (mArgs[0]))[mI]);
			}
		}

		//[TestMethod]
		//public void TestTamañoBufferSinContarCaracteresEspeciales()
		//{
		//	PrivateObject mObj = new PrivateObject(typeof( PeerToPeerUdp.PeerToPeerUdp));
		//	byte[] mBuffer1 =
		//	{
		//		0x48, 0x6F, 0x6C, 0x01, 0x61, 0x20, 0x4D, 0x61, 0x74, 0x6F, 0x3F, 0x20, 0x54, 0x6F, 0x64, 0x6F, 0x20, 0x62, 0x69, 0x65, 
		//		0x6E, 0x00, 0x04, 0x00, 0x04, 0x3F, 0x20, 0x45, 0x73, 0x70, 0x00, 0x03, 0x00, 0x03, 0x65, 0x72, 0x6F, 0x20, 0x71, 0x75, 
		//		0x65, 0x20, 0x02, 0x6C, 0x61, 0x01, 0x20, 0x03, 0x04, 0x70, 0x72, 0x75, 0x65, 0x62, 0x61, 0x20, 0x71, 0x75, 0x65, 0x20, 
		//		0x65, 0x73, 0x74, 0x61, 0x73, 0xFF, 0xFF, 0x20, 0x68, 0x00, 0x02, 0x61, 0x63, 0x02, 0x03, 0x04, 0x69, 0x65, 0x6E, 0x64, 
		//		0x6F, 0x20, 0x00, 0x00, 0x73, 0x61, 0x6C, 0x01, 0x67, 0x61, 0x20, 0x63, 0x6F, 0x02, 0x03, 0x72, 0x72, 0x65, 0x04, 0x63, 
		//		0x74, 0x61, 0x6D, 0x65, 0x6E, 0x74, 0x00, 0x01, 0x65, 0x2E, 0x20, 0x63, 0x6F, 0x02, 0x03, 0x72, 0x72, 0x65, 0x04, 0x63, 0x00
		//	};
		//	byte[] mBuffer2 =
		//	{
		//		0x00, 0x48, 0x6F, 0x6C, 0x01, 0x61, 0x20, 0x4D, 0x61, 0x74, 0x6F, 0x3F, 0x20, 0x54, 0x6F, 0x64, 0x6F, 0x20, 0x62, 0x69, 0x65, 
		//		0x6E, 0x00, 0x04, 0x00, 0x04, 0x3F, 0x20, 0x45, 0x73, 0x70, 0x00, 0x03, 0x00, 0x03, 0x65, 0x72, 0x6F, 0x20, 0x71, 0x75, 
		//		0x65, 0x20, 0x02, 0x6C, 0x61, 0x01, 0x20, 0x03, 0x04, 0x70, 0x72, 0x75, 0x65, 0x62, 0x61, 0x20, 0x71, 0x75, 0x65, 0x20, 
		//		0x65, 0x73, 0x74, 0x61, 0x73, 0xFF, 0xFF, 0x20, 0x68, 0x00, 0x02, 0x61, 0x63, 0x02, 0x03, 0x04, 0x69, 0x65, 0x6E, 0x64, 
		//		0x6F, 0x20, 0x00, 0x00, 0x73, 0x61, 0x6C, 0x01, 0x67, 0x61, 0x20, 0x63, 0x6F, 0x02, 0x03, 0x72, 0x72, 0x65, 0x04, 0x63, 
		//		0x74, 0x61, 0x6D, 0x65, 0x6E, 0x74, 0x00, 0x01, 0x65, 0x2E, 0x20, 0x63, 0x6F, 0x02, 0x03, 0x72, 0x72, 0x65, 0x04, 0x63, 0x00
		//	};

		//	int mEsperado = 196;

		//	Type[] mTypes = { typeof(byte[]).MakeByRefType() };
		//	object[] mArgs = { mBuffer1 };
		//	int mResult = (int) mObj.Invoke("TamañoBufferSinContarCaracteresEspeciales", mTypes, mArgs);

		//	mArgs = new object[] { mBuffer2 };
		//	mResult += (int)mObj.Invoke("TamañoBufferSinContarCaracteresEspeciales", mTypes, mArgs);

		//	Assert.AreEqual(mEsperado ,mResult);
		//}
	}
}
