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
			"g.v(0)"+
			".outE('"+typeof(RootContainsOauthAccess).Name+"').inV"+
				".has('Token',Tokens.T.neq,null)"+
				".as('step4')" +
			".outE('"+typeof(OauthAccessUsesApp).Name+"')[0].inV[0]" +
				".has('"+typeof(App).Name+"Id',Tokens.T.eq,{{AppId}}L)" +
			".back('step4')" +
			".outE('"+typeof(OauthAccessUsesUser).Name+"')[0].inV[0]" +
				".has('"+typeof(User).Name+"Id',Tokens.T.eq,{{UserId}})" +
			".back('step4')" +
				".each{it.Token=null};";

		private readonly static string QueryAddAccessTx =
			"g.startTransaction();"+
			"_V0=g.v(0);"+
			"_V1=g.addVertex(["+
				typeof(OauthAccess).Name+"Id:{{OauthAccessId}}L,"+
				"Token:_TP0,"+
				"Refresh:_TP1,"+
				"Expires:{{UtcExpireTicks}}L,"+
				"IsClientOnly:false"+
			"]);"+
			"g.idx(_TP2).put(_TP3,_V1."+typeof(OauthAccess).Name+"Id,_V1);"+
			"g.addEdge(_V0,_V1,_TP4);"+
			"_V2=g.idx(_TP5).get('"+typeof(App).Name+"Id',{{AppId}}L)[0];"+
			"g.addEdge(_V1,_V2,_TP6);"+
			"_V3=g.idx(_TP7).get('"+typeof(User).Name+"Id',{{UserId}})[0];"+
			"g.addEdge(_V1,_V3,_TP8);"+
			"g.stopTransaction(TransactionalGraph.Conclusion.SUCCESS);";

		private readonly static string QueryAddAccessTxClientOnly =
			"g.startTransaction();"+
			"_V0=g.v(0);"+
			"_V1=g.addVertex(["+
				typeof(OauthAccess).Name+"Id:{{OauthAccessId}}L,"+
				"Token:_TP0,"+
				"Refresh:_TP1,"+
				"Expires:{{UtcExpireTicks}}L,"+
				"IsClientOnly:true"+
			"]);"+
			"g.idx(_TP2).put(_TP3,_V1."+typeof(OauthAccess).Name+"Id,_V1);"+
			"g.addEdge(_V0,_V1,_TP4);"+
			"_V2=g.idx(_TP5).get('"+typeof(App).Name+"Id',{{AppId}}L)[0];"+
			"g.addEdge(_V1,_V2,_TP6);"+
			"g.stopTransaction(TransactionalGraph.Conclusion.SUCCESS);";

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
				.Returns((string s, IWeaverScript ws) => AddAccessTx(ws, false));
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
			
			string expect = QueryClearTokens
				.Replace("{{AppId}}", vAppId+"")
				.Replace("{{UserId}}", (vUserId == null ? "null" : vUserId+"L"));

			Assert.AreEqual(expect, pScripted.Script, "Incorrect Query.Script.");
			return null;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private ApiDataAccess AddAccessTx(IWeaverScript pScripted, bool pClientOnly) {
			TestUtil.LogWeaverScript(pScripted);
			vUsageMap.Increment(AddAccess.Query.AddAccessTx+"");

			string expect = (pClientOnly ? QueryAddAccessTxClientOnly : QueryAddAccessTx)
				.Replace("{{OauthAccessId}}", vAddOauthAccessId+"")
				.Replace("{{UtcExpireTicks}}", vUtcNow.AddSeconds(vExpireSec).Ticks+"")
				.Replace("{{AppId}}", vAppId+"")
				.Replace("{{UserId}}", (vUserId == null ? "null" : vUserId+"L"));

			Assert.AreEqual(expect, pScripted.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pScripted.Params, "_TP0", vTokenCode);
			TestUtil.CheckParam(pScripted.Params, "_TP1", vRefreshCode);
			TestUtil.CheckParam(pScripted.Params, "_TP2", typeof(OauthAccess).Name);
			TestUtil.CheckParam(pScripted.Params, "_TP3", typeof(OauthAccess).Name+"Id");
			TestUtil.CheckParam(pScripted.Params, "_TP4", typeof(RootContainsOauthAccess).Name);
			TestUtil.CheckParam(pScripted.Params, "_TP5", typeof(App).Name);
			TestUtil.CheckParam(pScripted.Params, "_TP6", typeof(OauthAccessUsesApp).Name);

			if ( !pClientOnly ) {
				TestUtil.CheckParam(pScripted.Params, "_TP7", typeof(User).Name);
				TestUtil.CheckParam(pScripted.Params, "_TP8", typeof(OauthAccessUsesUser).Name);
			}

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

				vMockCtx
					.Setup(x => x.DbData(AddAccess.Query.AddAccessTx+"", It.IsAny<IWeaverScript>()))
					.Returns((string s, IWeaverScript ws) => AddAccessTx(ws, true));
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
		[TestCase(0)]
		[TestCase(-1)]
		public virtual void ErrAppId(long pAppId) {
			vAppId = pAppId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(false, null)]
		[TestCase(false, 0L)]
		[TestCase(false, -1L)]
		[TestCase(true, 1L)]
		[TestCase(true, 0L)]
		[TestCase(true, -1L)]
		public virtual void ErrUserId(bool pIsClientOnly, long? pUserId) {
			vClientOnly = pIsClientOnly;
			vUserId = pUserId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

	}

}