using System.Collections.Generic;
using Weaver.Core.Query;

namespace Fabric.New.Test.Shared {

	/*================================================================================================*/
	public class MockDataAccessCmd {
		
		public string Script { get; set; }
		public IDictionary<string, string> StringParams { get; set; }
		public IDictionary<string, IWeaverQueryVal> Params { get; set; }
		public bool Cache { get; set; }

	}

}