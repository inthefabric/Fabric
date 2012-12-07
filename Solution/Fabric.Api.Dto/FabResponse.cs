using System;
using ServiceStack.Text;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public class FabResponse {

		public string Data { get; set; }
		public string Type { get; set; }
		public int DbMs { get; set; }
		public int TotalMs { get; set; }
		public int Size { get; set; }
		public int Count { get; set; }
		public int RemovedDups { get; set; }
		public long RequestTimestamp { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabResponse() {
			Count = 0;
			RemovedDups = 0;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void StartEvent() {
			RequestTimestamp = DateTime.UtcNow.Ticks;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void DbEvent() {
			DbMs = (int)((DateTime.UtcNow.Ticks-RequestTimestamp)/10000);
		}

		/*--------------------------------------------------------------------------------------------*/
		public string Complete(string pDataJson) {
			Data = "{DATA}";
			Size = pDataJson.Length;
			TotalMs = (int)((DateTime.UtcNow.Ticks-RequestTimestamp)/10000);
			
			string json = this.ToJson().Replace("\"{DATA}\"", pDataJson);
			Data = pDataJson;
			return json;
		}
		
			

	}

}