using System;
using Fabric.Api.Dto.Oauth;
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

		private readonly static string QueryUpdateGrant =
			"g.idx(_P0).get('"+typeof(User).Name+"Id',{{UserId}}L)[0]"+
			".inE('"+typeof(OauthGrantUsesUser).Name+"').outV"+
				".as('step3')"+
			".outE('"+typeof(OauthGrantUsesApp).Name+"').inV"+
				".has('"+typeof(App).Name+"Id',Tokens.T.eq,{{AppId}}L)"+
			".back('step3')"+
				".each{"+
					"it.RedirectUri=_P1;"+
					"it.Expires={{ExpireTicks}}L;"+
					"it.Code=_P2"+
				"};";

		private readonly static string QueryAddGrantTx =
			"g.startTransaction();"+
				"_V0=g.v(0);"+
				"_V1=g.addVertex(["+
					typeof(OauthGrant).Name+"Id:{{OauthGrantId}}L,"+
					"RedirectUri:_TP0,"+
					"Code:_TP1,"+
					"Expires:{{ExpireTicks}}L"+
				"]);"+
				"g.idx(_TP2).put(_TP3,_V1."+typeof(OauthGrant).Name+"Id,_V1);"+
				"g.addEdge(_V0,_V1,_TP4);"+
				"_V2=g.idx(_TP5).get('"+typeof(App).Name+"Id',{{AppId}}L)[0];"+
				"g.addEdge(_V1,_V2,_TP6);"+
				"_V3=g.idx(_TP7).get('"+typeof(User).Name+"Id',{{UserId}}L)[0];"+
				"g.addEdge(_V1,_V3,_TP8);"+
			"g.stopTransaction(TransactionalGraph.Conclusion.SUCCESS);";

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
					AddGrant.Query.UpdateGrant+"", It.IsAny<IWeaverQuery>()))
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
			vUsageMap.Increment(AddGrant.Query.UpdateGrant+"");
			
			string expect = QueryUpdateGrant
				.Replace("{{AppId}}", vAppId+"")
				.Replace("{{UserId}}", vUserId+"")
				.Replace("{{ExpireTicks}}", vUtcNow.AddMinutes(2).Ticks+"");

			Assert.AreEqual(expect, pScripted.Script, "Incorrect Query.Script.");
			
			//TODO: TAddGrant: quoted values seems like a bug
			TestUtil.CheckParam(pScripted.Params, "_P0", typeof(User).Name);
			TestUtil.CheckParam(pScripted.Params, "_P1", "'"+vRedirUri+"'");
			TestUtil.CheckParam(pScripted.Params, "_P2", "'"+vGrantCode+"'");
			
			return vGrantResult;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private ApiDataAccess AddGrantTx(IWeaverScript pScripted) {
			TestUtil.LogWeaverScript(pScripted);
			vUsageMap.Increment(AddGrant.Query.AddGrantTx+"");

			string expect = QueryAddGrantTx
				.Replace("{{OauthGrantId}}", vAddOauthGrantId+"")
				.Replace("{{AppId}}", vAppId+"")
				.Replace("{{UserId}}", vUserId+"")
				.Replace("{{ExpireTicks}}", vUtcNow.AddMinutes(2).Ticks+"");

			Assert.AreEqual(expect, pScripted.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pScripted.Params, "_TP0", vRedirUri);
			TestUtil.CheckParam(pScripted.Params, "_TP1", vGrantCode);
			TestUtil.CheckParam(pScripted.Params, "_TP2", typeof(OauthGrant).Name);
			TestUtil.CheckParam(pScripted.Params, "_TP3", typeof(OauthGrant).Name+"Id");
			TestUtil.CheckParam(pScripted.Params, "_TP4", typeof(RootContainsOauthGrant).Name);
			TestUtil.CheckParam(pScripted.Params, "_TP5", typeof(App).Name);
			TestUtil.CheckParam(pScripted.Params, "_TP6", typeof(OauthGrantUsesApp).Name);
			TestUtil.CheckParam(pScripted.Params, "_TP7", typeof(User).Name);
			TestUtil.CheckParam(pScripted.Params, "_TP8", typeof(OauthGrantUsesUser).Name);
			
			return null;
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public virtual void UpdateSuccess(bool pViaTask) {
			string result = TestGo(pViaTask);

			vUsageMap.AssertUses(AddGrant.Query.UpdateGrant+"", 1);
			vUsageMap.AssertUses(AddGrant.Query.AddGrantTx+"", 0);
			Assert.AreEqual(vGrantCode, result, "Incorrect Result.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public virtual void AddGrantSuccess(bool pViaTask) {
			vGrantResult = null;
			
			string result = TestGo(pViaTask);
			
			vUsageMap.AssertUses(AddGrant.Query.UpdateGrant+"", 1);
			vUsageMap.AssertUses(AddGrant.Query.AddGrantTx+"", 1);
			Assert.AreEqual(vGrantCode, result, "Incorrect Result.");
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