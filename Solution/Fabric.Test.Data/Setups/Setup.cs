namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public static class Setup {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static DataSet SetupAll(bool pIsForTesting) {
			var ds = new DataSet(pIsForTesting);
			ds.ClearPreviousData();

			SetupIndexes.SetupAll(ds);
			SetupTypes.SetupAll(ds);
			SetupUsers.SetupAll(ds);
			SetupOauth.SetupAll(ds);
			SetupObjects.SetupAll(ds);
			SetupFactors.SetupAll(ds);

			if ( pIsForTesting ) {
				int testId = 0;

				foreach ( IDataNode n in ds.Nodes ) {
					n.TestVal = ++testId;
				}

				foreach ( IDataRel rel in ds.Rels ) {
					rel.TestVal = ds.GetDataNode(rel.FromNode).TestVal+"|"+
						rel.Rel.Label+"|"+ds.GetDataNode(rel.ToNode).TestVal;
				}
			}

			return ds;
		}

	}

}