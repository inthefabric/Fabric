using System;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TAddGrant {

		private const string QueryUpdateGrantTx =
			"g.V('"+PropDbName.User_UserId+"',_TP)"+
			".inE('"+RelDbName.OauthGrantUsesUser+"').outV"+
				".as('step3')"+
			".outE('"+RelDbName.OauthGrantUsesApp+"').inV"+
				".has('"+PropDbName.App_AppId+"',Tokens.T.eq,_TP)"+
			".back('step3')"+
				".sideEffect{"+
					"it.setProperty('"+PropDbName.OauthGrant_RedirectUri+"',_TP);"+
					"it.setProperty('"+PropDbName.OauthGrant_Expires+"',_TP);"+
					"it.setProperty('"+PropDbName.OauthGrant_Code+"',_TP)"+
				"};";

		private const string QueryAddGrantTx =
			"_V0=g.addVertex(["+
				PropDbName.OauthGrant_OauthGrantId+":_TP,"+
				PropDbName.OauthGrant_RedirectUri+":_TP,"+
				PropDbName.OauthGrant_Code+":_TP,"+
				PropDbName.OauthGrant_Expires+":_TP,"+
				PropDbName.Node_FabType+":_TP"+
			"]);"+
			"_V1=g.V('"+PropDbName.App_AppId+"',_TP).next();"+
			"g.addEdge(_V0,_V1,_TP);"+
			"_V2=g.V('"+PropDbName.User_UserId+"',_TP).next();"+
			"g.addEdge(_V0,_V2,_TP);";

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


			string expect = TestUtil.InsertParamIndexes(QueryUpdateGrantTx, "_TP");
			Assert.AreEqual(expect, pScripted.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(pScripted.Params, "_TP", new object[] {
				vUserId,
				vAppId,
				vRedirUri,
				vUtcNow.AddMinutes(2).Ticks,
				vGrantCode
			});
			
			return vGrantResult;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private ApiDataAccess AddGrantTx(IWeaverScript pScripted) {
			TestUtil.LogWeaverScript(pScripted);
			vUsageMap.Increment(AddGrant.Query.AddGrantTx+"");

			string expect = TestUtil.InsertParamIndexes(QueryAddGrantTx, "_TP");
			Assert.AreEqual(expect, pScripted.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(pScripted.Params, "_TP", new object[] {
				vAddOauthGrantId,
				vRedirUri,
				vGrantCode,
				vUtcNow.AddMinutes(2).Ticks,
				(int)NodeFabType.OauthGrant,
				vAppId,
				RelDbName.OauthGrantUsesApp,
				vUserId,
				RelDbName.OauthGrantUsesUser
			});
			
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