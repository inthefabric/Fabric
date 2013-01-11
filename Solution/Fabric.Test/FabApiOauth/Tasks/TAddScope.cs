using System;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TAddScope {

		private readonly static string QueryUpdateScope =
			"g.idx(_P0).get('"+typeof(User).Name+"Id',{{UserId}}L)[0]"+
			".inE('"+typeof(OauthScopeUsesUser).Name+"').outV"+
				".as('step3')"+
			".outE('"+typeof(OauthScopeUsesApp).Name+"').inV"+
				".has('"+typeof(App).Name+"Id',Tokens.T.eq,{{AppId}}L)"+
			".back('step3')"+
				".each{"+
					"it.Allow={{Allow}};"+
					"it.Created={{UtcNowTicks}}L"+
				"};";

		private readonly static string QueryAddScopeTx =
			"g.startTransaction();"+
				"_V0=g.v(0);"+
				"_V1=g.addVertex(["+
					typeof(OauthScope).Name+"Id:{{OauthScopeId}}L,"+
					"Allow:{{Allow}},"+
					"Created:{{UtcNowTicks}}L"+
				"]);"+
				"g.idx(_TP0).put(_TP1,_V1."+typeof(OauthScope).Name+"Id,_V1);"+
				"g.addEdge(_V0,_V1,_TP2);"+
				"_V2=g.idx(_TP3).get('"+typeof(App).Name+"Id',{{AppId}}L)[0];"+
				"g.addEdge(_V1,_V2,_TP4);"+
				"_V3=g.idx(_TP5).get('"+typeof(User).Name+"Id',{{UserId}}L)[0];"+
				"g.addEdge(_V1,_V3,_TP6);"+
			"g.stopTransaction(TransactionalGraph.Conclusion.SUCCESS);"+
			"_V1;";

		protected long vAppId;
		protected long vUserId;
		protected bool vAllow;
		protected DateTime vUtcNow;
		protected long vAddOauthScopeId;
		private OauthScope vScopeResult;
		private OauthScope vAddScopeResult;
		protected Mock<IApiContext> vMockCtx;
		protected UsageMap vUsageMap;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public virtual void SetUp() {
			vAppId = 99;
			vUserId = 1234;
			vAllow = true;
			vUtcNow = DateTime.UtcNow;
			vAddOauthScopeId = 123456789;
			vUsageMap = new UsageMap();
			
			vScopeResult = new OauthScope();
			vAddScopeResult = new OauthScope();

			vMockCtx = new Mock<IApiContext>();
			vMockCtx.Setup(x => x.GetSharpflakeId<OauthScope>()).Returns(vAddOauthScopeId);
			vMockCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
			
			vMockCtx
				.Setup(x => x.DbSingle<OauthScope>(
					AddScope.Query.UpdateScope+"", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverScript ws) => UpdateScope(ws));
			
			vMockCtx
				.Setup(x => x.DbSingle<OauthScope>(
					AddScope.Query.AddScopeTx+"", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverScript ws) => AddScopeTx(ws));
		}

		/*--------------------------------------------------------------------------------------------*/
		private OauthScope TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().AddScope(vAppId, vUserId, vAllow, vMockCtx.Object);
			}

			var task = new AddScope(vAppId, vUserId, vAllow);
			return task.Go(vMockCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private OauthScope UpdateScope(IWeaverScript pScripted) {
			TestUtil.LogWeaverScript(pScripted);
			vUsageMap.Increment(AddScope.Query.UpdateScope+"");
			
			string expect = QueryUpdateScope
				.Replace("{{AppId}}", vAppId+"")
				.Replace("{{UserId}}", vUserId+"")
				.Replace("{{Allow}}", vAllow.ToString().ToLower())
				.Replace("{{UtcNowTicks}}", vUtcNow.Ticks+"");

			Assert.AreEqual(expect, pScripted.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pScripted.Params, "_P0", typeof(User).Name);
			
			return vScopeResult;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private OauthScope AddScopeTx(IWeaverScript pScripted) {
			TestUtil.LogWeaverScript(pScripted);
			vUsageMap.Increment(AddScope.Query.AddScopeTx+"");

			string expect = QueryAddScopeTx
				.Replace("{{OauthScopeId}}", vAddOauthScopeId+"")
				.Replace("{{AppId}}", vAppId+"")
				.Replace("{{UserId}}", vUserId+"")
				.Replace("{{Allow}}", vAllow.ToString().ToLower())
				.Replace("{{UtcNowTicks}}", vUtcNow.Ticks+"");

			Assert.AreEqual(expect, pScripted.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pScripted.Params, "_TP0", typeof(OauthScope).Name);
			TestUtil.CheckParam(pScripted.Params, "_TP1", typeof(OauthScope).Name+"Id");
			TestUtil.CheckParam(pScripted.Params, "_TP2", typeof(RootContainsOauthScope).Name);
			TestUtil.CheckParam(pScripted.Params, "_TP3", typeof(App).Name);
			TestUtil.CheckParam(pScripted.Params, "_TP4", typeof(OauthScopeUsesApp).Name);
			TestUtil.CheckParam(pScripted.Params, "_TP5", typeof(User).Name);
			TestUtil.CheckParam(pScripted.Params, "_TP6", typeof(OauthScopeUsesUser).Name);
			
			return vAddScopeResult;
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public virtual void UpdateSuccess(bool pViaTask) {
			OauthScope result = TestGo(pViaTask);

			vUsageMap.AssertUses(AddScope.Query.UpdateScope+"", 1);
			vUsageMap.AssertUses(AddScope.Query.AddScopeTx+"", 0);
			Assert.AreEqual(vScopeResult, result, "Incorrect Result.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public virtual void AddScopeSuccess(bool pViaTask) {
			vScopeResult = null;
			
			OauthScope result = TestGo(pViaTask);
			
			vUsageMap.AssertUses(AddScope.Query.UpdateScope+"", 1);
			vUsageMap.AssertUses(AddScope.Query.AddScopeTx+"", 1);
			Assert.AreEqual(vAddScopeResult, result, "Incorrect Result.");
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(-1)]
		public virtual void ErrAppId(long pAppId) {
			vAppId = pAppId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(-1)]
		public virtual void ErrUserId(long pUserId) {
			vUserId = pUserId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

	}

}