using Fabric.Api.Dto.Oauth;
using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data.Setups;
using Fabric.Infrastructure;
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
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pClientOnly) {
			vClientOnly = pClientOnly;

			if ( vClientOnly ) {
				vUserId = null;
			}
			
			Log.Debug("Start function...");
			FabOauthAccess result = TestGo();
			Log.Debug("End function: "+result);

			Assert.NotNull(result, "Result should be filled.");
		}

	}

}