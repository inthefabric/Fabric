using Fabric.Api.Server.Api;
using Fabric.Api.Server.ApiSpec;
using Fabric.Api.Server.Graph;
using Fabric.Api.Server.Setups;
using Fabric.Api.Server.Tables;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;

namespace Fabric.Api.Server {

	/*================================================================================================*/
	public class ApiModule : NancyModule {

		public const string ApiVersion = "1.0.0.10f7771a29e1";
		public const string DbServerUrl = "http://localhost:9001/gremlin";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiModule() {
			Log.ConfigureOnce();

			Get["/"] = (p => "api | apispec | gremlin | graph | tables/browse | setup ");
			Get["/setup"] = (p => new SetupRoutine(Context).GetResponse());
			Get["/graph/json"] = (p => new GraphJson(Context).GetResponse());
			Get["/graph"] = (p => new GraphView(this).GetResponse());
			Get["/tables/browse/(.*)"] = (p => new TableBrowser(this).GetResponse());
			Get["/api"] = (p => new ApiQuery(Context, NewApiCtx).GetResponse());
			Get["/api/(.*)"] = (p => new ApiQuery(Context, NewApiCtx).GetResponse());

			Get["/apispec"] = (p => new ApiSpecBuilder(Context).GetResponse());
			Get["/apispec/apiresponse"] = (p => new ApiSpecBuilder(Context, "res").GetResponse());
			Get["/apispec/dtolist/{name}"] = (p => new ApiSpecBuilder(Context, "dto").GetResponse());
			Get["/apispec/functionlist/{name}"] = (p => new ApiSpecBuilder(Context, "fun").GetResponse());
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected static IApiContext NewApiCtx {
			get {
				return new ApiContext(DbServerUrl);
			}
		}

	}

}