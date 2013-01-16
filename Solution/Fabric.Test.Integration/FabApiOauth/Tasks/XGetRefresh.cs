using System;
using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiOauth.Tasks {

	/*================================================================================================*/
	//[TestFixture]
	public class XGetRefresh : IntegTestBase {

		private string vCode;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			//OauthRefresh og = GetNode<OauthRefresh>((long)SetupOauth.OauthRefreshId.GalMel);
			//Context.TestUtcNow = new DateTime(og.Expires).AddMinutes(-20);
		}

		/*--------------------------------------------------------------------------------------------*/
		private RefreshResult TestGo() {
			return new GetRefresh(vCode).Go(Context);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		[TestCase(SetupOauth.RefreshGalZach, SetupOauth.OauthRefreshId.GalZach, AppGal, UserZach)]
		[TestCase(SetupOauth.RefreshBookElliePast, null, null, null)]
		public void Go(string pCode, SetupOauth.OauthRefreshId? pExpectId,																	SetupUsers.AppId? pExpectAppId, SetupUsers.UserId? pExpectUserId) {
			vCode = pCode;

			RefreshResult result = TestGo();

			if ( pExpectId != null) {
				Assert.NotNull(result, "Result should be filled.");
				Assert.AreEqual((long)pExpectId, result.RefreshId, "Incorrect RefreshId.");
				
				Assert.NotNull(pExpectAppId, "pExpectAppId cannot be null.");
				Assert.NotNull(pExpectUserId, "pExpectUserId cannot be null.");
				Assert.AreEqual((long)pExpectAppId, result.AppId, "Incorrect RefreshId.");
				Assert.AreEqual((long)pExpectUserId, result.UserId, "Incorrect RefreshId.");
			}
			else {
				Assert.Null(result, "Result should be null.");
			}
		}*/

	}

}