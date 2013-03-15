#define MONO_DEV

using System.Web.Configuration;
using Fabric.Api.Dto.Meta;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;
using System.Configuration;

namespace Fabric.Api {

	/*================================================================================================*/
	public abstract class BaseModule : NancyModule {

		protected static FabMetaVersion Version;
		private static string ConfPrefix;

		public static string ApiUrl;
		public static int RexNodes;
		public static string[] RexUrls;
		public static string[] GremlinUrls;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected BaseModule() {
			Log.ConfigureOnce();

			if ( ConfPrefix == null ) {
#if !DEBUG
				ConfPrefix = "Prod_";
#elif LIVE
				ConfPrefix = "DevLive_";
#else
				ConfPrefix = "Dev_";
#endif

#if MONO_DEV
				ApiUrl = "http://localhost:9000";
				RexNodes = 1;
				RexUrls = new string[1] { "rexster:8182" };
				GremlinUrls = new string[1] { "http://"+RexUrls[0]+"/graphs/Fabric/tp/gremlin" };
#else
				ApiUrl = "http://"+ConfigurationManager.AppSettings[ConfPrefix+"Api"];
				RexNodes = int.Parse(ConfigurationManager.AppSettings[ConfPrefix+"RexNodes"]);
				RexUrls = new string[RexNodes];
				GremlinUrls = new string[RexNodes];

				for ( int i = 0 ; i < RexNodes ; ++i ) {
					RexUrls[i] = WebConfigurationManager.AppSettings[ConfPrefix+"Rex"+(i+1)];
					GremlinUrls[i] = "http://"+RexUrls[i]+"/graphs/Fabric/tp/gremlin";
				}
#endif
			}
			
			if ( Version == null ) {
				Version = new FabMetaVersion();
				Version.SetBuild(0, 1, 11, "71e6dbb39e75");
				Version.SetDate(2013, 3, 8);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected static IApiContext NewApiCtx() {
			return new ApiContext(GremlinUrls[0]);
		}

	}

}