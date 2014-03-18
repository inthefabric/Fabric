using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Util;
using Fabric.New.Operations;
using ServiceStack.Text;

namespace Fabric.New.Api.Interfaces {

	/*================================================================================================*/
	public class ApiResponse : IApiResponse {

		private static readonly Logger Log = Logger.Build<ApiResponse>();

		public HttpStatusCode Status { get; set; }
		public string Html { get; set; }
		public string Json { get; set; }
		public string RedirectUrl { get; set; }
		public IDictionary<string, string> Headers { get; private set; }
		public IList<Cookie> Cookies { get; private set; }
		public bool IsError { get; set; }
		public Exception Unhandled { get; set; }

		private readonly Stopwatch vTimer;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiResponse() {
			Status = HttpStatusCode.OK;
			Headers = new Dictionary<string, string>();
			Cookies = new List<Cookie>();
			vTimer = new Stopwatch();
		}

		/*--------------------------------------------------------------------------------------------*/
		public void StartTimer() {
			vTimer.Start();
		}

		/*--------------------------------------------------------------------------------------------*/
		public void StopTimer() {
			vTimer.Stop();
		}

		/*--------------------------------------------------------------------------------------------*/
		public double GetTimerMilliseconds() {
			return vTimer.Elapsed.TotalMilliseconds;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void SetJsonWith(object pObject) {
			Json = (pObject == null ? "" : pObject.ToJson());
			//JsonSerializer.SerializeToString(pObject);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void SetUserCookie(long? pUserId, bool pRememberMe) {
			Tuple<Cookie, TimeSpan> pair = AuthUtil.CreateUserIdCookie(pUserId, pRememberMe);
			Cookie c = pair.Item1;
			c.Expires = DateTime.UtcNow.Add(pair.Item2);
			Cookies.Add(c);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void LogResponse(IApiRequest pApiReq) {
			IOperationContext oc = pApiReq.OpCtx;
			long totalMs = (long)GetTimerMilliseconds();
			long jsonLen = (Json == null ? 0 : Json.Length);
			
			oc.Analytics.TrackRequest(pApiReq.Method, pApiReq.Path);

			////

			IMetricsManager m = oc.Metrics;
			string key = BuildGraphiteKey(pApiReq);

			m.Counter(key, 1);
			m.Counter(key+".requests", 1);
			m.Counter(key+".errors", (IsError ? 1 : 0));
			m.Timer(key+".total-ms", totalMs);
			m.Mean(key+".json-len", jsonLen);

			if ( oc.Data.DbQueryExecutionCount > 0 ) {
				m.Timer(key+".db", oc.Data.DbQueryMillis);
				m.Mean(key+".db.queries", oc.Data.DbQueryExecutionCount);
			}

			//ARv1: (ApiResponse log, version 1)
			// IP, QueryCount, TotalMs, JsonLen, Timestamp, HttpStatus, IsError, Method, Path, Exception

			const string name = "ARv1";
			const string x = " | ";
			string ctxId = Logger.GuidToString(oc.ContextId);

			string v1 =
				pApiReq.IpAddress +x+
				oc.Data.DbQueryExecutionCount +x+
				totalMs +x+
				jsonLen +x+
				DateTime.UtcNow.Ticks +x+
				(int)Status +x+
				(IsError ? 1 : 0) +x+
				pApiReq.Method +x+
				pApiReq.Path;

			if ( Unhandled == null ) {
				Log.Info(ctxId, name, v1);
			}
			else {
				Log.Error(ctxId, name, v1, Unhandled);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string BuildGraphiteKey(IApiRequest pApiReq) {
			string key = pApiReq.Method;
			string path = pApiReq.Path.ToLower().Trim(new[] { '/' }).Split('?')[0];
			string[] pathSegs = path.Split('/').Take(3).ToArray();

			for ( int i = 0 ; i < pathSegs.Length ; ++i ) {
				string seg = pathSegs[i];
				int endI = seg.IndexOf('('); //TODO: further sterilize path string?

				if ( endI != -1 ) {
					seg = seg.Substring(0, endI);
				}

				key += "-"+seg;
			}

			return "req."+key;
		}

	}

}