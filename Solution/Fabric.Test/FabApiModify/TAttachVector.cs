using Fabric.Api.Modify;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain;
using Fabric.Test.Common;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class TAttachVector : TAttachFactorElement {

		private byte vVecTypeId;
		private long vValue;
		private long vAxisArtId;
		private byte vVecUnitId;
		private byte vVecUnitPrefId;

		private bool vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vVecTypeId = (byte)VectorTypeId.StdPerc; //0 to 100
			vValue = 88;
			vAxisArtId = 123525;
			vVecUnitId = 3;
			vVecUnitPrefId = (byte)VectorUnitPrefixId.Base;
			
			MockTasks
				.Setup(x => x.UpdateFactorVector(
						MockApiCtx.Object,
						ActiveFactor,
						vVecTypeId,
						vValue,
						vAxisArtId,
						vVecUnitId,
						vVecUnitPrefId
					)
				);

			var mda = MockDataAccess.Create(m => { });
			mda.MockResult.SetupToElement(new Artifact());
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			var func = new AttachVector(MockTasks.Object, FactorId,
				vVecTypeId, vValue, vAxisArtId, vVecUnitId, vVecUnitPrefId);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewVector() {
			TestGo();
			Assert.True(vResult, "Incorrect Result.");
			CheckValidation();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CheckValidation() {
			base.CheckValidation();

			MockValidator.Verify(x => x.FactorVector_TypeId(vVecTypeId,
				AttachVector.VecTypeParam), Times.Once());
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(VectorTypeId.StdPerc, VectorUnitPrefixId.Base, -1)]
		[TestCase(VectorTypeId.StdPerc, VectorUnitPrefixId.Base, 101)]
		[TestCase(VectorTypeId.OppAgree, VectorUnitPrefixId.Base, -101)]
		[TestCase(VectorTypeId.OppAgree, VectorUnitPrefixId.Base, 101)]
		[TestCase(VectorTypeId.OppAgree, VectorUnitPrefixId.Kilo, -11)]
		[TestCase(VectorTypeId.OppAgree, VectorUnitPrefixId.Kilo, 11)]
		[TestCase(VectorTypeId.OppAgree, VectorUnitPrefixId.Giga, -1)]
		[TestCase(VectorTypeId.OppAgree, VectorUnitPrefixId.Giga, 1)]
		public void ErrValueBounds(VectorTypeId pTypeId, VectorUnitPrefixId pPrefId, long pVal) {
			vVecTypeId = (byte)pTypeId;
			vVecUnitPrefId = (byte)pPrefId;
			vValue = pVal;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrAxisArtifactNotFound() {
			MockDataList[0].MockResult.SetupToElement((Artifact)null);

			FabNotFoundFault f = TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
			Assert.AreEqual(typeof(Artifact), f.ItemType, "Incorrect Fault.ItemType.");
		}

	}

}