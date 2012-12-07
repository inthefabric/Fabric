using Fabric.Api.Server.Api;
using Fabric.Api.Server.Graph;
using Fabric.Api.Server.Gremlin;
using Fabric.Api.Server.Setups;
using Fabric.Api.Server.Tables;
using Fabric.Infrastructure;
using Nancy;

namespace Fabric.Api.Server {

	/*================================================================================================*/
	public class ApiModule : NancyModule {

		//private readonly Guid vRequestId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiModule() {
			Log.ConfigureOnce();

			//vRequestId = Guid.NewGuid();
			//Log.Info(vRequestId, "REQUEST", "ApiModule Request");

			Get["/"] = (p => "api | gremlin | graph | tables/browse | setup ");
			Get["/setup"] = (p => new SetupRoutine(Context).GetResponse());
			Get["/graph/json"] = (p => new GraphJson(Context).GetResponse());
			Get["/graph"] = (p => new GraphView(this).GetResponse());
			Get["/tables/browse/(.*)"] = (p => new TableBrowser(this).GetResponse());
			Get["/gremlin/(.*)"] = (p => new GremlinQuery(Context).GetResponse());
			Get["/api/(.*)"] = (p => new ApiQuery(Context).GetResponse());
		}

	}

}