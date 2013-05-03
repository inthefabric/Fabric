using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using NUnit.Framework;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabInfra {

	/*================================================================================================*/
	[TestFixture]
	public class XDbDto : IntegTestBase {
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Edge() {
			IWeaverQuery q = 
				Weave.Inst.BeginPath<User>(u => u.UserId, 2).BaseNode
				.UsesEmail
				.End();

			ApiCtx.DbList<UserUsesEmail>("test", q);
		}

		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void NestedSessions() {
			int countA = GetCount(null);

				RexConnTcpRequest req = NewReq(null);
				ApiDataAccess.AddSessionAction(req, RexConnSessionAction.Start);
				string outerSessId = ApiCtx.DbData("OuterStart", req).Response.SessId;

					////

					req = NewReq(outerSessId);
					ApiDataAccess.AddSessionAction(req, RexConnSessionAction.Start);
					string innerSessId = ApiCtx.DbData("InnerStart", req).Response.SessId;

					req = NewReq(innerSessId);
					var cmd = new RexConnTcpRequestCommand();
					cmd.Cmd = RexConnCommand.Query;
					cmd.Args = new List<string>();
					cmd.Args.Add("g.addVertex([N_FT:1001,SessionTest:true])");
					req.CmdList.Add(cmd);
					ApiCtx.DbData("Add", req);
					int countB = GetCount(innerSessId);

					req = NewReq(innerSessId);
					ApiDataAccess.AddSessionAction(req, RexConnSessionAction.Commit);
					ApiCtx.DbData("InnerCommit", req);
					int countC = GetCount(innerSessId);

					req = NewReq(innerSessId);
					ApiDataAccess.AddSessionAction(req, RexConnSessionAction.Close);
					ApiCtx.DbData("InnerClose", req);

					////

				int countD = GetCount(outerSessId);
				req = NewReq(outerSessId);
				ApiDataAccess.AddSessionAction(req, RexConnSessionAction.Rollback);
				ApiCtx.DbData("OuterRollback", req);
				int countE = GetCount(outerSessId);

				req = NewReq(outerSessId);
				ApiDataAccess.AddSessionAction(req, RexConnSessionAction.Close);
				ApiCtx.DbData("OuterClose", req);

			int countF = GetCount(null);
			Log.Debug(countA+", "+countB+", "+countC+", "+countD+", "+countE+", "+countF);

			Assert.AreEqual(countA, countF, "Incorrect count.");
		}

		/*--------------------------------------------------------------------------------------------* /
		private RexConnTcpRequest NewReq(string pSessId) {
			var req = new RexConnTcpRequest();
			req.ReqId = "TEST";
			req.SessId = pSessId;
			req.CmdList = new List<RexConnTcpRequestCommand>();
			return req;
		}

		/*--------------------------------------------------------------------------------------------* /
		private int GetCount(string pSessId) {
			var cmd = new RexConnTcpRequestCommand();
			cmd.Cmd = RexConnCommand.Query;
			cmd.Args = new List<string>();
			cmd.Args.Add("g.V.count()");

			RexConnTcpRequest req = NewReq(pSessId);
			req.CmdList.Add(cmd);
			return ApiCtx.DbData("Count", req).GetIntResultAt(0);
		}*/
		
	}

}