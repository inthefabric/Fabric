using System;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure;
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
	public class TGetAccessToken {

		private const string QueryGetAccessTx = 
			"_V0=[];"+
			"g.V('"+PropDbName.Node_FabType+"',_TP)"+
				".has('"+PropDbName.OauthAccess_Token+"',Tokens.T.eq,_TP)"+
				".has('"+PropDbName.OauthAccess_Expires+"',Tokens.T.gt,_TP)"+
				".aggregate(_V0)"+
				".as('step4')"+
			".outE('"+RelDbName.OauthAccessUsesApp+"').inV"+
				".aggregate(_V0)"+
			".back('step4')"+
			".outE('"+RelDbName.OauthAccessUsesUser+"').inV"+
				".aggregate(_V0)"+
				".iterate();"+
			"_V0;";

		private string vToken;
		private DateTime vUtcNow;
		private int vExpiresInSec;
		private Mock<IApiContext> vMockCtx;
		private Mock<IMemCache> vMockMemCache;
		private Mock<IApiDataAccess> vMockGetAccessTxResult;
		private OauthAccess vResultAccess;
		private App vResultApp;
		private User vResultUser;
		private UsageMap vUsageMap;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vToken = "abcdefghijklmnopqrstuvwxyz789012";
			vUtcNow = DateTime.UtcNow;
			vExpiresInSec = 1000;
			vUsageMap = new UsageMap();

			vResultAccess = new OauthAccess();
			vResultAccess.Token = vToken;
			vResultAccess.Refresh = FabricUtil.Code32;
			vResultAccess.Expires = vUtcNow.AddSeconds(vExpiresInSec).Ticks;

			vResultApp = new App();
			vResultApp.ArtifactId = 456;

			vResultUser = new User();
			vResultUser.ArtifactId = 9878;

			vMockGetAccessTxResult = new Mock<IApiDataAccess>();
			vMockGetAccessTxResult.Setup(x => x.GetResultAt<OauthAccess>(0)).Returns(vResultAccess);
			vMockGetAccessTxResult.Setup(x => x.GetResultAt<App>(1)).Returns(vResultApp);
			vMockGetAccessTxResult.Setup(x => x.GetResultAt<User>(2)).Returns(vResultUser);
			vMockGetAccessTxResult.Setup(x => x.GetResultCount()).Returns(3);

			vMockCtx = new Mock<IApiContext>();
			vMockCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);

			vMockCtx
				.Setup(x => x.DbData(
					GetAccessToken.Query.GetAccessTx+"", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction tx) => GetAccess(tx));

			var mockCacheMan = new Mock<ICacheManager>();
			vMockCtx.SetupGet(x => x.Cache).Returns(mockCacheMan.Object);

			vMockMemCache = new Mock<IMemCache>();
			mockCacheMan.SetupGet(x => x.Memory).Returns(vMockMemCache.Object);
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().GetAccessToken(vToken, vMockCtx.Object);
			}

			var task = new GetAccessToken(vToken);
			return task.Go(vMockCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess GetAccess(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			vUsageMap.Increment(GetAccessToken.Query.GetAccessTx+"");

			string expect = TestUtil.InsertParamIndexes(QueryGetAccessTx, "_TP");
			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(pTx.Params, "_TP", new object[] {
				(int)NodeFabType.OauthAccess,
				vToken,
				vUtcNow.Ticks
			});

			return vMockGetAccessTxResult.Object;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pViaTask) {
			FabOauthAccess result = TestGo(pViaTask);

			CheckSuccessResult(result);
			vUsageMap.AssertUses(GetAccessToken.Query.GetAccessTx+"", 1);
			Assert.AreEqual(vResultUser.ArtifactId, result.UserId, "Incorrect Result.UserId.");

			vMockMemCache.Verify(
				x => x.AddOauthAccess(
					vToken,
					It.Is<Tuple<OauthAccess, long, long?>>(tuple =>
						tuple.Item1 == vResultAccess && 
						tuple.Item2 == vResultApp.ArtifactId &&
						tuple.Item3 == vResultUser.ArtifactId
					),
					It.Is<int>(exp => exp == vExpiresInSec)
				)
			);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void SuccessNoUser(bool pViaTask) {
			vMockGetAccessTxResult.Setup(x => x.GetResultCount()).Returns(2);

			FabOauthAccess result = TestGo(pViaTask);

			CheckSuccessResult(result);
			vUsageMap.AssertUses(GetAccessToken.Query.GetAccessTx+"", 1);
			Assert.Null(result.UserId, "Result.UserId should be null.");

			vMockMemCache.Verify(
				x => x.AddOauthAccess(
					vToken,
					It.Is<Tuple<OauthAccess, long, long?>>(tuple => 
						tuple.Item1 == vResultAccess && 
						tuple.Item2 == vResultApp.ArtifactId &&
						tuple.Item3 == null
					),
					It.Is<int>(exp => exp == vExpiresInSec)
				)
			);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void SuccessCache(bool pViaTask) {
			var tuple = new Tuple<OauthAccess, long, long?>(
				vResultAccess, vResultApp.ArtifactId, vResultUser.ArtifactId);
			vMockMemCache.Setup(x => x.FindOauthAccess(vToken)).Returns(tuple);

			FabOauthAccess result = TestGo(pViaTask);

			CheckSuccessResult(result);
			vUsageMap.AssertUses(GetAccessToken.Query.GetAccessTx+"", 0);
			Assert.AreEqual(vResultUser.ArtifactId, result.UserId, "Incorrect Result.UserId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(-1)]
		[TestCase(0)]
		public void NotFound(int pCount) {
			vMockGetAccessTxResult.Setup(x => x.GetResultCount()).Returns(pCount);

			FabOauthAccess result = TestGo();

			vUsageMap.AssertUses(GetAccessToken.Query.GetAccessTx+"", 1);
			Assert.Null(result, "Result should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNullToken() {
			vToken = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("")]
		[TestCase("x")]
		[TestCase("1234567890123456789012345678901")]
		[TestCase("123456789012345678901234567890123")]
		public void ErrTokenLen(string pToken) {
			vToken = pToken;
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("1234567890123456789012345678901_")]
		[TestCase("123456789 1234567890123456789012")]
		public void ErrTokenChars(string pToken) {
			vToken = pToken;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void CheckSuccessResult(FabOauthAccess pResult) {
			Assert.NotNull(pResult, "Result should be filled.");
			Assert.AreEqual(vToken, pResult.AccessToken, "Incorrect Result.AccessToken.");
			Assert.AreEqual(vResultAccess.Refresh, pResult.RefreshToken,
				"Incorrect Result.RefreshToken.");
			Assert.AreEqual("bearer", pResult.TokenType, "Incorrect Result.TokenType.");
			Assert.AreEqual(vExpiresInSec, pResult.ExpiresIn, "Incorrect Result.ExpiresIn.");
			Assert.AreEqual(vResultApp.ArtifactId, pResult.AppId, "Incorrect Result.AppId.");
		}

	}

}