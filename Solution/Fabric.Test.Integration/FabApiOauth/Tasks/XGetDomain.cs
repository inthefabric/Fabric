using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data.Setups;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetDomain : IntegTestBase {

		private long vAppId;
		private string vRedirUri;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private DomainResult TestGo() {
			return new GetDomain(vAppId, vRedirUri).Go(Context);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppGal, SetupOauth.GrantUrlGal, true)]
		[TestCase(AppGal, "http://www.ZACHKINSTNER.com/something/else", true)]
		[TestCase(AppGal, "http://www.zachkinstner.net/oauth", false)]
		public void Go(SetupUsers.AppId pAppId, string pRedirUri, bool pFound) {
			vAppId = (long)pAppId;
			vRedirUri = pRedirUri;

			DomainResult result = TestGo();

			if ( pFound ) {
				Assert.NotNull(result, "Result should be filled.");
				Assert.AreEqual(vAppId, result.AppId, "Incorrect UserId.");
			}
			else {
				Assert.Null(result, "Result should be null.");
			}
		}

	}

}