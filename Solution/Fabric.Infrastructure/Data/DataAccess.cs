using System;
using System.Collections.Generic;
using Fabric.Infrastructure.Api;
using RexConnectClient.Core;
using RexConnectClient.Core.Result;
using RexConnectClient.Core.Transfer;
using Weaver.Core.Query;
using Weaver.Exec.RexConnect;

namespace Fabric.Infrastructure.Data {

	/*================================================================================================*/
	public class DataAccess : IDataAccess {

		protected IApiContext vApiCtx;
		protected WeaverRequest vReq;
		protected RexConnContext vRexConnCtx;

		private bool vSetCmdIds;
		private bool vOmitCmdTimers;
		private int vCmdIndex;
		private RequestCmd vLatestCmd;
		private Action<IDataAccess, RexConnDataAccess> vPreExecute;
		private Action<IDataAccess, IResponseResult> vPostExecute;
		private Action<IDataAccess, Exception> vPostExecuteErr;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Build(IApiContext pApiCtx, string pSessionId=null, bool pSetCmdIds=false,
																			bool pOmitCmdTimers=true) {
			vApiCtx = pApiCtx;
			vReq = new WeaverRequest("0", pSessionId); //pApiCtx.ContextId.ToString("N")
			vRexConnCtx = new RexConnContext(vReq, pApiCtx.RexConnUrl, pApiCtx.RexConnPort);
			vSetCmdIds = pSetCmdIds;
			vOmitCmdTimers = pOmitCmdTimers;
			vCmdIndex = 0;
		}

		/*--------------------------------------------------------------------------------------------*/
		internal void SetExecuteHooks(Action<IDataAccess, RexConnDataAccess> pPreExecute,
													Action<IDataAccess, IResponseResult> pPostExecute,
													Action<IDataAccess, Exception> pPostExecuteErr) {
			vPreExecute = pPreExecute;
			vPostExecute = pPostExecute;
			vPostExecuteErr = pPostExecuteErr;
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetLatestCommandId() {
			return vLatestCmd.CmdId;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddConditionsToLatestCommand(string pCmdId) {
			vLatestCmd.AddConditionalCommandId(pCmdId);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AppendScriptToLatestCommand(string pScript) {
			vLatestCmd.Cmd += pScript;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void OmitResultsOfLatestCommand() {
			vLatestCmd.EnableOption(RequestCmd.Option.OmitResults);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void RemoveCommandIdOfLatestCommand() {
			vLatestCmd.CmdId = null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IDataAccess AddQuery(string pScript) {
			OnCmd(vReq.AddQuery(pScript));
			return this;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDataAccess AddQuery(string pScript, IDictionary<string, string> pParams) {
			OnCmd(vReq.AddQuery(pScript, pParams));
			return this;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDataAccess AddQuery(string pScript, IDictionary<string, IWeaverQueryVal> pParams) {
			OnCmd(vReq.AddQuery(pScript, pParams));
			return this;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDataAccess AddQuery(IWeaverScript pWeaverScript) {
			OnCmd(vReq.AddQuery(pWeaverScript));
			return this;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDataAccess AddQueries(IEnumerable<IWeaverScript> pWeaverScripts) {
			foreach ( IWeaverScript ws in pWeaverScripts ) {
				OnCmd(vReq.AddQuery(ws));
			}

			return this;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDataAccess AddQueries(IWeaverTransaction pTx) {
			foreach ( IWeaverQuery q in pTx.Queries ) {
				OnCmd(vReq.AddQuery(q));
			}

			return this;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IDataAccess AddSessionStart() {
			OnCmd(vReq.AddSessionAction(RexConn.SessionAction.Start));
			return this;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDataAccess AddSessionClose() {
			OnCmd(vReq.AddSessionAction(RexConn.SessionAction.Close));
			return this;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDataAccess AddSessionRollback() {
			OnCmd(vReq.AddSessionAction(RexConn.SessionAction.Rollback));
			return this;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDataAccess AddSessionCommit() {
			OnCmd(vReq.AddSessionAction(RexConn.SessionAction.Commit));
			return this;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IDataAccess AddConfigDebug(bool pEnable) {
			OnCmd(vReq.AddConfigSetting(RexConn.ConfigSetting.Debug, (pEnable ? "1" : "0")));
			return this;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IDataAccess AddConfigPretty(bool pEnable) {
			OnCmd(vReq.AddConfigSetting(RexConn.ConfigSetting.Pretty, (pEnable ? "1" : "0")));
			return this;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IDataResult Execute(string pName) {
			ExecuteName = pName;

			var data = new RexConnDataAccess(vRexConnCtx);
			IResponseResult rr = null;
			
			if ( vPreExecute != null ) {
				vPreExecute(this, data);
			}

			try {
				rr = data.Execute();
			}
			catch ( ResponseErrException ree ) {
				if ( vPostExecuteErr != null ) {
					vPostExecuteErr(this, ree);
				}

				throw new DataAccessException(this, ree.Message);
			}
			catch ( Exception e ) {
				if ( vPostExecuteErr != null ) {
					vPostExecuteErr(this, e);
				}

				throw;
			}

			if ( vPostExecute != null ) {
				vPostExecute(this, rr);
			}

			LogAction(rr);
			return new DataResult(rr);
		}

		/*--------------------------------------------------------------------------------------------*/
		public string ExecuteName { get; private set; }
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnCmd(RequestCmd pCmd) {
			vLatestCmd = pCmd;

			if ( vSetCmdIds ) {
				vLatestCmd.CmdId = vCmdIndex+"";
			}

			if ( vOmitCmdTimers ) {
				vLatestCmd.EnableOption(RequestCmd.Option.OmitTimer);
			}

			vCmdIndex++;

			//Log.Debug(vApiCtx.ContextId, "CMD", vLatestCmd.CmdId+": "+vLatestCmd.Cmd+" => "+
			//	string.Join(" // ", vLatestCmd.Args));
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