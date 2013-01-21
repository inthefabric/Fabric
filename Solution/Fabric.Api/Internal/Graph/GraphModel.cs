namespace Fabric.Api.Internal.Graph {

	/*================================================================================================*/
	public class GraphModel {

		public string Query { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GraphModel(string pQuery) {
			if ( pQuery != null ) {
				Query = pQuery.Replace("'", "\\'").Replace("\"", "\\\"");//.Replace("%3D", "=");
			}
		}

	}

}