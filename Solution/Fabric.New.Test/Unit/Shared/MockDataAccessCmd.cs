using System;
using System.Collections.Generic;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.New.Test.Unit.Shared {

	/*================================================================================================*/
	public class MockDataAccessCmd : IWeaverScript {

		public string CommandId { get; set; }
		public string ConditionCmdId { get; set; }
		public string SessionAction { get; set; }
		public string Script { get; set; }
		public Dictionary<string, IWeaverQueryVal> Params { get; set; }
		public bool Cache { get; set; }
		public bool OmitResults { get; set; }

		public string TestCommandName { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IDictionary<string, IWeaverQueryVal> BuildParamMap(IEnumerable<object> pList) {
			var map = new Dictionary<string, IWeaverQueryVal>();
			int i = 0;

			foreach ( object o in pList ) {
				map.Add("_P"+(i++), new WeaverQueryVal(o));
			}

			return map;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AssertEqual(MockDataAccessCmd pExpect, int pIndex) {
			Func<string, string> fmt = (x => string.Format(
				"Incorrect {0} at command '"+pExpect.TestCommandName+"' (index "+pIndex+").", x));

			Assert.AreEqual(pExpect.CommandId, CommandId, fmt("CommandId"));
			Assert.AreEqual(pExpect.ConditionCmdId, ConditionCmdId, fmt("ConditionCmdId"));
			Assert.AreEqual(pExpect.SessionAction, SessionAction, fmt("SessionAction"));
			Assert.AreEqual(pExpect.Script, Script, fmt("Script"));

			if ( Params != null && pExpect.Params != null ) {
				Assert.AreEqual(pExpect.Params.Count, Params.Keys.Count, fmt("Param count"));

				foreach ( KeyValuePair<string, IWeaverQueryVal> pair in pExpect.Params ) {
					Assert.True(Params.ContainsKey(pair.Key),
						fmt("Param (missing key '"+pair.Key+"')"));
					Assert.AreEqual(pair.Value.Original, Params[pair.Key].Original,
						fmt("Param (value for '"+pair.Key+"')"));
				}
			}
			else {
				Assert.AreEqual(pExpect.Params, Params, fmt("Params"));
			}

			Assert.AreEqual(pExpect.Cache, Cache, fmt("Cache"));
			Assert.AreEqual(pExpect.OmitResults, OmitResults, fmt("OmitResults"));
		}

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