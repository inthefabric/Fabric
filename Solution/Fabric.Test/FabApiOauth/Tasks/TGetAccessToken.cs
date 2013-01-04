using System;
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
	public class TGetAccessToken {

		private readonly static string QueryGetAccess = 
			"g.v(0)"+
			".outE('"+typeof(RootContainsOauthAccess).Name+"').inV"+
				".has('Token',Tokens.T.eq,_P0)"+
				".has('Expires',Tokens.T.gt,{{UtcNowTicks}}L);";

		private string vToken;
		private DateTime vUtcNow;
		private Mock<IApiContext> vMockCtx;
		private OauthAccess vGetAccessResult;
		private UsageMap vUsageMap;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vToken = "abcdefghijklmnopqrstuvwxyz789012";
			vUtcNow = DateTime.UtcNow;
			vUsageMap = new UsageMap();
			
			vGetAccessResult = new OauthAccess();
			vGetAccessResult.Token = vToken;
			vGetAccessResult.Refresh = FabricUtil.Code32;

			vMockCtx = new Mock<IApiContext>();
			vMockCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);

			vMockCtx
				.Setup(x => x.DbSingle<OauthAccess>(
					GetAccessToken.Query.GetAccess+"", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetAccess(q));
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
		private OauthAccess GetAccess(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			vUsageMap.Increment(GetAccessToken.Query.GetAccess+"");
			string expect = QueryGetAccess
				.Replace("{{UtcNowTicks}}", vUtcNow.Ticks+"");

			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", vToken);

			return vGetAccessResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pViaTask) {
			FabOauthAccess result = TestGo(pViaTask);

			vUsageMap.AssertUses(GetAccessToken.Query.GetAccess+"", 1);
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vToken, result.AccessToken, "Incorrect Result.AccessToken.");
			Assert.AreEqual(vGetAccessResult.Refresh, result.RefreshToken,
				"Incorrect Result.RefreshToken.");
			Assert.AreEqual("bearer", result.TokenType, "Incorrect Result.TokenType.");
			Assert.AreEqual(3600, result.ExpiresIn, "Incorrect Result.ExpiresIn.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NotFound() {
			vGetAccessResult = null;

			vMockCtx
				.Setup(x => x.DbSingle<OauthAccess>(
					GetAccessToken.Query.GetAccess+"", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetAccess(q));

			FabOauthAccess result = TestGo();

			vUsageMap.AssertUses(GetAccessToken.Query.GetAccess+"", 1);
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

	}

}