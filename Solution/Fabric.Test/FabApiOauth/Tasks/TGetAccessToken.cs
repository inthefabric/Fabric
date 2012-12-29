using Moq;
using Fabric.Infrastructure.Api;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;
using NUnit.Framework;
using Weaver.Interfaces;
using Fabric.Domain;
using Fabric.Infrastructure;
using System;
using Fabric.Test.Util;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetAccessToken {

		private enum QueryIndex {
			GetSingleAccess
		}

		private static string[] vQueries = new [] {
			//GetSingleAccess
			"g.v(0)"+
			".outE('RootContainsOauthAccess').inV"+
				".has('Token',Tokens.T.eq,_P0)"+
				".has('Expires',Tokens.T.gt,{{UtcNowTicks}});"
		};

		private string vToken;
		private DateTime vUtcNow;
		private Mock<IApiContext> vMockCtx;
		private OauthAccess vSingleAccessResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vToken = "abcdefghijklmnopqrstuvwxyz789012";
			vUtcNow = DateTime.UtcNow;
			
			vSingleAccessResult = new OauthAccess();
			vSingleAccessResult.Token = vToken;
			vSingleAccessResult.Refresh = FabricUtil.Code32;

			vMockCtx = new Mock<IApiContext>();
			vMockCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);

			vMockCtx
				.Setup(x => x.DbSingle<OauthAccess>(It.IsAny<IWeaverQuery>()))
				.Returns((IWeaverQuery q) => GetSingleAccess(q, vToken, vUtcNow, vSingleAccessResult));
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess TestGo(string pToken) {
			var task = new GetAccessToken(pToken);
			return task.Go(vMockCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private OauthAccess GetSingleAccess(IWeaverQuery pQuery, string pToken, DateTime pUtcNow,
		                                    									OauthAccess pReturn) {
			TestUtil.LogQuery(pQuery);
			string expect = vQueries[(int)QueryIndex.GetSingleAccess]
				.Replace("{{UtcNowTicks}}", pUtcNow.Ticks+"L");

			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery, "_P0", pToken);

			return pReturn;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			FabOauthAccess result = TestGo(vToken);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vToken, result.AccessToken, "Incorrect Result.AccessToken.");
			Assert.AreEqual(vSingleAccessResult.Refresh, result.RefreshToken,
				"Incorrect Result.RefreshToken.");
			Assert.AreEqual("bearer", result.TokenType, "Incorrect Result.TokenType.");
			Assert.AreEqual(3600, result.ExpiresIn, "Incorrect Result.ExpiresIn.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NotFound() {
			OauthAccess nullOa = null;

			vMockCtx
				.Setup(x => x.DbSingle<OauthAccess>(It.IsAny<IWeaverQuery>()))
				.Returns((IWeaverQuery q) => GetSingleAccess(q, vToken, vUtcNow, nullOa));

			FabOauthAccess result = TestGo(vToken);
			
			Assert.Null(result, "Result should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNullToken() {
			vToken = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, () => TestGo(vToken));
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("")]
		[TestCase("x")]
		[TestCase("1234567890123456789012345678901")]
		[TestCase("123456789012345678901234567890123")]
		public void ErrTokenLen(string pToken) {
			vToken = pToken;
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, () => TestGo(vToken));
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("1234567890123456789012345678901_")]
		[TestCase("123456789 1234567890123456789012")]
		public void ErrTokenChars(string pToken) {
			vToken = pToken;
			TestUtil.CheckThrows<FabArgumentFault>(true, () => TestGo(vToken));
		}

	}

}