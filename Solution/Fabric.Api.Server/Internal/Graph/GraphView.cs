using Nancy;
using Nancy.Responses.Negotiation;

namespace Fabric.Api.Server.Internal.Graph {

	/*================================================================================================*/
	public class GraphView {

		private readonly NancyModule vModule;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GraphView(NancyModule pModule) {
			vModule = pModule;
		}

		/*--------------------------------------------------------------------------------------------*/
		public Negotiator GetResponse() {
			var gm = new GraphModel(vModule.Context.Request.Query["q"]);
			return vModule.View["graph/index.html", gm];
		}

	}

}