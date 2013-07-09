using System;
using System.Diagnostics;
using Fabric.Domain;
using Fabric.Infrastructure.Analytics;
using Fabric.Infrastructure.Data;
using RexConnectClient.Core;
using RexConnectClient.Core.Result;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public class ApiContext : IApiContext {

		public string RexConnUrl { get; private set; }
		public int RexConnPort { get; private set; }

		public Guid ContextId { get; private set; }
		public long UserId { get; private set; }
		public long AppId { get; private set; }
		public AnalyticsManager Analytics { get; private set; }
		public ICacheManager Cache { get; private set; }

		public int DbQueryExecutionCount { get; private set; }
		public int DbQueryMillis { get; private set; }

		private readonly Stopwatch vProfiler;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiContext(string pRexConnUrl, int pRexConnPort, ICacheManager pCache) {
			vProfiler = new Stopwatch();
			vProfiler.Start();

			RexConnUrl = pRexConnUrl;
			RexConnPort = pRexConnPort;
			Cache = pCache;

			ContextId = Guid.NewGuid();
			UserId = -1;
			AppId = -1;
			Analytics = new AnalyticsManager(ContextId, x => Log.Debug(ContextId, "ANALYT", x));
			DbQueryExecutionCount = 0;
			DbQueryMillis = 0;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void SetAppUserId(long? pAppId, long? pUserId) {
			if ( AppId != -1 ) { throw new Exception("UserId and AppId are already set."); }
			AppId = (pAppId ?? 0);
			UserId = (pUserId ?? 0);
			//Analytics.SetAppUserId(AppId, UserId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual DateTime UtcNow {
			get { return DateTime.UtcNow; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual string Code32 {
			get { return FabricUtil.Code32; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual long GetSharpflakeId<T>() where T : IVertex {
			return Sharpflake.GetId<T>();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IDataAccess NewData(string pSessionId=null) {
			var da = new DataAccess();
			da.Build(this, pSessionId);
			da.SetExecuteHooks(OnDataPreExecute, OnDataPostExecute);
			return da;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected virtual void OnDataPreExecute(RexConnDataAccess pRexConnData) {
			//int n = pRexConnData.Context.Request.CmdList.Count;
			//Log.Debug(ContextId, "Data", "PreExec commands: "+n);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void OnDataPostExecute(IResponseResult pResult) {
			DbQueryExecutionCount++;
			DbQueryMillis += (int)pResult.Response.Timer;
			//Log.Debug(ContextId, "Data", "PostExec timer: "+pResult.Response.Timer+"ms");
			//Log.Debug(ContextId, "Data", "Request: "+pResult.RequestJson);
			//Log.Debug(ContextId, "Data", "Response: "+pResult.ResponseJson);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void ProfilerTrace(object pObj, string pName) {
			ProfilerTrace(pObj.GetType().Name, pName);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ProfilerTrace(string pObjName, string pName) {
			Log.Debug("---> "+String.Format("{0,7:##0.000}", vProfiler.Elapsed.TotalMilliseconds)+
				"ms ("+pObjName+"."+pName+")");
		}

	}

}