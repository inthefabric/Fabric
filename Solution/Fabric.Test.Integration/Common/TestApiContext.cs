using System;
using System.Collections.Generic;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Caching;
using Fabric.Infrastructure.Db;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.Common {
	
	/*================================================================================================*/
	public class TestApiContext : ApiContext {

		public DateTime? TestUtcNow { get; set; }
		//public string TestCode32 { get; set; }
		public IList<long> SharpflakeIds { get; private set; }
		public string SessionId { get; private set; }
		public bool PerfomingSessionAction { get; private set; }

		private IList<string> vInternalSessionIds;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestApiContext() : base("rexster", 8185, new CacheManager("ApiTest", true)) {
			SharpflakeIds = new List<long>();
			vInternalSessionIds = new List<string>();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void PerformSessionAction(string pCommand) {
			PerfomingSessionAction = true;

			var req = new RexConnTcpRequest();
			req.ReqId = ContextId.ToString();
			req.CmdList = new List<RexConnTcpRequestCommand>();

			ApiDataAccess.AddSessionAction(req, pCommand);
			IApiDataAccess da = DbDataAccess("TEST.Session."+pCommand, NewAccess(req));

			if ( pCommand == RexConnSessionAction.Start ) {
				SessionId = da.Response.SessId;
				Log.Debug("Test-level SessionId: "+SessionId);
			}
			else if ( pCommand == RexConnSessionAction.Close ) {
				SessionId = null;
			}

			PerfomingSessionAction = false;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public bool AddInternalSessionId(string pSessId) {
			if ( PerfomingSessionAction || pSessId == SessionId ) {
				return false;
			}

			vInternalSessionIds.Add(pSessId);
			Log.Warn("*** Recorded internal session "+pSessId+" ("+vInternalSessionIds.Count+") ***");
			return true;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CloseInternalSessions() {
			PerfomingSessionAction = true;

			foreach ( string id in vInternalSessionIds ) {
				var req = new RexConnTcpRequest();
				req.ReqId = ContextId.ToString();
				req.SessId = id;

				req.CmdList = new List<RexConnTcpRequestCommand>();
				ApiDataAccess.AddSessionAction(req, RexConnSessionAction.Rollback);
				ApiDataAccess.AddSessionAction(req, RexConnSessionAction.Close);

				DbDataAccess("TEST.CloseInternalSessions", NewAccess(req));
			}

			vInternalSessionIds = new List<string>();
			PerfomingSessionAction = false;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override DateTime UtcNow {
			get {
				return (TestUtcNow == null ? base.UtcNow : (DateTime)TestUtcNow);
			}
		}

		/*--------------------------------------------------------------------------------------------* /
		public override string Code32 {
			get { return (TestUtcNow == null ? base.Code32 : TestCode32); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public override long GetSharpflakeId<T>() {
			long id = Sharpflake.GetId<T>();

			lock ( this ) {
				SharpflakeIds.Add(id);
			}

			return id;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IApiDataAccess DbData(string pQueryName, RexConnTcpRequest pReq) {
			var a = NewAccess(pReq);
			return DbDataAccess(pQueryName, a);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override IApiDataAccess NewAccess(IWeaverScript pScripted) {
			return new TestApiDataAccess(this, pScripted);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override IApiDataAccess<T> NewAccess<T>(IWeaverScript pScripted) {
			return new TestApiDataAccess<T>(this, pScripted);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override IApiDataAccess NewAccess(IList<IWeaverScript> pScriptedList) {
			return new TestApiDataAccess(this, pScriptedList);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override IApiDataAccess NewAccess(RexConnTcpRequest pReq) {
			return new TestApiDataAccess(this, pReq);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override IApiDataAccess DbDataAccess(string pQueryName, IApiDataAccess pDbQuery) {
			Log.Info("Query ("+pQueryName+") ExCount="+DbQueryExecutionCount+", NumCmds="+
				pDbQuery.Request.CmdList.Count+", SessId="+pDbQuery.Request.SessId);
			return base.DbDataAccess(pQueryName, pDbQuery);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override IApiDataAccess<T> DbDataAccess<T>(string pQueryName,
																		IApiDataAccess<T> pDbQuery) {
			Log.Info("Query<"+typeof(T).Name+"> ("+pQueryName+") ExCount="+DbQueryExecutionCount+
				", NumCmds="+pDbQuery.Request.CmdList.Count+", SessId="+pDbQuery.Request.SessId);
			return base.DbDataAccess(pQueryName, pDbQuery);
		}

	}

}