using System;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetAccessToken : IntegTestBase {

		private string vToken;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			IsReadOnlyTest = true;

			OauthAccess oa = GetVertex<OauthAccess>((long)SetupOauth.OauthAccessId.GalZach);
			ApiCtx.TestUtcNow = new DateTime(oa.Expires).AddMinutes(-2);
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess TestGo() {
			return new GetAccessToken(vToken).Go(ApiCtx);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupOauth.TokenGalZach, SetupOauth.OauthAccessId.GalZach)]
		[TestCase(SetupOauth.TokenBook, SetupOauth.OauthAccessId.Book)]
		[TestCase(SetupOauth.TokenGalEllieExp, null)]
		[TestCase("12345678901234567890123456789012", null)]
		public void Go(string pToken, SetupOauth.OauthAccessId? pExpectId) {
			vToken = pToken;

			FabOauthAccess result = TestGo();

			if ( pExpectId != null ) {
				Assert.NotNull(result, "Result should be filled.");
				Assert.AreEqual((long)pExpectId, result.OauthAccessId, "Incorrect OauthAccessId.");
			}
			else {
				Assert.Null(result, "Result should be null.");
			}
		}

	}

}