//#define MONO_DEV

using System;
using System.Configuration;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Meta;
using Fabric.Api.Util;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Analytics;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Caching;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api {

	/*================================================================================================*/
	public abstract class BaseModule : NancyModule {

		private static string ConfPrefix;
		protected static FabMetaVersion Version;
		private static MetricsManager Metrics;
		private static CacheManager Cache;
		private static Func<Guid, IAnalyticsManager> AnalyticsProv;

		public static string ApiUrl;
		public static int RexConnPort;
		public static int VertexCount;
		public static string[] VertexIpList;
		public static int VertexIndex;


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
				VertexCount = 1;
				VertexIpList = new string[1] { "rexster" };
#else
				ApiUrl = "http://"+ConfigurationManager.AppSettings[ConfPrefix+"Api"];
				RexConnPort = int.Parse(ConfigurationManager.AppSettings[ConfPrefix+"RexConnPort"]);
				VertexCount = int.Parse(ConfigurationManager.AppSettings[ConfPrefix+"VertexCount"]);
				VertexIpList = new string[VertexCount];

				for ( int i = 0 ; i < VertexCount ; ++i ) {
					VertexIpList[i] = ConfigurationManager.AppSettings[ConfPrefix+"VertexIp"+(i+1)];
				}
#endif

				VertexIndex = 0;
			}
			
			if ( Version == null ) {
				Version = new FabMetaVersion();
				Version.SetBuild(0, 2, 1, "d4b16b1");
				Version.SetDate(2013, 8, 22);

				Log.Debug("Fabric Version: "+Version.Version+
					" ("+Version.Year+'.'+Version.Month+'.'+Version.Day+")");

				string graphite = ConfigurationManager.AppSettings[ConfPrefix+"Graphite"];
				string prefix = ConfigurationManager.AppSettings[ConfPrefix+"GraphitePrefix"];
				Metrics = new MetricsManager(graphite, 2003, prefix);

				Cache = new CacheManager(Metrics);
				AnalyticsProv = (g => new AnalyticsManager(g));
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected static IApiContext NewApiCtx() {
			int i = (VertexIndex++)%VertexCount;
			return new ApiContext(VertexIpList[i], RexConnPort, Cache, Metrics, AnalyticsProv);
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