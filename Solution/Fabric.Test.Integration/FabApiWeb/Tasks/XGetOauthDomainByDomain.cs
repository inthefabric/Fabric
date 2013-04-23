using Fabric.Db.Data.Setups;
using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetOauthDomainByDomain : XWebTasks {

		private long vAppId;
		private string vDomain;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private OauthDomain TestGo() {
			return Tasks.GetOauthDomainByDomain(ApiCtx, vAppId, vDomain);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppBook, SetupOauth.DomBook2)]
		[TestCase(AppGal, SetupOauth.DomGal1)]
		public void Found(SetupUsers.AppId pAppId, string pDomain) {
			vAppId = (long)pAppId;
			vDomain = pDomain;

			OauthDomain result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vDomain.ToLower(), result.Domain.ToLower(), "Incorrect Domain.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppGal, SetupOauth.DomBook2)]
		[TestCase(AppBook, SetupOauth.DomGal1)]
		public void NotFound(SetupUsers.AppId pAppId, string pDomain) {
			vAppId = (long)pAppId;
			vDomain = pDomain;

			OauthDomain result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}