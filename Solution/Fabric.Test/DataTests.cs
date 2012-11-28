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
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void SetupAll(bool pIsForTesting) {
			DataSet ds = Setup.SetupAll(pIsForTesting);
			long nodeI = 0;

			foreach ( WeaverQuery q in ds.Indexes ) {
				string json = FabricUtil.WeaverQueryToJson(q);
				Log.Debug(json);
			}

			foreach ( IDataNode n in ds.Nodes ) {
				string json = FabricUtil.WeaverQueryToJson(n.AddQuery);
				Log.Debug(json);

				n.Node.Id = nodeI++;
			}

			foreach ( IDataNodeIndex ni in ds.NodeToIndexes ) {
				string json = FabricUtil.WeaverQueryToJson(ni.AddToIndexQuery);
				Log.Debug(json);
			}

			foreach ( IDataRel r in ds.Rels ) {
				string json = FabricUtil.WeaverQueryToJson(r.AddQuery);
				Log.Debug(json);
			}
		}

	}

}