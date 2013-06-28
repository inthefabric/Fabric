using System.Collections.Generic;
using Weaver.Core.Query;

namespace Fabric.Test.Common {

	/*================================================================================================*/
	public class MockDataAccessCmd {
		
		public string Script { get; set; }
		public IDictionary<string, string> StringParams { get; set; }
		public IDictionary<string, IWeaverQueryVal> Params { get; set; }

	}

}