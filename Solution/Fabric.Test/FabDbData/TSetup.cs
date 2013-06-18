using System.Collections.Generic;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Weaver;
using NUnit.Framework;
using Weaver;
using Weaver.Core.Query;

namespace Fabric.Test.FabDbData {

	/*================================================================================================*/
	[TestFixture]
	public class TSetup {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void SetupAll(bool pIsForTesting) {
			var x = Weave.Inst;

			DataSet ds = Setup.SetupAll(pIsForTesting);
			long vertexI = 1000;

			foreach ( WeaverQuery q in ds.Initialization ) {
				string json = WeaverQueryToJson(q);
				Log.Debug(json);
			}

			foreach ( WeaverQuery q in ds.Indexes ) {
				string json = WeaverQueryToJson(q);
				Log.Debug(json);
			}

			foreach ( IDataVertex n in ds.Vertices ) {
				string json = WeaverQueryToJson(n.AddQuery);
				Log.Debug("["+vertexI+"] -- "+json);
				n.Vertex.Id = (vertexI++)+"";
			}

			foreach ( IDataEdge r in ds.Edges ) {
				string json = WeaverQueryToJson(r.AddQuery);
				Log.Debug(json);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string WeaverQueryToJson(IWeaverQuery pQuery) {
			return ScriptAndParamsToJson(pQuery.Script, pQuery.Params);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string ScriptAndParamsToJson(string pScript, 
														Dictionary<string, IWeaverQueryVal> pParams) {
			string json = "{\"script\":\""+FabricUtil.JsonUnquote(pScript)+"\",\"params\":{";
			bool first = true;

			foreach ( string key in pParams.Keys ) {
				json += (first ? "" : ",")+"\""+FabricUtil.JsonUnquote(key)+"\":\""+
					FabricUtil.JsonUnquote(pParams[key].RawText)+"\"";
				first = false;
			}

			return json+"}}";
		}

	}

}