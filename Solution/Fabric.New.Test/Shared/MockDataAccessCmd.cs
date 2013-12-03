using System.Collections.Generic;
using Weaver.Core.Query;

namespace Fabric.New.Test.Shared {

	/*================================================================================================*/
	public class MockDataAccessCmd {

		public string CommandId { get; set; }
		public string ConditionCmdId { get; set; }
		public string SessionAction { get; set; }
		public string Script { get; set; }
		public IDictionary<string, IWeaverQueryVal> Params { get; set; }
		public bool Cache { get; set; }
		public bool OmitResults { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override string ToString() {
			string s = "{";

			if ( CommandId != null ) {
				s += "\n\tCommandId: "+CommandId;
			}

			if ( ConditionCmdId != null ) {
				s += "\n\tConditionCmdId: "+ConditionCmdId;
			}

			if ( SessionAction != null ) {
				s += "\n\tSessionAction: "+SessionAction;
			}

			if ( Script != null ) {
				s += "\n\tScript: "+Script;
			}

			if ( Params != null ) {
				s += "\n\tParams: {";

				foreach ( KeyValuePair<string, IWeaverQueryVal> pair in Params ) {
					s += "\n\t\t"+pair.Key+" = "+pair.Value.FixedText;
				}

				s += "\n\t}";
			}

			if ( Cache ) {
				s += "\n\tCache: true";
			}

			if ( OmitResults ) {
				s += "\n\tOmitResults: true";
			}

			return s+"\n}";
		}

	}

}