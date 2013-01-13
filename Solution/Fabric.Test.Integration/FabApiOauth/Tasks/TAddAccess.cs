using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TAddAccess : IntegTestBase {

		private long vAppId;
		private long? vUserId;
		private int vExpireSec;
		private bool vClientOnly;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = (long)SetupUsers.AppId.KinPhoGal;
			vUserId = (long)SetupUsers.UserId.Penny;
			vExpireSec = 3600;
			vClientOnly = false;
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess TestGo() {
			return new AddAccess(vAppId, vUserId, vExpireSec, vClientOnly).Go(Context);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppGal, UserZach, SetupOauth.OauthAccessId.GalZach)]
		[TestCase(AppGal, UserEllie, SetupOauth.OauthAccessId.GalEllie_Past)]
		[TestCase(AppGal, UserGal, SetupOauth.OauthAccessId.GalGalData)]
		public void SuccessAppAndUser(SetupUsers.AppId pAppId, SetupUsers.UserId pUserId,
														SetupOauth.OauthAccessId pClearedAccessId) {
			vClientOnly = false;
			vAppId = (long)pAppId;
			vUserId = (long)pUserId;

			////

			OauthAccess clearOa = GetNode<OauthAccess>((long)pClearedAccessId);
			Assert.NotNull(clearOa, "Target OauthAccess is missing.");
			Assert.NotNull(clearOa.Token, "Target OauthAccess must have a Token value.");
			Assert.NotNull(clearOa.Refresh, "Target OauthAccess must have a Refresh value.");

			////

			FabOauthAccess result = TestGo();
			Assert.NotNull(result, "Result should be filled.");

			OauthAccess newOa = GetNodeByProp<OauthAccess>("Token", "'"+result.AccessToken+"'");
			Assert.NotNull(newOa, "New OauthAccess was not created.");

			////

			clearOa = GetNode<OauthAccess>((long)pClearedAccessId);
			Assert.NotNull(clearOa, "Target OauthAccess was deleted.");
			Assert.AreEqual("", clearOa.Token, "Target OauthAccess.Token was not cleared.");
			Assert.AreEqual("", clearOa.Refresh, "Target OauthAccess.Refresh was not cleared.");
		}

	}

}