﻿namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public static class Setup {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static DataSet SetupAll(bool pIsForTesting) {
			var ds = new DataSet(pIsForTesting);
			ds.ClearPreviousData();

			SetupIndexes.SetupAll(ds);
			SetupUsers.SetupAll(ds);
			SetupOauth.SetupAll(ds);
			SetupObjects.SetupAll(ds);
			SetupFactors.SetupAll(ds);

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