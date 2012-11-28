using System.Collections.Generic;

namespace Fabric.Infrastructure {
	
	/*================================================================================================*/
	public class DbResult {

		public string Self { get; set; }
		public string Start { get; set; }
		public string Type { get; set; }
		public string End { get; set; }

		public Dictionary<string, string> Data { get; set; }

		public string Message { get; set; }
		public string Exception { get; set; }

	}

}