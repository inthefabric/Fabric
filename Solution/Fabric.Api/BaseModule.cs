using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;

namespace Fabric.Api {

	/*================================================================================================*/
	public abstract class BaseModule : NancyModule {

		protected const string ApiVersion = "1.0.2.0fd8d9a4c28e";
		private const string DbServerUrl = "http://localhost:9001/gremlin";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected BaseModule() {
			Log.ConfigureOnce();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected static IApiContext NewApiCtx() {
			return new ApiContext(DbServerUrl);
		}

	}

}