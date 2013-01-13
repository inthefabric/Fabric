﻿using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Infrastructure;
using NUnit.Framework;
using Weaver;

namespace Fabric.Test.FabDbData {

	/*================================================================================================*/
	[TestFixture]
	public class TSetup {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		[TestCase(true)]
		[TestCase(false)]
		public void SetupAll(bool pIsForTesting) {
			DataSet ds = Setup.SetupAll(pIsForTesting);
			long nodeI = 1000;

			foreach ( WeaverQuery q in ds.Initialization ) {
				string json = FabricUtil.WeaverQueryToJson(q);
				Log.Debug(json);
			}

			foreach ( WeaverQuery q in ds.Indexes ) {
				string json = FabricUtil.WeaverQueryToJson(q);
				Log.Debug(json);
			}

			foreach ( IDataNode n in ds.Nodes ) {
				string json = FabricUtil.WeaverQueryToJson(n.AddQuery);
				Log.Debug("["+nodeI+"] -- "+json);
				n.Node.Id = nodeI++;
			}

			foreach ( IDataRel r in ds.Rels ) {
				string json = FabricUtil.WeaverQueryToJson(r.AddQuery);
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
			
			foreach ( IDataNodeIndex ni in ds.NodeToIndexes ) {
				tx.AddQuery(ni.AddToIndexQuery);
			}
			
			foreach ( IDataRel r in ds.Rels ) {
				tx.AddQuery(r.AddQuery);
			}

			tx.Finish(WeaverTransaction.ConclusionType.Success);
			//Log.Debug(FabricUtil.WeaverTransactionToJson(tx).Replace(";", ";\n\t\t"));
		}*/

	}

}