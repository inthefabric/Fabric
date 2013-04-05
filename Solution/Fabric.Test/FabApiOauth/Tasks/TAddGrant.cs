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
	public class TAddGrant {

		private readonly static string QueryUpdateGrantTx =
			"g.V('"+typeof(User).Name+"Id',_TP0)[0]"+
			".inE('"+typeof(OauthGrantUsesUser).Name+"').outV"+
				".as('step3')"+
			".outE('"+typeof(OauthGrantUsesApp).Name+"').inV"+
				".has('"+typeof(App).Name+"Id',Tokens.T.eq,_TP1)"+
			".back('step3')"+
				".sideEffect{"+
					"it.setProperty('RedirectUri',_TP2);"+
					"it.setProperty('Expires',_TP3);"+
					"it.setProperty('Code',_TP4)"+
				"};";

		private readonly static string QueryAddGrantTx =
			"_V0=g.V('RootId',_TP0)[0].next();"+
			"_V1=g.addVertex(["+
				typeof(OauthGrant).Name+"Id:_TP1,"+
				"RedirectUri:_TP2,"+
				"Code:_TP3,"+
				"Expires:_TP4,"+
				"FabType:_TP5"+
			"]);"+
			"g.addEdge(_V0,_V1,_TP6);"+
			"_V2=g.V('"+typeof(App).Name+"Id',_TP7)[0].next();"+
			"g.addEdge(_V1,_V2,_TP8);"+
			"_V3=g.V('"+typeof(User).Name+"Id',_TP9)[0].next();"+
			"g.addEdge(_V1,_V3,_TP10);";

		protected long vAppId;
		protected long vUserId;
		protected string vRedirUri;
		protected string vGrantCode;
		protected DateTime vUtcNow;
		protected long vAddOauthGrantId;
		private OauthGrant vGrantResult;
		protected Mock<IApiContext> vMockCtx;
		protected UsageMap vUsageMap;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public virtual void SetUp() {
			vAppId = 99;
			vUserId = 1234;
			vRedirUri = "http://www.test.com/oauth";
			vGrantCode = "12345678901234567890123456789012";
			vUtcNow = DateTime.UtcNow;
			vAddOauthGrantId = 123456789;
			vUsageMap = new UsageMap();
			
			vGrantResult = new OauthGrant();
			vGrantResult.Code = vGrantCode;

			vMockCtx = new Mock<IApiContext>();
			vMockCtx.Setup(x => x.GetSharpflakeId<OauthGrant>()).Returns(vAddOauthGrantId);
			vMockCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
			vMockCtx.SetupGet(x => x.Code32).Returns(vGrantCode);
			
			vMockCtx
				.Setup(x => x.DbSingle<OauthGrant>(
					AddGrant.Query.UpdateGrantTx+"", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverScript ws) => UpdateGrant(ws));
			
			vMockCtx
				.Setup(x => x.DbData(AddGrant.Query.AddGrantTx+"", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverScript ws) => AddGrantTx(ws));
		}

		/*--------------------------------------------------------------------------------------------*/
		private string TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().AddGrant(vAppId, vUserId, vRedirUri, vMockCtx.Object);
			}

			var task = new AddGrant(vAppId, vUserId, vRedirUri);
			return task.Go(vMockCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private OauthGrant UpdateGrant(IWeaverScript pScripted) {
			TestUtil.LogWeaverScript(pScripted);
			vUsageMap.Increment(AddGrant.Query.UpdateGrantTx+"");
			

			Assert.AreEqual(QueryUpdateGrantTx, pScripted.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pScripted.Params, "_TP0", vUserId);
			TestUtil.CheckParam(pScripted.Params, "_TP1", vAppId);
			TestUtil.CheckParam(pScripted.Params, "_TP2", vRedirUri);
			TestUtil.CheckParam(pScripted.Params, "_TP3", vUtcNow.AddMinutes(2).Ticks);
			TestUtil.CheckParam(pScripted.Params, "_TP4", vGrantCode);
			
			return vGrantResult;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private ApiDataAccess AddGrantTx(IWeaverScript pScripted) {
			TestUtil.LogWeaverScript(pScripted);
			vUsageMap.Increment(AddGrant.Query.AddGrantTx+"");

			Assert.AreEqual(QueryAddGrantTx, pScripted.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pScripted.Params, "_TP0", 0);
			TestUtil.CheckParam(pScripted.Params, "_TP1", vAddOauthGrantId);
			TestUtil.CheckParam(pScripted.Params, "_TP2", vRedirUri);
			TestUtil.CheckParam(pScripted.Params, "_TP3", vGrantCode);
			TestUtil.CheckParam(pScripted.Params, "_TP4", vUtcNow.AddMinutes(2).Ticks);
			TestUtil.CheckParam(pScripted.Params, "_TP5", (int)NodeFabType.OauthGrant);
			TestUtil.CheckParam(pScripted.Params, "_TP7", vAppId);
			TestUtil.CheckParam(pScripted.Params, "_TP8", typeof(OauthGrantUsesApp).Name);
			TestUtil.CheckParam(pScripted.Params, "_TP9", vUserId);
			TestUtil.CheckParam(pScripted.Params, "_TP10", typeof(OauthGrantUsesUser).Name);
			
			return null;
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public virtual void UpdateSuccess(bool pViaTask) {
			string result = TestGo(pViaTask);

			vUsageMap.AssertUses(AddGrant.Query.UpdateGrantTx+"", 1);
			vUsageMap.AssertUses(AddGrant.Query.AddGrantTx+"", 0);
			Assert.AreEqual(vGrantCode, result, "Incorrect Result.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public virtual void AddGrantSuccess(bool pViaTask) {
			vGrantResult = null;
			
			string result = TestGo(pViaTask);
			
			vUsageMap.AssertUses(AddGrant.Query.UpdateGrantTx+"", 1);
			vUsageMap.AssertUses(AddGrant.Query.AddGrantTx+"", 1);
			Assert.AreEqual(vGrantCode, result, "Incorrect Result.");
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