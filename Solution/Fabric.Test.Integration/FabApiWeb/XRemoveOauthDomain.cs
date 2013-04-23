using Fabric.Api.Web;
using Fabric.Api.Web.Results;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiWeb {

	/*================================================================================================*/
	[TestFixture]
	public class XRemoveOauthDomain : XBaseWebFunc {

		private long vAppId;
		private long vOauthDomainId;
		
		private SuccessResult vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;

			vAppId = (long)AppGal;
			vOauthDomainId = (long)SetupOauth.OauthDomainId.Gal1;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new RemoveOauthDomain(Tasks, vAppId, vOauthDomainId);
			vResult = func.Go(ApiCtx);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppBook, SetupOauth.OauthDomainId.Book2)]
		[TestCase(AppGal, SetupOauth.OauthDomainId.Gal1)]
		public void Success(SetupUsers.AppId pAppId, SetupOauth.OauthDomainId pDomainId) {
			vAppId = (long)pAppId;
			vOauthDomainId = (long)pDomainId;
			IsReadOnlyTest = false;

			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");
			Assert.True(vResult.Success, "Incorrect Result.Success.");

			OauthDomain tryDom = GetNode<OauthDomain>(vOauthDomainId);
			Assert.Null(tryDom, "Target OauthDomain was not deleted.");

			NewNodeCount = -1;
			NewRelCount = -1;
		}

				
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrAppIdValue() {
			vAppId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrOauthDomainId() {
			vOauthDomainId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}

	}

}