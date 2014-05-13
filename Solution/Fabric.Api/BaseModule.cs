using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using Fabric.Api.Interfaces;
using Fabric.Api.Objects;
using Fabric.Api.Objects.Meta;
using Fabric.Infrastructure.Broadcast;
using Fabric.Infrastructure.Cache;
using Fabric.Infrastructure.Data;
using Fabric.Operations;
using Nancy;
using Nancy.Cookies;
using Nancy.Responses;
using Nancy.Serializers.Json.ServiceStack;
using ServiceStack.Text;
using HttpStatusCode = Nancy.HttpStatusCode;

namespace Fabric.Api {

	/*================================================================================================*/
	public abstract class BaseModule : NancyModule {

		private static readonly Logger Log = Logger.Build<BaseModule>();

		private readonly IList<ApiEntry> vApiEntries;
		private readonly IDictionary<ApiEntry.Method, RouteBuilder> vMethodMap;

		private static string ConfPrefix;
		public static FabMetaVersion Version;
		private static MetricsManager Metrics;
		private static CacheManager Cache;
		private static Func<Guid, IAnalyticsManager> AnalyticsProv;
		private static IDataAccessFactory AccessFactory;

		public static string ApiUrl;
		public static int RexConnPort;
		public static int NodeCount;
		public static string[] NodeIpList;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected BaseModule() {
			OnError.AddItemToStartOfPipeline(HandleError);

			vApiEntries = new List<ApiEntry>();

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

		/*--------------------------------------------------------------------------------------------*/
		public IList<ApiEntry> GetApiEntries() {
			return vApiEntries;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void SetupFromApiEntries(IEnumerable<ApiEntry> pEntries) {
			foreach ( ApiEntry e in pEntries ) {
				ApiEntry ee = e;
				vApiEntries.Add(ee);
				vMethodMap[e.RequestMethod][e.Path] = (p => GetResponse(ee));
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response GetResponse(ApiEntry pEntry) {
			IApiResponse apiResp = pEntry.Function(NewReq());
			HttpStatusCode status = (HttpStatusCode)(int)apiResp.Status;
			var cookies = new List<INancyCookie>();

			foreach ( Cookie c in apiResp.Cookies ) {
				var nc = new NancyCookie(c.Name, c.Value, c.HttpOnly, c.Secure);
				nc.Domain = c.Domain;
				nc.Expires = c.Expires;
				nc.Path = c.Path;
				cookies.Add(nc);
			}

			////

			if ( apiResp.RedirectUrl != null ) {
				var r = new RedirectResponse(apiResp.RedirectUrl);

				foreach ( INancyCookie c in cookies ) {
					r.Cookies.Add(c);
				}

				return r;
			}

			if ( apiResp.Html != null ) {
				byte[] bytes = Encoding.UTF8.GetBytes(apiResp.Html);
				return new HtmlResponse(status, (s => s.Write(bytes, 0, bytes.Length)),
					apiResp.Headers, cookies);
			}

			var tr = new TextResponse(status, apiResp.Json, Encoding.UTF8, apiResp.Headers, cookies);
			tr.ContentType = "application/json";
			return tr;
		}

		/*--------------------------------------------------------------------------------------------*/
		private IApiRequest NewReq() {
			var oc = new OperationContext(AccessFactory, Cache, Metrics, AnalyticsProv);
			return new ApiRequest(oc, Context.Request);
		}

		/*--------------------------------------------------------------------------------------------*/
		private Response HandleError(NancyContext pContext, Exception pException) {
			Log.Fatal("Error at "+pContext.Request.Path, pException);

			var fr = new FabResponse<FabObject>();
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
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void BuildObjects() {
			Version = new FabMetaVersion();
			Version.SetBuild(0, 3, 0, "2dcdf4b");
			Version.SetDate(2014, 5, 12);

			Log.Debug("Fabric Version: "+Version.Version+
				" ("+Version.Year+'.'+Version.Month+'.'+Version.Day+")");

			string graphite = ConfigurationManager.AppSettings[ConfPrefix+"Graphite"];
			string prefix = ConfigurationManager.AppSettings[ConfPrefix+"GraphitePrefix"];
			Metrics = new MetricsManager(graphite, 2003, prefix);

			Cache = new CacheManager(Metrics);
			AnalyticsProv = (g => new AnalyticsManager(g));
			AccessFactory = new DataAccessFactory(NodeIpList, RexConnPort, Cache);

			JsConfig.ExcludeTypeInfo = true;
		}

	}

}