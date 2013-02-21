using Fabric.Api.Dto.Meta;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;

namespace Fabric.Api {

	/*================================================================================================*/
	public abstract class BaseModule : NancyModule {

		protected static FabMetaVersion Version;
		private const string DbServerUrl = "http://localhost:9001/gremlin/";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected BaseModule() {
			Log.ConfigureOnce();

			if ( Version == null ) {
				Version = new FabMetaVersion();
				Version.SetBuild(0, 1, 5, "6057d18325c1");
				Version.SetDate(2013, 2, 19);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected static IApiContext NewApiCtx() {
			return new ApiContext(DbServerUrl);
		}

	}

}