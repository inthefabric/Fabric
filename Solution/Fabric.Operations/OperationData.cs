using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Broadcast;
using Fabric.Infrastructure.Cache;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Query;
using RexConnectClient.Core;
using RexConnectClient.Core.Result;
using Weaver.Core.Query;

namespace Fabric.Operations {

	/*================================================================================================*/
	public class OperationData : IOperationData {

		private static readonly Logger Log = Logger.Build<OperationData>();

		public int DbQueryExecutionCount { get; private set; }
		public int DbQueryMillis { get; private set; }

		private readonly Guid vContextId;
		private readonly IDataAccessFactory vFactory;
		private readonly IMetricsManager vMetrics;
		private readonly IMemCache vCache;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OperationData(Guid pContextId, IDataAccessFactory pFactory,
														IMetricsManager pMetrics, IMemCache pCache) {
			vContextId = pContextId;
			vFactory = pFactory;
			vMetrics = pMetrics;
			vCache = pCache;

			DbQueryExecutionCount = 0;
			DbQueryMillis = 0;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDataAccess Build(string pSessionId=null, bool pSetCmdIds=false,
																			bool pOmitCmdTimers=true) {
			IDataAccess da = vFactory.Create(pSessionId, pSetCmdIds, pOmitCmdTimers);
			da.SetExecuteHooks(OnDataPreExecute, OnDataPostExecute, OnDataPostExecuteError);
			da.SetLoggingHook(OnLog);
			return da;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IDataResult Execute(IWeaverScript pWeaverScript, string pName) {
			return Build().AddQuery(pWeaverScript).Execute(pName);
		}

		/*--------------------------------------------------------------------------------------------*/
		public T Get<T>(IWeaverScript pWeaverScript, string pName) where T : class, IElement, new() {
			return Build().AddQuery(pWeaverScript).Execute(pName).ToElement<T>();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public IList<T> GetList<T>(IWeaverScript pWeaverScript, string pName)
																	where T : class, IElement, new() {
			return Build().AddQuery(pWeaverScript).Execute(pName).ToElementList<T>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public T GetVertexById<T>(long pVertexId) where T : Vertex, new() {
			T item = vCache.FindVertex<T>(pVertexId);

			if ( item != null ) {
				return item;
			}

			item = new T();
			item.VertexId = pVertexId;

			IWeaverQuery q = Weave.Inst.Graph.V.ExactIndex(item).ToQuery();
			item = Build().AddQuery(q).Execute("GetVertexById").ToElement<T>();

			if ( item == null ) {
				vCache.RemoveVertex<T>(pVertexId);
			}
			else {
				vCache.AddVertex(item);
			}

			return item;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected virtual void OnDataPreExecute(IDataAccess pAccess, RexConnDataAccess pRexConnData) {
			//int n = pRexConnData.Context.Request.CmdList.Count;
			//Log.Debug(ContextId, "Data", "PreExec commands: "+n);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void OnDataPostExecute(IDataAccess pAccess, IResponseResult pResult) {
			DbQueryExecutionCount++;
			DbQueryMillis += (pResult.Response.Timer == null ? 0 : (int)pResult.Response.Timer);

			string key = "opdata."+pAccess.ExecuteName;
			vMetrics.Counter(key, 1);

			if ( pResult.Response.Timer != null ) {
				vMetrics.Timer(key+".rc", (long)pResult.Response.Timer);
			}

			vMetrics.Timer(key+".ex", (long)pResult.ExecutionMilliseconds);
			vMetrics.Mean(key+".len", pResult.ResponseJson.Length);
			vMetrics.Counter(key+".err", (pResult.IsError ? 1 : 0));

			//Log.Debug(ContextId, "Data", "PostExec timer: "+pResult.Response.Timer+"ms");
			//Log.Debug(ContextId.ToString("N"), "Data", "Request: "+pResult.RequestJson);
			//Log.Debug(ContextId.ToString("N"), "Data", "Response: "+pResult.ResponseJson);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void OnDataPostExecuteError(IDataAccess pAccess, Exception pEx) {
			string key = "opdata."+pAccess.ExecuteName;
			vMetrics.Counter(key, 1);
			vMetrics.Counter(key+".err", 1);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void OnLog(IDataAccess pAccess, string pName, string pText) {
			if ( !pName.Contains("DB") ) {
				pText = pAccess.ExecuteName+" | "+pText;
			}

			Log.Debug(Logger.GuidToString(vContextId), pName, pText);
		}

	}

}