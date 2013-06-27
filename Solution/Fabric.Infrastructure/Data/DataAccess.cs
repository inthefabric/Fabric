using System;
using System.Collections.Generic;
using Fabric.Infrastructure.Api;
using RexConnectClient.Core;
using RexConnectClient.Core.Result;
using Weaver.Core.Query;
using Weaver.Exec.RexConnect;

namespace Fabric.Infrastructure.Data {

	/*================================================================================================*/
	public class DataAccess : IDataAccess {

		protected IApiContext vApiCtx;
		protected WeaverRequest vReq;
		protected RexConnContext vRexConnCtx;

		private Action<RexConnDataAccess> vPreExecute;
		private Action<IResponseResult> vPostExecute;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Build(IApiContext pApiCtx, string pSessionId=null) {
			vApiCtx = pApiCtx;
			vReq = new WeaverRequest(pApiCtx.ContextId.ToString("N"), pSessionId);
			vRexConnCtx = new RexConnContext(vReq, pApiCtx.RexConnUrl, pApiCtx.RexConnPort);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void SetExecuteHooks(Action<RexConnDataAccess> pPreExecute,
																Action<IResponseResult> pPostExecute) {
			vPreExecute = pPreExecute;
			vPostExecute = pPostExecute;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataAccess AddQuery(string pScript) {
			vReq.AddQuery(pScript);
			return this;
		}

		/*--------------------------------------------------------------------------------------------*/
		public DataAccess AddQuery(string pScript, IDictionary<string, string> pParams) {
			vReq.AddQuery(pScript, pParams);
			return this;
		}

		/*--------------------------------------------------------------------------------------------*/
		public DataAccess AddQuery(string pScript, IDictionary<string, IWeaverQueryVal> pParams) {
			vReq.AddQuery(pScript, pParams);
			return this;
		}

		/*--------------------------------------------------------------------------------------------*/
		public DataAccess AddQuery(IWeaverScript pWeaverScript) {
			vReq.AddQuery(pWeaverScript);
			return this;
		}

		/*--------------------------------------------------------------------------------------------*/
		public DataAccess AddQuery(IEnumerable<IWeaverScript> pWeaverScripts) {
			vReq.AddQueries(pWeaverScripts, true);
			return this;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataAccess AddSessionStart() {
			vReq.AddSessionAction(RexConn.SessionAction.Start);
			return this;
		}

		/*--------------------------------------------------------------------------------------------*/
		public DataAccess AddSessionClose() {
			vReq.AddSessionAction(RexConn.SessionAction.Close);
			return this;
		}

		/*--------------------------------------------------------------------------------------------*/
		public DataAccess AddSessionRollback() {
			vReq.AddSessionAction(RexConn.SessionAction.Rollback);
			return this;
		}

		/*--------------------------------------------------------------------------------------------*/
		public DataAccess AddSessionCommit() {
			vReq.AddSessionAction(RexConn.SessionAction.Commit);
			return this;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataAccess AddConfigDebug(bool pEnable) {
			vReq.AddConfigSetting(RexConn.ConfigSetting.Debug, (pEnable ? "1" : "0"));
			return this;
		}

		/*--------------------------------------------------------------------------------------------*/
		public DataAccess AddConfigPretty(bool pEnable) {
			vReq.AddConfigSetting(RexConn.ConfigSetting.Pretty, (pEnable ? "1" : "0"));
			return this;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataResult Execute() {
			var data = new RexConnDataAccess(vRexConnCtx);

			if ( vPreExecute != null ) {
				vPreExecute(data);
			}

			IResponseResult rr = data.Execute();

			if ( vPostExecute != null ) {
				vPostExecute(rr);
			}

			LogAction(rr);
			return new DataResult(rr);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void LogAction(IResponseResult pRes) {
			//DBv1: 
			//	TotalMs, QueryMs, Timestamp, QueryChars

			const string name = "DBv1";
			const string x = " | ";

			string v1 =
				pRes.ExecutionMilliseconds +x+
				pRes.Response.Timer +x+
				DateTime.UtcNow.Ticks +x+
				pRes.RequestJson.Length;
			
			Log.Info(vApiCtx.ContextId, name, v1);
		}

	}

}