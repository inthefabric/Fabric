using Fabric.Api.Modify;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class TDeleteFactor : TUpdateFactor {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vDeleted = true;
			base.TestSetUp();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			var func = new DeleteFactor(MockTasks.Object, vFactorId, vDeleted);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrCompletedValue() {
			vDeleted = false;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}


	}

}