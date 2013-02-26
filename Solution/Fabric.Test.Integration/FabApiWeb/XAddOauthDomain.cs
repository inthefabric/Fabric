using Fabric.Api.Web;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Integration.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiWeb {

	/*================================================================================================*/
	[TestFixture]
	public class XAddOauthDomain : XBaseWebFunc {

		private long vAppId;
		private string vDomain;
		
		private OauthDomain vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;

			vAppId = (long)AppGal;
			vDomain = "testing.com";
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new AddOauthDomain(Tasks, vAppId, vDomain);
			vResult = func.Go(ApiCtx);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppBook, SetupOauth.DomBook1)]
		[TestCase(AppGal, SetupOauth.DomGal2)]
		public void Success(SetupUsers.AppId pAppId, string pDomain) {
			vAppId = (long)pAppId;
			vDomain = pDomain;
			IsReadOnlyTest = false;

			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");
			Assert.AreNotEqual(0, vResult.OauthDomainId, "Incorrect Result.OauthDomainId.");

			OauthDomain newDom = GetNode<OauthDomain>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newDom, "New OauthDomain was not created.");
			Assert.AreNotEqual(0, newDom.OauthDomainId, "Incorrect OauthDomainId.");
			Assert.AreEqual(vDomain, newDom.Domain, "Incorrect Result.Domain.");

			NodeConnections conn = GetNodeConnections(newDom);
			conn.AssertRelCount(1, 1);
			conn.AssertRel<RootContainsOauthDomain, Root>(false, 0);
			conn.AssertRel<OauthDomainUsesApp, App>(true, vAppId);

			NewNodeCount = 1;
			NewRelCount = 2;
		}

				
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrAppIdValue() {
			vAppId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNameNull() {
			vDomain = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNameLength() {
			vDomain = new string('a', 257);
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, TestGo);
		}

	}

}