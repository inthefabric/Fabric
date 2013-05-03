using System;
using System.Collections.Generic;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Db;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.Common {

	/*================================================================================================*/
	public class TestApiDataAccess : ApiDataAccess {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestApiDataAccess(IApiContext pContext, string pScript,
												IDictionary<string, IWeaverQueryVal> pParams=null) :
												base(pContext, pScript, pParams) {}

		/*--------------------------------------------------------------------------------------------*/
		public TestApiDataAccess(IApiContext pContext, IWeaverScript pScripted):
												this(pContext, pScripted.Script, pScripted.Params) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public TestApiDataAccess(IApiContext pContext, IList<IWeaverScript> pScriptedList) :
																	base(pContext, pScriptedList) {}

		/*--------------------------------------------------------------------------------------------*/
		public TestApiDataAccess(IApiContext pContext, RexConnTcpRequest pRequest) :
																			base(pContext, pRequest) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Execute() {
			AlterExecute(ApiCtx, Request);
			base.Execute();
			PostExecute(ApiCtx, Response);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override string GetRawResult(string pReqJson) {
			long t = DateTime.UtcNow.Ticks;
			string json = base.GetRawResult(pReqJson);
			Log.Info("Query: "+(DateTime.UtcNow.Ticks-t)/10000+"ms");
			Log.Info("");
			return json;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal static void AlterExecute(IApiContext pApiCtx, RexConnTcpRequest pReq) {
			TestApiContext tac = (TestApiContext)pApiCtx;

			if ( pReq.SessId == null ) {
				pReq.SessId = tac.SessionId;
			}

			Log.Debug(" - AlterExecute SessionId: "+pReq.SessId);

			if ( tac.PerfomingSessionAction ) {
				return;
			}

			for ( int i = 0 ; i < pReq.CmdList.Count ; ++i ) {
				RexConnTcpRequestCommand cmd = pReq.CmdList[i];
				
				if ( cmd.Cmd != RexConnCommand.Session ) {
					continue;
				}

				string a = cmd.Args[0];

				/*if ( a != RexConnSessionAction.Commit && a != RexConnSessionAction.Close ) {
					continue;
				}*/

				Log.Warn("*** Removed "+RexConnCommand.Session+"."+a+" from request ***");
				pReq.CmdList.RemoveAt(i);
				--i;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		internal static void PostExecute(IApiContext pApiCtx, RexConnTcpResponse pResp) {
			if ( pResp.SessId == null ) {
				return;
			}

			((TestApiContext)pApiCtx).AddInternalSessionId(pResp.SessId);
		}

	}

}