using System;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Infrastructure;
using NUnit.Framework;
using Weaver;

namespace Fabric.Test {

	/*================================================================================================*/
	[TestFixture]
	public class DataTests {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void SetupAddIndexes() {
			List<WeaverQuery> queries = Setup.SetupAddNodeIndexes();

			foreach ( WeaverQuery q in queries ) {
				string json = FabricUtil.WeaverQueryToJson(q);
				Console.WriteLine(json);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void SetupAll(bool pIsForTesting) {
			DataSet ds = Setup.SetupAll(pIsForTesting);
			long nodeI = 0;

			foreach ( WeaverQuery q in ds.Indexes ) {
				string json = FabricUtil.WeaverQueryToJson(q);
				Console.WriteLine(json);
			}

			foreach ( IDataNode n in ds.Nodes ) {
				string json = FabricUtil.WeaverQueryToJson(n.AddQuery);
				Console.WriteLine(json);

				n.Node.Id = nodeI++;
			}

			foreach ( IDataNodeIndex ni in ds.NodeToIndexes ) {
				string json = FabricUtil.WeaverQueryToJson(ni.AddToIndexQuery);
				Console.WriteLine(json);
			}
		}

	}

}