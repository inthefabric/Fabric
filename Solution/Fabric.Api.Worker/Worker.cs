using System;

namespace Fabric.Api.Worker {

	/*================================================================================================*/
	public class Worker {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void Main(string[] pArgs) {
			int n = pArgs.Length;

			string method = pArgs[0];
			string path = pArgs[1];
			string query = (n > 2 ? pArgs[2] : null);
			string formData = (n > 3 ? pArgs[3] : null);

			Console.Write("status=200&error=0&other=something\n");
			Console.Write(
				"{"+
					"\"name\":\"hello\","+
					"\"data\":\"this is some text\","+
					"\"method\":\""+method+"\","+
					"\"path\":\""+path+"\","+
					"\"query\":\""+query+"\","+
					"\"formData\":\""+formData+"\""+
				"}");
		}

	}

}