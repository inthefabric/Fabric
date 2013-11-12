using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Fabric.New.Infrastructure.Util {

	//adapted from http://www.4guysfromrolla.com/webtech/090501-1.shtml

	/*================================================================================================*/
	public static class EncryptUtil {

		static private readonly Byte[] Key = new Byte[8];
		static private readonly Byte[] Iv = new Byte[8];


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string EncryptData(String pStrKey, String pStrData) {
			string strResult;		//Return Result

			//1. String Length cannot exceed 90Kb. Otherwise, buffer will overflow. See point 3 for reasons
			if ( pStrData.Length > 92160 ) {
				strResult="Error. Data String too large. Keep within 90Kb.";
				return strResult;
			}

			//2. Generate the Keys
			if ( !InitKey(pStrKey) ) {
				strResult="Error. Fail to generate key for encryption";
				return strResult;
			}

			//3. Prepare the String
			//	The first 5 character of the string is formatted to store the actual length of the data.
			//	This is the simplest way to remember to original length of the data, without resorting to complicated computations.
			//	If anyone figure a good way to 'remember' the original length to facilite the decryption without having to use additional function parameters, pls let me know.
			pStrData = String.Format("{0,5:00000}"+pStrData, pStrData.Length);

			//4. Encrypt the Data
			byte[] rbData = new byte[pStrData.Length];
			ASCIIEncoding aEnc = new ASCIIEncoding();
			aEnc.GetBytes(pStrData, 0, pStrData.Length, rbData, 0);

			DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();

			ICryptoTransform desEncrypt = descsp.CreateEncryptor(Key, Iv);

			//5. Perpare the streams:
			//	mOut is the output stream. 
			//	mStream is the input stream.
			//	cs is the transformation stream.
			MemoryStream mStream = new MemoryStream(rbData);
			CryptoStream cs = new CryptoStream(mStream, desEncrypt, CryptoStreamMode.Read);
			MemoryStream mOut = new MemoryStream();

			//6. Start performing the encryption
			int bytesRead;
			byte[] output = new byte[1024];
			do {
				bytesRead = cs.Read(output, 0, 1024);
				if ( bytesRead != 0 )
					mOut.Write(output, 0, bytesRead);
			} while ( bytesRead > 0 );

			//7. Returns the encrypted result after it is base64 encoded
			//	In this case, the actual result is converted to base64 so that it can be transported over the HTTP protocol without deformation.
			if ( mOut.Length == 0 )
				strResult = "";
			else
				strResult = Convert.ToBase64String(mOut.GetBuffer(), 0, (int)mOut.Length);

			return strResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string DecryptData(String pStrKey, String pStrData) {
			string strResult;

			//1. Generate the Key used for decrypting
			if ( !InitKey(pStrKey) ) {
				strResult="Error. Fail to generate key for decryption";
				return strResult;
			}

			//2. Initialize the service provider
			//int nReturn = 0;
			DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();
			ICryptoTransform desDecrypt = descsp.CreateDecryptor(Key, Iv);

			//3. Prepare the streams:
			//	mOut is the output stream. 
			//	cs is the transformation stream.
			MemoryStream mOut = new MemoryStream();
			CryptoStream cs = new CryptoStream(mOut, desDecrypt, CryptoStreamMode.Write);

			//4. Remember to revert the base64 encoding into a byte array to restore the original encrypted data stream
			byte[] bPlain;// = new byte[strData.Length];
			try {
				bPlain = Convert.FromBase64CharArray(pStrData.ToCharArray(), 0, pStrData.Length);
			}
			catch ( Exception ) {
				strResult = "Error. Input Data is not base64 encoded.";
				return strResult;
			}

			long lRead = 0;
			long lTotal = pStrData.Length;

			try {
				//5. Perform the actual decryption
				while ( lTotal >= lRead ) {
					cs.Write(bPlain, 0, /*(int)*/bPlain.Length);
					//descsp.BlockSize=64
					lRead = mOut.Length + Convert.ToUInt32(((bPlain.Length / descsp.BlockSize) * descsp.BlockSize));
				}

				ASCIIEncoding aEnc = new ASCIIEncoding();
				strResult = aEnc.GetString(mOut.GetBuffer(), 0, (int)mOut.Length);

				//6. Trim the string to return only the meaningful data
				//	Remember that in the encrypt function, the first 5 character holds the length of the actual data
				//	This is the simplest way to remember to original length of the data, without resorting to complicated computations.
				String strLen = strResult.Substring(0, 5);
				int nLen = Convert.ToInt32(strLen);
				strResult = strResult.Substring(5, nLen);
				//nReturn = (int)mOut.Length;

				return strResult;
			}
			catch ( Exception ) {
				strResult = "Error. Decryption Failed. Possibly due to incorrect Key or corrputed data";
				return strResult;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		//Private function to generate the keys into member variables
		private static bool InitKey(String pStrKey) {
			try {
				// Convert Key to byte array
				byte[] bp = new byte[pStrKey.Length];
				ASCIIEncoding aEnc = new ASCIIEncoding();
				aEnc.GetBytes(pStrKey, 0, pStrKey.Length, bp, 0);

				//Hash the key using SHA1
				SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
				byte[] bpHash = sha.ComputeHash(bp);

				int i;
				// use the low 64-bits for the key value
				for ( i=0 ; i<8 ; i++ )
					Key[i] = bpHash[i];

				for ( i=8 ; i<16 ; i++ )
					Iv[i-8] = bpHash[i];

				return true;
			}
			catch ( Exception ) {
				//Error Performing Operations
				return false;
			}
		}

	}

}