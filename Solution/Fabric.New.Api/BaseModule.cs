﻿using System;
using System.Collections.Generic;
using System.Configuration;
using Fabric.New.Api.Interfaces;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Meta;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Cache;
using Fabric.New.Operations;
using Nancy;
using Nancy.Responses;
using Nancy.Serializers.Json.ServiceStack;
using ServiceStack.Text;

namespace Fabric.New.Api {

	/*================================================================================================*/
	public abstract class BaseModule : NancyModule {

		private static readonly Logger Log = Logger.Build<BaseModule>();

		private readonly IDictionary<ApiEntry.Method, RouteBuilder> vMethodMap;

		private static string ConfPrefix;
		public static FabMetaVersion Version;
		private static MetricsManager Metrics;
		private static CacheManager Cache;
		private static Func<Guid, IAnalyticsManager> AnalyticsProv;

		public static string ApiUrl;
		public static int RexConnPort;
		public static int NodeCount;
		public static string[] NodeIpList;
		public static int NodeIndex;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected BaseModule() {
			OnError.AddItemToStartOfPipeline(HandleError);

			vMethodMap = new Dictionary<ApiEntry.Method, RouteBuilder>();
			vMethodMap.Add(ApiEntry.Method.Get, Get);
			vMethodMap.Add(ApiEntry.Method.Post, Post);
			vMethodMap.Add(ApiEntry.Method.Put, Put);
			vMethodMap.Add(ApiEntry.Method.Delete, Delete);

			if ( Version != null ) {
				return;
			}

			lock ( this ) {
				GetConfigValues();
				BuildObjects();
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void SetupFromApiEntries(IEnumerable<ApiEntry> pEntries) {
			foreach ( ApiEntry e in pEntries ) {
				ApiEntry ee = e;
				vMethodMap[e.RequestMethod][e.Path] = (p => GetResponse(ee));
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response GetResponse(ApiEntry pEntry) {
			IApiResponse apiResp = pEntry.Function(NewReq());

			var tr = new TextResponse(apiResp.Json, "application/json");
			tr.StatusCode = (HttpStatusCode)(int)apiResp.Status;
			return tr;
		}

		/*--------------------------------------------------------------------------------------------*/
		private IApiRequest NewReq() {
			int i = (NodeIndex++)%NodeCount;
			var oc = new OperationContext(NodeIpList[i], RexConnPort, Cache, Metrics, AnalyticsProv);
			return new ApiRequest(oc, Context.Request);
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response HandleError(NancyContext pContext, Exception pException) {
			Log.Fatal("Error at "+pContext.Request.Path, pException);

			var fr = new FabResponse();
			fr.Error = FabError.ForInternalServerError();

			var jr = new JsonResponse(fr, new ServiceStackJsonSerializer());
			jr.StatusCode = HttpStatusCode.InternalServerError;
			return jr;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void GetConfigValues() {
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
			NodeCount = int.Parse(ConfigurationManager.AppSettings[ConfPrefix+"NodeCount"]);
			NodeIpList = new string[NodeCount];

			for ( int i = 0 ; i < NodeCount ; ++i ) {
				NodeIpList[i] = ConfigurationManager.AppSettings[ConfPrefix+"NodeIp"+(i+1)];
			}
#endif

			NodeIndex = 0;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void BuildObjects() {
			Version = new FabMetaVersion();
			Version.SetBuild(0, 2, 4, "37fd2cd");
			Version.SetDate(2013, 9, 18);

			Log.Debug("Fabric Version: "+Version.Version+
				" ("+Version.Year+'.'+Version.Month+'.'+Version.Day+")");

			string graphite = ConfigurationManager.AppSettings[ConfPrefix+"Graphite"];
			string prefix = ConfigurationManager.AppSettings[ConfPrefix+"GraphitePrefix"];
			Metrics = new MetricsManager(graphite, 2003, prefix);

			Cache = new CacheManager(Metrics);
			AnalyticsProv = (g => new AnalyticsManager(g));

			JsConfig.ExcludeTypeInfo = true;
		}

	}

}