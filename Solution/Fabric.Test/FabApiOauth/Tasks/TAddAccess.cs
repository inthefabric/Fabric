using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure;
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

		private static string[] Queries = new [] {
			//ClearTokens
			"g.v(0)"+
			".outE('RootContainsOauthAccess').inV"+
				".has('Token',Tokens.T.neq,null)"+
				".as('step4')" +
			".outE('OauthAccessUsesApp')[0].inV(0)" +
				".has('AppId',Tokens.T.eq,{{AppId}}L)" +
			".back('step4')" +
			".outE('OauthAccessUsesUser')[0].inV(0)" +
				".has('UserId',Tokens.T.eq,{{UserId}})" +
			".back('step4')" +
				".each{it.Token=null};",

			//AddAccessTx
			"g.startTransaction();"+
			"_var0=g.addVertex(["+
				"OauthAccessId:{{OauthAccessId}}L,"+
				"Token:_TP0,"+
				"Refresh:_TP1,"+
				"Expires:{{UtcExpireTicks}}L,"+
				"IsClientOnly:false"+
			"]);"+
			"g.idx(_TP2).put(_TP3,_var0.OauthAccessId,_var0);"+
			"_var1=g.v(0);"+
			"g.addEdge(_var1,_var0,_TP4);"+
			"_var2=g.idx(_TP5).get('AppId',99L);"+
			"g.addEdge(_var0,_var2,_TP6);"+
			"_var3=g.idx(_TP7).get('UserId',1234L);"+
			"g.addEdge(_var0,_var3,_TP8);"+
			"g.stopTransaction(TransactionalGraph.Conclusion.SUCCESS);"
		};
		
		protected long vAppId;
		protected long? vUserId;
		protected int vExpireSec;
		protected bool vClientOnly;

		protected Mock<IApiContext> vMockCtx;

		protected OauthAccess vAddAccessResult;
		protected UsageMap vUsageMap;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public virtual void SetUp() {
			vAppId = 99;
			vUserId = 1234;
			vExpireSec = 3600;
			vClientOnly = false;

			vAddAccessResult = new OauthAccess();
			vAddAccessResult.Id = 8585;
			vAddAccessResult.Token = "12345678901234567890123456789012";
			vAddAccessResult.Refresh = "abcd5678901234567890123456789012";

			vUsageMap = new UsageMap();

			vMockCtx = new Mock<IApiContext>();
			
			vMockCtx
				.Setup(x => x.DbData(
					AddAccess.Query.ClearTokens+"", It.IsAny<IWeaverQuery>()))
					.Returns((string s, IWeaverScript ws) => ClearTokens(ws));
			
			vMockCtx
				.Setup(x => x.DbData(
					AddAccess.Query.AddAccessTx+"", It.IsAny<IWeaverScript>()))
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
			
			string expect = Queries[(int)AddAccess.Query.ClearTokens]
				.Replace("{{AppId}}", vAppId+"")
				.Replace("{{UserId}}", (vUserId == null ? "null" : vUserId+"L"));

			Assert.AreEqual(expect, pScripted.Script, "Incorrect Query.Script.");
			return null;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private ApiDataAccess AddAccessTx(IWeaverScript pScripted) {
			TestUtil.LogWeaverScript(pScripted);
			vUsageMap.Increment(AddAccess.Query.AddAccessTx+"");

			Log.Debug("\n"+new ApiDataAccess(null, pScripted).Query);

			string expect = Queries[(int)AddAccess.Query.AddAccessTx]
				.Replace("{{AppId}}", vAppId+"");

			Assert.AreEqual(expect, pScripted.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pScripted.Params, "_P0", typeof(App).Name);
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
			Assert.AreEqual(vAddAccessResult.Token, result.AccessToken,
				"Incorrect Result.AccessToken.");
			Assert.AreEqual(vAddAccessResult.Refresh, result.RefreshToken,
				"Incorrect Result.RefreshToken.");
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