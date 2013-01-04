using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Infrastructure;
using NUnit.Framework;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TDoLogout : TAddAccess {
	
		private FabOauthAccess vAccess;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public override void SetUp() {
			base.SetUp();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private FabOauthAccess TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().DoLogout(vAccess, vMockCtx.Object);
			}
			
			var task = new DoLogout(vAccess);
			return task.Go(vMockCtx.Object);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void ErrAppId(long pAppId) {}
		public override void ErrUserId(bool pIsClientOnly, long? pUserId) {}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true, true)]
		[TestCase(true, false)]
		[TestCase(false, true)]
		[TestCase(false, false)]
		public override void Success(bool pClientOnly, bool pViaTask) {
			vClientOnly = pClientOnly;
			
			if ( vClientOnly ) {
				vUserId = null;
			}
			
			vAccess = new FabOauthAccess();
			vAccess.AppId = vAppId;
			vAccess.UserId = vUserId;
			vAccess.OauthAccessId = 83838;
			vAccess.AccessToken = vTokenCode;
			vAccess.RefreshToken = FabricUtil.Code32;
			vAccess.TokenType = "bearer";
			vAccess.ExpiresIn = 400;
			
			FabOauthAccess result = TestGo(pViaTask);
			
			vUsageMap.AssertUses(AddAccess.Query.ClearTokens+"", 1);
			vUsageMap.AssertUses(AddAccess.Query.AddAccessTx+"", 0);
			
			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vAccess.AccessToken, result.AccessToken, "Incorrect Result.AccessToken.");
			Assert.Null(result.RefreshToken, "Incorrect Result.RefreshToken.");
			Assert.AreEqual("bearer", result.TokenType, "Incorrect Result.TokenType.");
			Assert.AreEqual(0, result.ExpiresIn, "Incorrect Result.ExpiresIn.");
		}
		
	}

}