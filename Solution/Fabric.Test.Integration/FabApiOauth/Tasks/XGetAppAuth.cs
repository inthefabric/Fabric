using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetAppAuth : IntegTestBase {

		private long vAppId;
		private string vSecret;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private App TestGo() {
			return new GetAppAuth(vAppId, vSecret).Go(Context);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppFab, SetupUsers.FabSysSecret, true)]
		[TestCase(AppGal, SetupUsers.KinPhoGalSecret, true)]
		[TestCase(AppGal, SetupUsers.KinPhoGalSecret+"x", false)]
		[TestCase(AppGal, "", false)]
		public void Go(SetupUsers.AppId pAppId, string pSecret, bool pExpectFound) {
			vAppId = (long)pAppId;
			vSecret = pSecret;

			App result = TestGo();

			if ( pExpectFound ) {
				Assert.NotNull(result, "Result should be filled.");
				Assert.AreEqual(vAppId, result.AppId, "Incorrect AppId.");
			}
			else {
				Assert.Null(result, "Result should be null.");
			}
		}

	}

}