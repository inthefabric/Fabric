using System;
using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetGrant : IntegTestBase {

		private string vCode;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			OauthGrant og = GetNode<OauthGrant>((long)SetupOauth.OauthGrantId.GalMel);
			Context.TestUtcNow = new DateTime(og.Expires).AddMinutes(-20);
		}

		/*--------------------------------------------------------------------------------------------*/
		private GrantResult TestGo() {
			return new GetGrant(vCode).Go(Context);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupOauth.GrantGalZach, SetupOauth.OauthGrantId.GalZach, AppGal, UserZach)]
		[TestCase(SetupOauth.GrantBookElliePast, null, null, null)]
		public void Go(string pCode, SetupOauth.OauthGrantId? pExpectId,																	SetupUsers.AppId? pExpectAppId, SetupUsers.UserId? pExpectUserId) {
			vCode = pCode;

			GrantResult result = TestGo();

			if ( pExpectId != null) {
				Assert.NotNull(result, "Result should be filled.");
				Assert.AreEqual((long)pExpectId, result.GrantId, "Incorrect GrantId.");
				
				Assert.NotNull(pExpectAppId, "pExpectAppId cannot be null.");
				Assert.AreEqual((long)pExpectAppId, result.AppId, "Incorrect GrantId.");

				if ( pExpectUserId != null ) {
					Assert.AreEqual((long)pExpectUserId, result.UserId, "Incorrect GrantId.");
				}
				else {
					Assert.Null(result.UserId, "UserId should be null.");
				}
			}
			else {
				Assert.Null(result, "Result should be null.");
			}
		}

	}

}