using System;
using System.Collections.Generic;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetAccessToken {

		private readonly static string QueryGetAccessTx = 
			"_V0=[];"+
			"g.V('RootId',0)[0]"+
				".outE('"+typeof(RootContainsOauthAccess).Name+"').inV"+
					".has('Token',Tokens.T.eq,_TP0)"+
					".has('Expires',Tokens.T.gt,{{UtcNowTicks}}L)"+
					".aggregate(_V0)"+
					".as('step6')"+
				".outE('"+typeof(OauthAccessUsesApp).Name+"').inV"+
					".aggregate(_V0)"+
				".back('step6')"+
				".outE('"+typeof(OauthAccessUsesUser).Name+"').inV"+
					".aggregate(_V0)"+
					".iterate();"+
			"_V0;";

		private string vToken;
		private DateTime vUtcNow;
		private Mock<IApiContext> vMockCtx;
		private Mock<IApiDataAccess> vMockGetAccessTxResult;
		private OauthAccess vResultAccess;
		private App vResultApp;
		private User vResultUser;
		private List<IDbDto> vResultList2;
		private List<IDbDto> vResultList3;
		private UsageMap vUsageMap;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vToken = "abcdefghijklmnopqrstuvwxyz789012";
			vUtcNow = DateTime.UtcNow;
			vUsageMap = new UsageMap();

			vResultAccess = new OauthAccess();
			vResultAccess.Token = vToken;
			vResultAccess.Refresh = FabricUtil.Code32;

			vResultApp = new App();
			vResultApp.AppId = 456;

			vResultUser = new User();
			vResultUser.UserId = 9878;

			//TODO: build utility for creating DataAccess results

			var mockGrantDbDto = new Mock<IDbDto>();
			mockGrantDbDto.Setup(x => x.ToNode<OauthAccess>()).Returns(vResultAccess);

			var mockAppDbDto = new Mock<IDbDto>();
			mockAppDbDto.Setup(x => x.ToNode<App>()).Returns(vResultApp);

			var mockUserDbDto = new Mock<IDbDto>();
			mockUserDbDto.Setup(x => x.ToNode<User>()).Returns(vResultUser);

			vResultList2 = new List<IDbDto>();
			vResultList2.Add(mockGrantDbDto.Object);
			vResultList2.Add(mockAppDbDto.Object);

			vResultList3 = new List<IDbDto>();
			vResultList3.Add(mockGrantDbDto.Object);
			vResultList3.Add(mockAppDbDto.Object);
			vResultList3.Add(mockUserDbDto.Object);

			vMockGetAccessTxResult = new Mock<IApiDataAccess>();
			vMockGetAccessTxResult.SetupGet(x => x.ResultDtoList).Returns(vResultList3);

			vMockCtx = new Mock<IApiContext>();
			vMockCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);

			vMockCtx
				.Setup(x => x.DbData(
					GetAccessToken.Query.GetAccessTx+"", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction tx) => GetAccess(tx));
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
			string expect = QueryGetAccessTx
				.Replace("{{UtcNowTicks}}", vUtcNow.Ticks+"");

			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", vToken);

			return vMockGetAccessTxResult.Object;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pViaTask) {
			FabOauthAccess result = TestGo(pViaTask);

			CheckSuccessResult(result);
			Assert.AreEqual(vResultUser.UserId, result.UserId, "Incorrect Result.UserId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void SuccessNoUser(bool pViaTask) {
			vMockGetAccessTxResult.SetupGet(x => x.ResultDtoList).Returns(vResultList2);

			FabOauthAccess result = TestGo(pViaTask);

			CheckSuccessResult(result);
			Assert.Null(result.UserId, "Result.UserId should be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(null)]
		[TestCase(0)]
		public void NotFound(int? pLen) {
			IList<IDbDto> list = null;
			if ( pLen == 0 ) { list = new List<IDbDto>(); }
			vMockGetAccessTxResult.SetupGet(x => x.ResultDtoList).Returns(list);

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
			TestUtil.CheckThrows<FabArgumentFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void CheckSuccessResult(FabOauthAccess pResult) {
			vUsageMap.AssertUses(GetAccessToken.Query.GetAccessTx+"", 1);
			Assert.NotNull(pResult, "Result should be filled.");
			Assert.AreEqual(vToken, pResult.AccessToken, "Incorrect Result.AccessToken.");
			Assert.AreEqual(vResultAccess.Refresh, pResult.RefreshToken,
				"Incorrect Result.RefreshToken.");
			Assert.AreEqual("bearer", pResult.TokenType, "Incorrect Result.TokenType.");
			Assert.AreEqual(3600, pResult.ExpiresIn, "Incorrect Result.ExpiresIn.");
			Assert.AreEqual(vResultApp.AppId, pResult.AppId, "Incorrect Result.AppId.");
		}

	}

}