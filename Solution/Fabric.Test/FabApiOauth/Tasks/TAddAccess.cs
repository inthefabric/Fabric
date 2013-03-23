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
	public class TAddAccess {

		private readonly static string QueryClearTokens =
			"g.V('AppId',{{AppId}}L)[0]"+
			".inE('"+typeof(OauthAccessUsesApp).Name+"').outV"+
				".has('Token',Tokens.T.neq,null)"+
				".has('IsClientOnly',Tokens.T.eq,false)"+
				".as('step5')" +
			".outE('"+typeof(OauthAccessUsesUser).Name+"').inV" +
				".has('"+typeof(User).Name+"Id',Tokens.T.eq,{{UserId}})" +
			".back('step5')" +
				".sideEffect{it.setProperty('Token','');it.setProperty('Refresh','')};";

		private readonly static string QueryClearTokensClientOnly =
			"g.V('AppId',{{AppId}}L)[0]"+
			".inE('"+typeof(OauthAccessUsesApp).Name+"').outV"+
				".has('Token',Tokens.T.neq,null)"+
				".has('IsClientOnly',Tokens.T.eq,true)"+
				".sideEffect{it.setProperty('Token','');it.setProperty('Refresh','')};";

		private readonly static string QueryAddAccessTx =
			"g.V('RootId',0)[0]"+
				".each{_V0=g.v(it)};"+
			"_V1=g.addVertex(["+
				typeof(OauthAccess).Name+"Id:{{OauthAccessId}}L,"+
				"Token:'{{Token}}',"+
				"Refresh:'{{Refresh}}',"+
				"Expires:{{UtcExpireTicks}}L,"+
				"IsClientOnly:false"+
			"]);"+
			"g.addEdge(_V0,_V1,'"+typeof(RootContainsOauthAccess).Name+"');"+
			"g.V('"+typeof(App).Name+"Id',{{AppId}}L)[0]"+
				".each{_V2=g.v(it)};"+
			"g.addEdge(_V1,_V2,'"+typeof(OauthAccessUsesApp).Name+"');"+
			"g.V('"+typeof(User).Name+"Id',{{UserId}})[0]"+
				".each{_V3=g.v(it)};"+
			"g.addEdge(_V1,_V3,'"+typeof(OauthAccessUsesUser).Name+"');";

		private readonly static string QueryAddAccessTxClientOnly =
			"g.V('RootId',0)[0]"+
				".each{_V0=g.v(it)};"+
			"_V1=g.addVertex(["+
				typeof(OauthAccess).Name+"Id:{{OauthAccessId}}L,"+
				"Token:'{{Token}}',"+
				"Refresh:'{{Refresh}}',"+
				"Expires:{{UtcExpireTicks}}L,"+
				"IsClientOnly:true"+
			"]);"+
			"g.addEdge(_V0,_V1,'"+typeof(RootContainsOauthAccess).Name+"');"+
			"g.V('"+typeof(App).Name+"Id',{{AppId}}L)[0]"+
				".each{_V2=g.v(it)};"+
			"g.addEdge(_V1,_V2,'"+typeof(OauthAccessUsesApp).Name+"');";

		protected long vAddOauthAccessId;
		protected DateTime vUtcNow;
		protected long vAppId;
		protected long? vUserId;
		protected int vExpireSec;
		protected bool vClientOnly;
		protected int vCode32Count;
		protected string vTokenCode;
		protected string vRefreshCode;

		protected Mock<IApiContext> vMockCtx;
		protected UsageMap vUsageMap;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public virtual void SetUp() {
			vAddOauthAccessId = 123456789;
			vUtcNow = DateTime.UtcNow;
			vAppId = 99;
			vUserId = 1234;
			vExpireSec = 3600;
			vClientOnly = false;
			vCode32Count = 0;
			vTokenCode = "12345678901234567890123456789012";
			vRefreshCode = "abcd5678901234567890123456789012";

			vUsageMap = new UsageMap();

			vMockCtx = new Mock<IApiContext>();
			vMockCtx.Setup(x => x.GetSharpflakeId<OauthAccess>()).Returns(vAddOauthAccessId);
			vMockCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
			vMockCtx.SetupGet(x => x.Code32).Returns(GetCode32);
			
			vMockCtx
				.Setup(x => x.DbData(AddAccess.Query.ClearTokens+"", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverScript ws) => ClearTokens(ws));
			
			vMockCtx
				.Setup(x => x.DbData(AddAccess.Query.AddAccessTx+"", It.IsAny<IWeaverScript>()))
				.Returns((string s, IWeaverScript ws) => AddAccessTx(ws));
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().AddAccess(
					vAppId, vUserId, vExpireSec, vClientOnly, vMockCtx.Object);
			}

			var task = new AddAccess(vAppId, vUserId, vExpireSec, vClientOnly);
			return task.Go(vMockCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private ApiDataAccess ClearTokens(IWeaverScript pScripted) {
			TestUtil.LogWeaverScript(pScripted);
			vUsageMap.Increment(AddAccess.Query.ClearTokens+"");
			
			string expect = (vClientOnly ? QueryClearTokensClientOnly : QueryClearTokens)
				.Replace("{{AppId}}", vAppId+"")
				.Replace("{{UserId}}", (vUserId == null ? "null" : vUserId+"L"));

			Assert.AreEqual(expect, pScripted.Script, "Incorrect Query.Script.");
			return null;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private ApiDataAccess AddAccessTx(IWeaverScript pScripted) {
			TestUtil.LogWeaverScript(pScripted);
			vUsageMap.Increment(AddAccess.Query.AddAccessTx+"");

			string expect = (vClientOnly ? QueryAddAccessTxClientOnly : QueryAddAccessTx)
				.Replace("{{OauthAccessId}}", vAddOauthAccessId+"")
				.Replace("{{UtcExpireTicks}}", vUtcNow.AddSeconds(vExpireSec).Ticks+"")
				.Replace("{{AppId}}", vAppId+"")
				.Replace("{{UserId}}", (vUserId == null ? "null" : vUserId+"L"))
				.Replace("{{Token}}", vTokenCode)
				.Replace("{{Refresh}}", vRefreshCode);

			Assert.AreEqual(expect, pScripted.Script, "Incorrect Query.Script.");
			return null;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private string GetCode32() {
			switch ( vCode32Count++ ) {
				case 0: return vTokenCode;
				case 1: return vRefreshCode;
			}

			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true, true)]
		[TestCase(true, false)]
		[TestCase(false, true)]
		[TestCase(false, false)]
		public virtual void Success(bool pClientOnly, bool pViaTask) {
			vClientOnly = pClientOnly;
			
			if ( vClientOnly ) {
				vUserId = null;
			}
									
			FabOauthAccess result = TestGo(pViaTask);

			vUsageMap.AssertUses(AddAccess.Query.ClearTokens+"", 1);
			vUsageMap.AssertUses(AddAccess.Query.AddAccessTx+"", 1);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vTokenCode, result.AccessToken, "Incorrect Result.AccessToken.");
			Assert.AreEqual(vRefreshCode, result.RefreshToken, "Incorrect Result.RefreshToken.");
			Assert.AreEqual("bearer", result.TokenType, "Incorrect Result.TokenType.");
			Assert.AreEqual(3600, result.ExpiresIn, "Incorrect Result.ExpiresIn.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public virtual void ErrAppId() {
			vAppId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(false, null)]
		[TestCase(false, 0L)]
		[TestCase(true, 1L)]
		[TestCase(true, 0L)]
		[TestCase(true, -1L)]
		public virtual void ErrUserId(bool pIsClientOnly, long? pUserId) {
			vClientOnly = pIsClientOnly;
			vUserId = pUserId;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

	}

}