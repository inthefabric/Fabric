using Fabric.Db.Data.Setups;
using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XDeleteOauthDomain : XWebTasks {

		private long vAppId;
		private long vOauthDomainId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vAppId = (long)AppGal;
			vOauthDomainId = (long)SetupOauth.OauthDomainId.Gal2;
		}

		/*--------------------------------------------------------------------------------------------*/
		private bool TestGo() {
			return Tasks.DeleteOauthDomain(ApiCtx, vAppId, vOauthDomainId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Deleted() {
			OauthDomain targetDom = GetNode<OauthDomain>(vOauthDomainId);
			Assert.NotNull(targetDom, "Target OauthDomain does not exist.");

			bool result = TestGo();

			Assert.True(result, "Incorrect result.");

			OauthDomain tryDom = GetNode<OauthDomain>(vOauthDomainId);
			Assert.Null(tryDom, "Target OauthDomain was not deleted.");

			NewNodeCount = -1;
			NewRelCount = -2;
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppGal, SetupOauth.OauthDomainId.Book1)]
		[TestCase(AppBook, SetupOauth.OauthDomainId.Fab2)]
		public void NotDeleted(SetupUsers.AppId pAppId, SetupOauth.OauthDomainId pDomainId) {
			vAppId = (long)pAppId;
			vOauthDomainId = (long)pDomainId;

			OauthDomain targetDom = GetNode<OauthDomain>(vOauthDomainId);
			Assert.NotNull(targetDom, "Target OauthDomain does not exist.");

			bool result = TestGo();

			Assert.False(result, "Incorrect result.");

			IsReadOnlyTest = true;
			NewNodeCount = 0;
			NewRelCount = 0;
		}

	}

}