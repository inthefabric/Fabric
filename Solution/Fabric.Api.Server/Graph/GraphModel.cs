using Fabric.Infrastructure;

namespace Fabric.Api.Server.Graph {

	/*================================================================================================*/
	public class GraphModel {

		public string Query { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GraphModel(string pQuery) {
			Query = pQuery.Replace("'", "\\'").Replace("\"", "\\\"");//.Replace("%3D", "=");
		}

	}

}