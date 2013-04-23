using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetDataProv : IntegTestBase {

		private long vAppId;
		private long vDataProvUserId;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private User TestGo() {
			return new GetDataProv(vAppId, vDataProvUserId).Go(ApiCtx);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppGal, UserGal, UserGal)]
		[TestCase(AppBook, UserBook, UserBook)]
		[TestCase(AppBook, UserZach, null)]
		public void Go(SetupUsers.AppId pAppId, SetupUsers.UserId pDpId, SetupUsers.UserId? pExpectId) {
			vAppId = (long)pAppId;
			vDataProvUserId = (long)pDpId;

			User result = TestGo();

			if ( pExpectId != null ) {
				Assert.NotNull(result, "Result should be filled.");
				Assert.AreEqual((long)pExpectId, result.UserId, "Incorrect UserId.");
			}
			else {
				Assert.Null(result, "Result should be null.");
			}
		}

	}

}