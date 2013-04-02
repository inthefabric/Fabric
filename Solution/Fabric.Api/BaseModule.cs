//#define MONO_DEV

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Runtime.Caching;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Meta;
using Fabric.Api.Util;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Cache;
using Fabric.Infrastructure.Caching;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api {

	/*================================================================================================*/
	public abstract class BaseModule : NancyModule {

		protected static FabMetaVersion Version;
		private static string ConfPrefix;
		private static MemoryCache MemCache;
		private static ClassNameCache ClassNameCache;

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
				Version.SetBuild(0, 1, 21, "0680465c8c5f");
				Version.SetDate(2013, 3, 29);
			}

			if ( MemCache == null ) {
				var cacheConfig = new NameValueCollection();
				//cacheConfig.Add("PhysicalMemoryLimitPercentage", "10");

				MemCache = new MemoryCache("FabricApi", cacheConfig);
				var testCache = new TestCache();

				var acList = new List<IApiContext>();

				for ( int i = 0 ; i < NodeCount ; ++i ) {
					acList.Add(NewApiCtx());
				}

				Log.Debug("VERSION "+Version.Version);
				ClassNameCache = new ClassNameCache(acList, 5, 3);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected static IApiContext NewApiCtx() {
			int i = (NodeIndex++)%NodeCount;
			return new ApiContext(NodeIpList[i], RexConnPort, MemCache, ClassNameCache);
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