using Fabric.New.Database.Init.Setups;

namespace Fabric.New.Database.Init {

	/*================================================================================================*/
	public static class Setup {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static DataSet SetupAll(bool pIsForTesting) {
			var ds = new DataSet(pIsForTesting);
			ds.ClearPreviousData();

			new SetupIndexes(ds).Create();
			new SetupUsers(ds).Create();
			new SetupOauth(ds).Create();
			new SetupObjects(ds).Create();
			new SetupFactors(ds).Create();

			if ( pIsForTesting ) {
				int testId = 0;

				foreach ( IDataVertex n in ds.Vertices ) {
					n.TestVal = ++testId;
				}

				foreach ( IDataEdge edge in ds.Edges ) {
					edge.TestVal = ds.GetDataVertex(edge.OutVertex).TestVal+"|"+
						edge.Edge.Label+"|"+ds.GetDataVertex(edge.InVertex).TestVal;
				}
			}

			return ds;
		}

	}

}