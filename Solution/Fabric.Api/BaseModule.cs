﻿//#define MONO_DEV

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Runtime.Caching;
using System.Web.Configuration;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Meta;
using Fabric.Api.Util;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api {

	/*================================================================================================*/
	public abstract class BaseModule : NancyModule {

		protected static FabMetaVersion Version;
		private static string ConfPrefix;
		private static MemoryCache MemCache;
		private static ClassNameCache ClassNameCache;
		private static int GremlinUrlIndex;

		public static string ApiUrl;
		public static int RexNodes;
		public static string[] RexUrls;
		public static string[] GremlinUrls;


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
				RexNodes = 1;
				RexUrls = new string[1] { "rexster:8182" };
				GremlinUrls = new string[1] { "http://"+RexUrls[0]+"/graphs/Fabric/tp/gremlin" };
#else
				ApiUrl = "http://"+ConfigurationManager.AppSettings[ConfPrefix+"Api"];
				RexNodes = int.Parse(ConfigurationManager.AppSettings[ConfPrefix+"RexNodes"]);
				RexUrls = new string[RexNodes];
				GremlinUrls = new string[RexNodes];
				GremlinUrlIndex = 0;

				for ( int i = 0 ; i < RexNodes ; ++i ) {
					RexUrls[i] = WebConfigurationManager.AppSettings[ConfPrefix+"Rex"+(i+1)];
					GremlinUrls[i] = "http://"+RexUrls[i]+"/graphs/Fabric/tp/gremlin";
				}
#endif
			}
			
			if ( Version == null ) {
				Version = new FabMetaVersion();
				Version.SetBuild(0, 1, 16, "ccfc9c4136bd");
				Version.SetDate(2013, 3, 17);
			}

			if ( MemCache == null ) {
				var cacheConfig = new NameValueCollection();
				//cacheConfig.Add("PhysicalMemoryLimitPercentage", "10");

				MemCache = new MemoryCache("FabricApi", cacheConfig);
				ClassNameCache = new ClassNameCache(NewApiCtx(), 3, 2);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected static IApiContext NewApiCtx() {
			int i = (GremlinUrlIndex++)%RexNodes;
			return new ApiContext(GremlinUrls[i], MemCache, ClassNameCache);
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