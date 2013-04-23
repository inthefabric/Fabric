using Fabric.Api.Modify;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class TCompleteFactor : TUpdateFactor {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vCompleted = true;
			base.TestSetUp();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			var func = new CompleteFactor(MockTasks.Object, vFactorId, vCompleted);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrCompletedValue() {
			vCompleted = false;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrFactorAlreadyCompleted() {
			vResultFactor.Completed = 12343255;
			TestUtil.CheckThrows<FabPreventedFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrFactorHasNoDescriptor() {
			vResultFactor.Descriptor_TypeId = null;
			TestUtil.CheckThrows<FabPreventedFault>(true, TestGo);
		}

	}

}