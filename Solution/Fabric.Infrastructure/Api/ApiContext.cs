using System;
using System.Collections.Generic;
using System.Diagnostics;
using Fabric.Domain;
using Fabric.Infrastructure.Analytics;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Weaver;
using RexConnectClient.Core;
using RexConnectClient.Core.Result;
using Weaver.Core.Query;

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
			da.Build(this);
			da.SetExecuteHooks(OnDataPreExecute, OnDataPostExecute);
			return da;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected virtual void OnDataPreExecute(RexConnDataAccess pRexConnData) {
			int n = pRexConnData.Context.Request.CmdList.Count;
			Log.Debug(ContextId, "Data", "PreExec commands: "+n);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void OnDataPostExecute(IResponseResult pResult) {
			DbQueryExecutionCount++;
			DbQueryMillis += (int)pResult.Response.Timer;
			Log.Debug(ContextId, "Data", "PostExec timer: "+pResult.Response.Timer+"ms");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IApiDataAccess DbData(string pQueryName, IWeaverScript pScripted) {
			var a = NewAccess(pScripted);
			return DbDataAccess(pQueryName, a);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public IApiDataAccess DbData(string pQueryName, IList<IWeaverScript> pScriptedList) {
			var a = NewAccess(pScriptedList);
			return DbDataAccess(pQueryName, a);
		}

		/*--------------------------------------------------------------------------------------------* /
		public IApiDataAccess DbData(string pQueryName, RexConnTcpRequest pRequest) {
			var a = NewAccess(pRequest);
			return DbDataAccess(pQueryName, a);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public T DbVertexById<T>(long pTypeId) where T : class, IVertex, IVertexWithId, new() {
			T item = Cache.Memory.FindVertex<T>(pTypeId);
			
			if ( item != null ) {
				return item;
			}
			
			item = new T();
			((IVertex)item).SetTypeId(pTypeId);
			IWeaverQuery q = Weave.Inst.Graph.V.ExactIndex(item).ToQuery();
			item = DbSingle<T>("Get"+typeof(T).Name+"ById", q);
			
			if ( item != null ) {
				Cache.Memory.AddVertex(item);
			}
			
			return item;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public T DbSingle<T>(string pQueryName, IWeaverScript pScripted)
																where T : class, IElementWithId, new() {
			var a = NewAccess<T>(pScripted);
			IApiDataAccess<T> da = DbDataAccess(pQueryName, a);

			if ( da.TypedResultList == null || da.TypedResultList.Count == 0 ) {
				return default(T);
			}

			if ( da.TypedResultList.Count > 1 ) {
				Log.Debug("DbSingle Error > Query: "+a.Request);
				Log.Debug("DbSingle Error > RawResult: "+da.Result.ResponseJson);
				throw new Exception("DbSingle<"+typeof(T).Name+"> expects 1 result, but received "+
					da.TypedResultList.Count);
			}

			return da.TypedResultList[0];
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<T> DbList<T>(string pQueryName, IWeaverScript pScripted)
																		where T : IElementWithId, new() {
			var a = NewAccess<T>(pScripted);
			return DbDataAccess(pQueryName, a).TypedResultList;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		// Hooks for ApiContext subclasses
		/*--------------------------------------------------------------------------------------------*/
		protected virtual IApiDataAccess NewAccess(IWeaverScript pScripted) {
			return new ApiDataAccess(this, pScripted);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual IApiDataAccess<T> NewAccess<T>(IWeaverScript pScripted)
																		where T : IElementWithId, new() {
			return new ApiDataAccess<T>(this, pScripted);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual IApiDataAccess NewAccess(IList<IWeaverScript> pScriptedList) {
			return new ApiDataAccess(this, pScriptedList);
		}

		/*--------------------------------------------------------------------------------------------* /
		protected virtual IApiDataAccess NewAccess(WeaverRequest pRequest) {
			return new ApiDataAccess(this, pRequest);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected virtual IApiDataAccess DbDataAccess(string pQueryName, IApiDataAccess pDbQuery) {
			pDbQuery.Execute();
			DbQueryExecutionCount++;
			DbQueryMillis += (int)pDbQuery.Result.Response.Timer;
			return pDbQuery;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual IApiDataAccess<T> DbDataAccess<T>(string pQueryName,
											IApiDataAccess<T> pDbQuery) where T : IElementWithId, new() {
			pDbQuery.Execute();
			DbQueryExecutionCount++;
			DbQueryMillis += (int)pDbQuery.Result.Response.Timer;
			return pDbQuery;
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