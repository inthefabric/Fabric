//#define MONO_DEV

using System;
using System.Configuration;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Meta;
using Fabric.Api.Util;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Caching;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api {

	/*================================================================================================*/
	public abstract class BaseModule : NancyModule {

		private static string ConfPrefix;
		protected static FabMetaVersion Version;
		private static CacheManager Cache;

		public static string ApiUrl;
		public static int RexConnPort;
		public static int NodeCount;
		public static string[] NodeIpList;
		public static int NodeIndex;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected BaseModule() {
			Log.ConfigureOnce();
			OnError.AddItemToStartOfPipeline(HandleError);

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
				RexConnPort = 8185;
				NodeCount = 1;
				NodeIpList = new string[1] { "rexster" };
#else
				ApiUrl = "http://"+ConfigurationManager.AppSettings[ConfPrefix+"Api"];
				RexConnPort = int.Parse(ConfigurationManager.AppSettings[ConfPrefix+"RexConnPort"]);
				NodeCount = int.Parse(ConfigurationManager.AppSettings[ConfPrefix+"NodeCount"]);
				NodeIpList = new string[NodeCount];

				for ( int i = 0 ; i < NodeCount ; ++i ) {
					NodeIpList[i] = ConfigurationManager.AppSettings[ConfPrefix+"NodeIp"+(i+1)];
				}
#endif

				NodeIndex = 0;
			}
			
			if ( Version == null ) {
				Version = new FabMetaVersion();
				Version.SetBuild(0, 1, 22, "29fc060ce66b");
				Version.SetDate(2013, 4, 6);
				Log.Debug("Fabric Version: "+Version.Version);

				Cache = new CacheManager();
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected static IApiContext NewApiCtx() {
			int i = (NodeIndex++)%NodeCount;
			return new ApiContext(NodeIpList[i], RexConnPort, Cache);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private Response HandleError(NancyContext pContext, Exception pException) {
			Log.Fatal("Error at "+pContext.Request.Path, pException);
			var err = FabError.ForInternalServerError();
			return NancyUtil.BuildJsonResponse(HttpStatusCode.InternalServerError, err.ToJson());
		}

	}

}