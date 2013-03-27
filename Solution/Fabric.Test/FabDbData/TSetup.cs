using System.Collections.Generic;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Infrastructure;
using NUnit.Framework;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Test.FabDbData {

	/*================================================================================================*/
	//[TestFixture]
	public class TSetup {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		[TestCase(true)]
		[TestCase(false)]
		public void SetupAll(bool pIsForTesting) {
			DataSet ds = Setup.SetupAll(pIsForTesting);
			long nodeI = 1000;

			foreach ( WeaverQuery q in ds.Initialization ) {
				string json = WeaverQueryToJson(q);
				Log.Debug(json);
			}

			foreach ( WeaverQuery q in ds.Indexes ) {
				string json = WeaverQueryToJson(q);
				Log.Debug(json);
			}

			foreach ( IDataNode n in ds.Nodes ) {
				string json = WeaverQueryToJson(n.AddQuery);
				Log.Debug("["+nodeI+"] -- "+json);
				n.Node.Id = nodeI++;
			}

			foreach ( IDataRel r in ds.Rels ) {
				string json = WeaverQueryToJson(r.AddQuery);
				Log.Debug(json);
			}
		}

		/*--------------------------------------------------------------------------------------------* /
		[TestCase(true)]
		[TestCase(false)]
		public void SetupAllTransaction(bool pIsForTesting) {
			var tx = new WeaverTransaction();
			DataSet ds = Setup.SetupAll(pIsForTesting);
			long nodeI = 0;
			
			foreach ( WeaverQuery q in ds.Indexes ) {
				tx.AddQuery(q);
			}
			
			foreach ( IDataNode n in ds.Nodes ) {
				tx.AddQuery(n.AddQuery);
				n.Node.Id = nodeI++;
			}
			
			foreach ( IDataRel r in ds.Rels ) {
				tx.AddQuery(r.AddQuery);
			}

			tx.Finish();
			//Log.Debug(FabricUtil.WeaverTransactionToJson(tx).Replace(";", ";\n\t\t"));
		}

		/*--------------------------------------------------------------------------------------------* /
		private static string WeaverQueryToJson(IWeaverQuery pQuery) {
			return ScriptAndParamsToJson(pQuery.Script, pQuery.Params);
		}

		/*--------------------------------------------------------------------------------------------* /
		public static string ScriptAndParamsToJson(string pScript, 
														Dictionary<string, IWeaverQueryVal> pParams) {
			string json = "{\"script\":\""+FabricUtil.JsonUnquote(pScript)+"\",\"params\":{";
			bool first = true;

			foreach ( string key in pParams.Keys ) {
				json += (first ? "" : ",")+"\""+FabricUtil.JsonUnquote(key)+"\":\""+
					FabricUtil.JsonUnquote(pParams[key])+"\"";
				first = false;
			}

			return json+"}}";
		}*/

	}

}