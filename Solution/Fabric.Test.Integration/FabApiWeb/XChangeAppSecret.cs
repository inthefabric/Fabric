using Fabric.Api.Web;
using Fabric.Api.Web.Results;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiWeb {

	/*================================================================================================*/
	[TestFixture]
	public class XChangeAppSecret : XBaseWebFunc {

		private long vAppId;
		
		private SuccessResult vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;

			vAppId = (long)AppGal;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new ChangeAppSecret(Tasks, vAppId);
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
		}

				
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrAppIdValue() {
			vAppId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}

	}

}