using Fabric.Api.Modify;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class TAttachLocator : TAttachFactorElement {

		private byte vLocTypeId;
		private double vValueX;
		private double vValueY;
		private double vValueZ;

		private bool vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vLocTypeId = (byte)LocatorTypeId.EarthCoord; //bounds: 180, 90, DblMax
			vValueX = 1.34236;
			vValueY = 89.52352;
			vValueZ = 37.023983;
			
			MockTasks
				.Setup(x => x.UpdateFactorLocator(
					MockApiCtx.Object,
					ActiveFactor,
					vLocTypeId,
					vValueX,
					vValueY,
					vValueZ
				));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			var func = new AttachLocator(MockTasks.Object, FactorId,
				vLocTypeId, vValueX, vValueY, vValueZ);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewLocator() {
			TestGo();
			Assert.True(vResult, "Incorrect Result.");
			CheckValidation();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CheckValidation() {
			base.CheckValidation();

			MockValidator.Verify(x => x.FactorLocator_TypeId(vLocTypeId,
				AttachLocator.LocTypeParam), Times.Once());
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(181, 0, 0)]
		[TestCase(0, 91, 0)]
		[TestCase(0, 0, double.MaxValue)]
		[TestCase(-181, 0, 0)]
		[TestCase(0, -91, 0)]
		[TestCase(0, 0, double.MinValue)]
		public void ErrValueBounds(double pValX, double pValY, double pValZ) {
			vValueX = pValX;
			vValueY = pValY;
			vValueZ = pValZ;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

	}

}