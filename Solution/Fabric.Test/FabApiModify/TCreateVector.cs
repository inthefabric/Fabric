using Fabric.Api.Modify;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Domain.Types;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateVector : TCreateFactorElement<Vector> {

		private long vVecTypeId;
		private long vValue;
		private long vAxisArtId;
		private long vVecUnitId;
		private long vVecUnitPrefId;

		private VectorType vRangeVecType;
		private Vector vResultVector;
		private Vector vResult;
		
		//TODO: add more Vector.Value boundary tests
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vVecTypeId = 9;
			vValue = 88;
			vAxisArtId = 123525;
			vVecUnitId = 3;
			vVecUnitPrefId = (long)VectorUnitPrefixId.Base;
			IWeaverVarAlias<Vector> outVar = GetTxVar<Vector>("VEC");
			
			vRangeVecType = new VectorType();
			vRangeVecType.Min = 0;
			vRangeVecType.Max = 100;
			
			MockTasks
				.Setup(x => x.TxAddVector(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vVecTypeId,
						vValue,
						vAxisArtId,
						vVecUnitId,
						vVecUnitPrefId,
						ActiveFactor,
						out outVar
					)
				);
				
			MockTasks
				.Setup(x => x.GetArtifact(MockApiCtx.Object, vAxisArtId))
				.Returns(new Artifact());
				
			MockTasks
				.Setup(x => x.GetVectorType(MockApiCtx.Object, vVecTypeId))
				.Returns(vRangeVecType);

			vResultVector = new Vector();

			MockApiCtx
				.Setup(x => x.DbSingle<Vector>("CreateVectorTx", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction q) => CreateVectorTx(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Vector CreateVectorTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);

			const string expectPartial = "VEC;";
			Assert.AreEqual(expectPartial, pTx.Script, "Incorrect partial script.");
			return vResultVector;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void SetupFactorHasElement(bool pResult) {
			MockTasks
				.Setup(x => x.FactorHasVector(MockApiCtx.Object, ActiveFactor))
				.Returns(pResult);
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
			Assert.AreEqual(vResultVector, vResult, "Incorrect Result.");
			CheckValidation();
		}


		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExistingVector() {
			var existing = new Vector();

			MockTasks
				.Setup(x => x.GetVectorMatch(
						MockApiCtx.Object,
						vVecTypeId,
						vValue,
						vAxisArtId,
						vVecUnitId,
						vVecUnitPrefId
					)
				)
				.Returns(existing);

			TestGo();

			Assert.AreEqual(existing, vResult, "Incorrect Result.");
			CheckValidation();

			MockTasks
				.Verify(x => x.AttachExistingElement<Vector, FactorUsesVector>(
						MockApiCtx.Object,
						ActiveFactor,
						existing
					),
					Times.Once()
				);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CheckValidation() {
			base.CheckValidation();

			MockValidator.Verify(x => x.VectorTypeId(vVecTypeId,
				AttachVector.VecTypeParam), Times.Once());
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrMin() {
			vRangeVecType.Min = 1000;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrMax() {
			vRangeVecType.Max = 0;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrAxisArtifactNotFound() {
			MockTasks
				.Setup(x => x.GetArtifact(MockApiCtx.Object, vAxisArtId))
				.Returns((Artifact)null);

			FabNotFoundFault f = TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
			Assert.AreEqual(typeof(Artifact), f.ItemType, "Incorrect Fault.ItemType.");
		}

	}

}