using Fabric.Api.Server.Api;
using Fabric.Api.Server.ApiSpec;
using Fabric.Api.Server.Graph;
using Fabric.Api.Server.Gremlin;
using Fabric.Api.Server.Setups;
using Fabric.Api.Server.Tables;
using Fabric.Infrastructure;
using Nancy;

namespace Fabric.Api.Server {

	/*================================================================================================*/
	public class ApiModule : NancyModule {

		public const string ApiVersion = "1.0.0.10f7771a29e1";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiModule() {
			Log.ConfigureOnce();

			Get["/"] = (p => "api | apispec | gremlin | graph | tables/browse | setup ");
			Get["/setup"] = (p => new SetupRoutine(Context).GetResponse());
			Get["/graph/json"] = (p => new GraphJson(Context).GetResponse());
			Get["/graph"] = (p => new GraphView(this).GetResponse());
			Get["/tables/browse/(.*)"] = (p => new TableBrowser(this).GetResponse());
			Get["/gremlin/(.*)"] = (p => new GremlinQuery(Context).GetResponse());
			Get["/api"] = (p => new ApiQuery(Context).GetResponse());
			Get["/api/(.*)"] = (p => new ApiQuery(Context).GetResponse());

			Get["/apispec"] = (p => new ApiSpecBuilder(Context).GetResponse());
			Get["/apispec/apiresponse"] = (p => new ApiSpecBuilder(Context, "res").GetResponse());
			Get["/apispec/dtolist/{name}"] = (p => new ApiSpecBuilder(Context, "dto").GetResponse());
			Get["/apispec/functionlist/{name}"] = (p => new ApiSpecBuilder(Context, "fun").GetResponse());
		}

	}

}