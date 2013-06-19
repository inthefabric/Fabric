using Fabric.Api.Web;
using Fabric.Api.Web.Results;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiWeb {

	/*================================================================================================*/
	[TestFixture]
	public class XChangeAppName : XBaseWebFunc {

		private long vAppId;
		private string vName;
		
		private SuccessResult vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
			UsesElasticSearch = true;

			vAppId = (long)AppGal;
			vName = "My New App";
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new ChangeAppName(Tasks, vAppId, vName);
			vResult = func.Go(ApiCtx);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			IsReadOnlyTest = false;

			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");
			Assert.True(vResult.Success, "Result.Success should not be null.");

			App upApp = GetVertex<App>(vAppId);
			Assert.AreEqual(vName, upApp.Name, "Target App.Name not updated.");
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
			vName = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(2)]
		[TestCase(65)]
		public void ErrNameLength(int pLength) {
			vName = new string('a', pLength);
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNameInvalid() {
			vName = "test`";
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}

	}

}