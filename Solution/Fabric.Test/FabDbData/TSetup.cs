﻿using System.Collections.Generic;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Weaver;
using NUnit.Framework;
using Weaver;
using Weaver.Interfaces;

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
				n.Node.Id = (nodeI++)+"";
			}

			foreach ( IDataRel r in ds.Rels ) {
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