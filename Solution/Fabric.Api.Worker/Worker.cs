using System;

namespace Fabric.Api.Worker {

	/*================================================================================================*/
	public class Worker {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void Main(string[] pArgs) {
			try {
				int n = pArgs.Length;

				string method = pArgs[0];
				string path = pArgs[1];
				string query = (n > 2 ? pArgs[2] : null);
				string formData = (n > 3 ? pArgs[3] : null);

				var gremReq = new GremlinRequestAsync("g.v(99);");

				Console.Write("status=200&error=0&data=#\n");
				Console.Write(gremReq.ResponseData);
			}
			catch ( Exception ex ) {
				Console.Write("status=500&error=1&data=#\n"+ex.Message);
			}
		}

	}

}