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
			"g.V('"+typeof(User).Name+"Id',_TP0)[0]"+
			".inE('"+typeof(OauthScopeUsesUser).Name+"').outV"+
				".as('step3')"+
			".outE('"+typeof(OauthScopeUsesApp).Name+"').inV"+
				".has('"+typeof(App).Name+"Id',Tokens.T.eq,_TP1)"+
			".back('step3')"+
				".sideEffect{"+
					"it.setProperty('Allow',_TP2);"+
					"it.setProperty('Created',_TP3)"+
				"};";

		private readonly static string QueryAddScopeTx =
			"_V0=g.V('RootId',_TP0)[0].next();"+
			"_V1=g.addVertex(["+
				typeof(OauthScope).Name+"Id:_TP1,"+
				"Allow:_TP2,"+
				"Created:_TP3,"+
				"FabType:_TP4"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP5);"+
			"_V2=g.V('"+typeof(App).Name+"Id',_TP6)[0].next();"+
			"g.addEdge(_V1,_V2,_TP7);"+
			"_V3=g.V('"+typeof(User).Name+"Id',_TP8)[0].next();"+
			"g.addEdge(_V1,_V3,_TP9);"+
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

			Assert.AreEqual(QueryUpdateScopeTx, pScripted.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pScripted.Params, "_TP0", vUserId);
			TestUtil.CheckParam(pScripted.Params, "_TP1", vAppId);
			TestUtil.CheckParam(pScripted.Params, "_TP2", vAllow);
			TestUtil.CheckParam(pScripted.Params, "_TP3", vUtcNow.Ticks);
			
			return vScopeResult;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private OauthScope AddScopeTx(IWeaverScript pScripted) {
			TestUtil.LogWeaverScript(pScripted);
			vUsageMap.Increment(AddScope.Query.AddScopeTx+"");

			Assert.AreEqual(QueryAddScopeTx, pScripted.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pScripted.Params, "_TP0", 0);
			TestUtil.CheckParam(pScripted.Params, "_TP1", vAddOauthScopeId);
			TestUtil.CheckParam(pScripted.Params, "_TP2", vAllow);
			TestUtil.CheckParam(pScripted.Params, "_TP3", vUtcNow.Ticks);
			TestUtil.CheckParam(pScripted.Params, "_TP4", (int)NodeFabType.OauthScope);
			TestUtil.CheckParam(pScripted.Params, "_TP6", vAppId);
			TestUtil.CheckParam(pScripted.Params, "_TP7", typeof(OauthScopeUsesApp).Name);
			TestUtil.CheckParam(pScripted.Params, "_TP8", vUserId);
			TestUtil.CheckParam(pScripted.Params, "_TP9", typeof(OauthScopeUsesUser).Name);
			
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
		[Test]
		public virtual void ErrAppId() {
			vAppId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public virtual void ErrUserId() {
			vUserId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

	}

}