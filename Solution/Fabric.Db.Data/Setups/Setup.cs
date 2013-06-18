namespace Fabric.Db.Data.Setups {

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

				foreach ( IDataRel rel in ds.Rels ) {
					System.Console.WriteLine(rel.OutVertex+" / "+rel.Rel.Label+" / "+rel.InVertex);
					System.Console.WriteLine("OUT: "+ds.GetDataVertex(rel.OutVertex).TestVal);
					System.Console.WriteLine("IN: "+ds.GetDataVertex(rel.InVertex).TestVal);
					rel.TestVal = ds.GetDataVertex(rel.OutVertex).TestVal+"|"+
						rel.Rel.Label+"|"+ds.GetDataVertex(rel.InVertex).TestVal;
				}
			}

			return ds;
		}

	}

}