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

		private readonly static string QueryUpdateScopeTx =
			"g.V('"+typeof(User).Name+"Id',{{UserId}}L)[0]"+
				".inE('"+typeof(OauthScopeUsesUser).Name+"').outV"+
					".as('step3')"+
				".outE('"+typeof(OauthScopeUsesApp).Name+"').inV"+
					".has('"+typeof(App).Name+"Id',Tokens.T.eq,{{AppId}}L)"+
				".back('step3')"+
					".sideEffect{"+
						"it.setProperty('Allow',{{Allow}});"+
						"it.setProperty('Created',{{UtcNowTicks}}L)"+
					"};";

		private readonly static string QueryAddScopeTx =
			"g.V('RootId',0)[0]"+
				".each{_V0=g.v(it)};"+
			"_V1=g.addVertex(["+
				typeof(OauthScope).Name+"Id:{{OauthScopeId}}L,"+
				"Allow:{{Allow}},"+
				"Created:{{UtcNowTicks}}L"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP0);"+
			"g.V('"+typeof(App).Name+"Id',{{AppId}}L)[0]"+
				".each{_V2=g.v(it)};"+
			"g.addEdge(_V1,_V2,_TP1);"+
			"g.V('"+typeof(User).Name+"Id',{{UserId}}L)[0]"+
				".each{_V3=g.v(it)};"+
			"g.addEdge(_V1,_V3,_TP2);"+
			"_V1;";

		private long vAppId;
		private long vUserId;
		private bool vAllow;
		private DateTime vUtcNow;
		private long vAddOauthScopeId;
		private OauthScope vScopeResult;
		private OauthScope vAddScopeResult;
		private Mock<IApiContext> vMockCtx;
		private UsageMap vUsageMap;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
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
					AddScope.Query.UpdateScopeTx+"", It.IsAny<IWeaverTransaction>()))
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
			vUsageMap.Increment(AddScope.Query.UpdateScopeTx+"");
			
			string expect = QueryUpdateScopeTx
				.Replace("{{AppId}}", vAppId+"")
				.Replace("{{UserId}}", vUserId+"")
				.Replace("{{Allow}}", vAllow.ToString().ToLower())
				.Replace("{{UtcNowTicks}}", vUtcNow.Ticks+"");

			Assert.AreEqual(expect, pScripted.Script, "Incorrect Query.Script.");
			
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
			TestUtil.CheckParam(pScripted.Params, "_TP0", typeof(RootContainsOauthScope).Name);
			TestUtil.CheckParam(pScripted.Params, "_TP1", typeof(OauthScopeUsesApp).Name);
			TestUtil.CheckParam(pScripted.Params, "_TP2", typeof(OauthScopeUsesUser).Name);
			
			return vAddScopeResult;
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public virtual void UpdateSuccess(bool pViaTask) {
			OauthScope result = TestGo(pViaTask);

			vUsageMap.AssertUses(AddScope.Query.UpdateScopeTx+"", 1);
			vUsageMap.AssertUses(AddScope.Query.AddScopeTx+"", 0);
			Assert.AreEqual(vScopeResult, result, "Incorrect Result.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public virtual void AddScopeSuccess(bool pViaTask) {
			vScopeResult = null;
			
			OauthScope result = TestGo(pViaTask);
			
			vUsageMap.AssertUses(AddScope.Query.UpdateScopeTx+"", 1);
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