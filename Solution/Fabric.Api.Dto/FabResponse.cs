using System;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public class FabResponse {

		public string Data { get; set; }
		public string Type { get; set; }
		public string BaseUri { get; set; }
		public string RequestUri { get; set; }
		public string[] AvailableUris { get; set; }
		public int DbMs { get; set; }
		public int TotalMs { get; set; }
		public int DataLen { get; set; }
		public int Count { get; set; }
		public bool HasMore { get; set; }
		public long Timestamp { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabResponse() {
			Count = 0;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void StartEvent() {
			Timestamp = DateTime.UtcNow.Ticks;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void DbEvent() {
			DbMs = (int)((DateTime.UtcNow.Ticks-Timestamp)/10000);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Complete() {
			TotalMs = (int)((DateTime.UtcNow.Ticks-Timestamp)/10000);
		}
		
			

	}

}