using System;
using System.Collections;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Weaver;
using RexConnectClient.Core;
using RexConnectClient.Core.Result;
using Weaver.Core.Query;
using Weaver.Exec.RexConnect;

namespace Fabric.Infrastructure.Data {

	/*================================================================================================*/
	public class DataAccess {

		public RexConnContext RexConnCtx { get; private set; }
		public IResponseResult Result { get; private set; }

		private IApiContext vApiCtx;
		private WeaverRequest vReq;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Build(IApiContext pApiCtx, string pSessionId=null) {
			vApiCtx = pApiCtx;
			vReq = new WeaverRequest(pApiCtx.ContextId.ToString("N"), pSessionId);
			RexConnCtx = new RexConnContext(vReq, pApiCtx.RexConnUrl, pApiCtx.RexConnPort);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddQuery(string pScript) {
			vReq.AddQuery(pScript);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddQuery(string pScript, IDictionary<string, string> pParams) {
			vReq.AddQuery(pScript, pParams);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddQuery(string pScript, IDictionary<string, IWeaverQueryVal> pParams) {
			vReq.AddQuery(pScript, pParams);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddQuery(IWeaverScript pWeaverScript) {
			vReq.AddQuery(pWeaverScript);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddQuery(IEnumerable<IWeaverScript> pWeaverScripts) {
			vReq.AddQueries(pWeaverScripts, true);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddSessionStart() {
			vReq.AddSessionAction(RexConn.SessionAction.Start);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddSessionClose() {
			vReq.AddSessionAction(RexConn.SessionAction.Close);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddSessionRollback() {
			vReq.AddSessionAction(RexConn.SessionAction.Rollback);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddSessionCommit() {
			vReq.AddSessionAction(RexConn.SessionAction.Commit);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddConfigDebug(bool pEnable) {
			vReq.AddConfigSetting(RexConn.ConfigSetting.Debug, (pEnable ? "1" : "0"));
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddConfigPretty(bool pEnable) {
			vReq.AddConfigSetting(RexConn.ConfigSetting.Pretty, (pEnable ? "1" : "0"));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Execute() {
			if ( Result != null ) {
				throw new Exception("This request has already been executed.");
			}

			var data = new RexConnDataAccess(RexConnCtx);
			Result = data.Execute();
			LogAction();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public int GetResultCount(int pCommandIndex=0) {
			return Result.Response.CmdList[pCommandIndex].Results.Count;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public T DbVertexById<T>(long pTypeId) where T : class, IVertex, IVertexWithId, new() {
			T item = vApiCtx.Cache.Memory.FindVertex<T>(pTypeId);

			if ( item == null ) {
				item = new T();
				((IVertex)item).SetTypeId(pTypeId);

				AddQuery(Weave.Inst.Graph.V.ExactIndex(item).ToQuery());
				item = ExecuteForSingle<T>("Get"+typeof(T).Name+"ById");

				if ( item == null ) {
					vApiCtx.Cache.Memory.RemoveVertex<T>(pTypeId);
				}
				else {
					vApiCtx.Cache.Memory.AddVertex(item);
				}
			}

			return item;
		}

		/*--------------------------------------------------------------------------------------------*/
		public T ExecuteForSingle<T>(string pQueryName) where T : class, IItemWithId, new() {
			if ( RexConnCtx.Request.CmdList.Count > 1 ) {
				throw new Exception("Expected one request command: "+RexConnCtx.Request.CmdList.Count);
			}

			Execute();

			if ( GetResultCount() > 1 ) {
				throw new Exception("Expected one item in command response: "+GetResultCount());
			}

			IList<IGraphElement> elems = Result.GetGraphElementsAt(0);

			if ( elems.Count == 0 ) {
				return default(T);
			}

			return new DbDto(elems[0]).ToItem<T>();
		}

		/*--------------------------------------------------------------------------------------------* /
		public IList<T> DbList<T>(string pQueryName, IWeaverScript pScripted)
																		where T : IItemWithId, new() {
			var a = NewAccess<T>(pScripted);
			return DbDataAccess(pQueryName, a).TypedResultList;
		}












		
		/*--------------------------------------------------------------------------------------------* /
		public T GetResultAt<T>(int pIndex) where T : IItemWithId, new() {
			var d = new DbDto(Result.GetGraphElementsAt(0)[pIndex]);
			return d.ToItem<T>();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		public int GetTextListCount() {
			return Result.GetTextResultsAt(0).Values.Count;
		}

		/*--------------------------------------------------------------------------------------------* /
		public string GetStringResultAt(int pIndex) {
			return Result.GetTextResultsAt(0).ToString(pIndex);
		}

		/*--------------------------------------------------------------------------------------------* /
		public int GetIntResultAt(int pIndex) {
			return Result.GetTextResultsAt(0).ToInt(pIndex);
		}

		/*--------------------------------------------------------------------------------------------* /
		public long GetLongResultAt(int pIndex) {
			return Result.GetTextResultsAt(0).ToLong(pIndex);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void LogAction() {
			//DBv1: 
			//	TotalMs, QueryMs, Timestamp, QueryChars

			const string name = "DBv1";
			const string x = " | ";

			string v1 =
				Result.ExecutionMilliseconds +x+
				Result.Response.Timer +x+
				DateTime.UtcNow.Ticks +x+
				Result.RequestJson.Length;
			
			Log.Info(vApiCtx.ContextId, name, v1);
		}

	}

}