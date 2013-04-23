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
		[TestCase(AppBook, "book.com")]
		[TestCase(AppGal, "gallery.com")]
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
			conn.AssertRelCount(0, 1);
			conn.AssertRel<OauthDomainUsesApp, App>(true, vAppId);

			NewNodeCount = 1;
			NewRelCount = 1;
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
		public void ErrDomainNull() {
			vDomain = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(257)]
		public void ErrDomainLength(int pLen) {
			vDomain = new string('a', pLen);
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("bad one.com")]
		[TestCase("bad_2.com")]
		[TestCase("http://fail.com")]
		[TestCase("somewhere.com/fail")]
		[TestCase("fail0")]
		[TestCase("fail0.")]
		[TestCase("fail1.x")]
		[TestCase("fail7.xxxOOOx")]
		[TestCase("numericalTldFail.abc1")]
		public void ErrDomainInvalid(string pDomain) {
			vDomain = pDomain;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}

	}

}