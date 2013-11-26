﻿using System;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Cache;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Query;
using Fabric.New.Infrastructure.Util;
using RexConnectClient.Core;
using RexConnectClient.Core.Result;

namespace Fabric.New.Operations {

	/*================================================================================================*/
	public class OperationContext : IOperationContext {

		private static readonly Logger Log = Logger.Build<OperationContext>();

		public Guid ContextId { get; private set; }
		public IOperationAccess Access { get; private set; }
		public IAnalyticsManager Analytics { get; private set; }
		public IMetricsManager Metrics { get; private set; }
		public ICacheManager Cache { get; private set; }

		public int DbQueryExecutionCount { get; private set; }
		public int DbQueryMillis { get; private set; }

		private readonly IDataAccessFactory vAccessFactory;
		//private readonly Stopwatch vProfiler;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OperationContext(IDataAccessFactory pAccessFactory, ICacheManager pCache,
						IMetricsManager pMetrics, Func<Guid, IAnalyticsManager> pAnalyticsProvider) {
			vAccessFactory = pAccessFactory;
			Metrics = pMetrics;
			Cache = pCache;

			ContextId = Guid.NewGuid();
			Access = new OperationAccess(() => NewData(), () => UtcNow.Ticks);
			Analytics = pAnalyticsProvider(ContextId);
			DbQueryExecutionCount = 0;
			DbQueryMillis = 0;

			//vProfiler = new Stopwatch();
			//vProfiler.Start();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual DateTime UtcNow {
			get { return DateTime.UtcNow; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual string Code32 {
			get { return DataUtil.Code32; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual long GetSharpflakeId<T>() where T : IVertex {
			return Sharpflake.GetId<T>();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IDataAccess NewData(string pSessionId=null, bool pSetCmdIds=false,
																			bool pOmitCmdTimers=true) {
			IDataAccess da = vAccessFactory.Create(pSessionId, pSetCmdIds, pOmitCmdTimers);
			da.SetExecuteHooks(OnDataPreExecute, OnDataPostExecute, OnDataPostExecuteError);
			da.SetLoggingHook(OnLog);
			return da;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected virtual void OnDataPreExecute(IDataAccess pAccess, RexConnDataAccess pRexConnData) {
			//int n = pRexConnData.Context.Request.CmdList.Count;
			//Log.Debug(ContextId, "Data", "PreExec commands: "+n);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void OnDataPostExecute(IDataAccess pAccess, IResponseResult pResult) {
			DbQueryExecutionCount++;
			DbQueryMillis += (int)pResult.Response.Timer;

			string key = "apictx."+pAccess.ExecuteName;
			Metrics.Counter(key, 1);

			if ( pResult.Response.Timer != null ) {
				Metrics.Timer(key+".rc", (long)pResult.Response.Timer);
			}

			Metrics.Timer(key+".ex", (long)pResult.ExecutionMilliseconds);
			Metrics.Mean(key+".len", pResult.ResponseJson.Length);
			Metrics.Counter(key+".err", (pResult.IsError ? 1 : 0));

			//Log.Debug(ContextId, "Data", "PostExec timer: "+pResult.Response.Timer+"ms");
			//Log.Debug(ContextId.ToString("N"), "Data", "Request: "+pResult.RequestJson);
			//Log.Debug(ContextId.ToString("N"), "Data", "Response: "+pResult.ResponseJson);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void OnDataPostExecuteError(IDataAccess pAccess, Exception pEx) {
			string key = "apictx."+pAccess.ExecuteName;
			Metrics.Counter(key, 1);
			Metrics.Counter(key+".err", 1);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void OnLog(IDataAccess pAccess, string pName, string pText) {
			Log.Debug(ContextId.ToString("N"), pName, pText);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		public void ProfilerTrace(object pObj, string pName) {
			ProfilerTrace(pObj.GetType().Name, pName);
		}

		/*--------------------------------------------------------------------------------------------* /
		public void ProfilerTrace(string pObjName, string pName) {
			Log.Debug("---> "+String.Format("{0,7:##0.000}", vProfiler.Elapsed.TotalMilliseconds)+
				"ms ("+pObjName+"."+pName+")");
		}*/

	}

}