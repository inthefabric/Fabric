using Fabric.Api.Modify;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateLocator : TCreateFactorElement<Locator> {

		private long vLocTypeId;
		private double vValueX;
		private double vValueY;
		private double vValueZ;

		private LocatorType vRangeLocType;
		private Locator vResultLocator;
		private Locator vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vLocTypeId = 9;
			vValueX = 1.34236;
			vValueY = 99.52352;
			vValueZ = 37.023983;
			
			IWeaverVarAlias<Locator> outVar = GetTxVar<Locator>("LOC");
			
			vRangeLocType = new LocatorType();
			vRangeLocType.MinX = 0;
			vRangeLocType.MaxX = 100;
			vRangeLocType.MinY = 0;
			vRangeLocType.MaxY = 100;
			vRangeLocType.MinZ = 0;
			vRangeLocType.MaxZ = 100;
			
			MockTasks
				.Setup(x => x.TxAddLocator(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vLocTypeId,
						vValueX,
						vValueY,
						vValueZ,
						ActiveFactor,
						out outVar
					)
				);
				
			MockTasks
				.Setup(x => x.GetLocatorType(MockApiCtx.Object, vLocTypeId))
				.Returns(vRangeLocType);

			vResultLocator = new Locator();

			MockApiCtx
				.Setup(x => x.DbSingle<Locator>("CreateLocatorTx", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction q) => CreateLocatorTx(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Locator CreateLocatorTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);

			const string expectPartial = "LOC;";
			Assert.AreEqual(expectPartial, pTx.Script, "Incorrect partial script.");
			return vResultLocator;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void SetupFactorHasElement(bool pResult) {
			MockTasks
				.Setup(x => x.FactorHasLocator(MockApiCtx.Object, ActiveFactor))
				.Returns(pResult);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			var func = new CreateLocator(MockTasks.Object, FactorId,
				vLocTypeId, vValueX, vValueY, vValueZ);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewLocator() {
			TestGo();
			Assert.AreEqual(vResultLocator, vResult, "Incorrect Result.");
			CheckValidation();
		}


		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExistingLocator() {
			var existing = new Locator();

			MockTasks
				.Setup(x => x.GetLocatorMatch(
						MockApiCtx.Object,
						vLocTypeId,
						vValueX,
						vValueY,
						vValueZ
					)
				)
				.Returns(existing);

			TestGo();

			Assert.AreEqual(existing, vResult, "Incorrect Result.");
			CheckValidation();

			MockTasks
				.Verify(x => x.AttachExistingElement<Locator, FactorUsesLocator>(
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

			MockValidator.Verify(x => x.LocatorTypeId(vLocTypeId,
				CreateLocator.LocTypeParam), Times.Once());
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(1000, 0, 0)]
		[TestCase(0, 1000, 0)]
		[TestCase(0, 0, 1000)]
		public void ErrMin(double pMinX, double pMinY, double pMinZ) {
			vRangeLocType.MinX = pMinX;
			vRangeLocType.MinY = pMinY;
			vRangeLocType.MinZ = pMinZ;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0, 100, 100)]
		[TestCase(100, 0, 100)]
		[TestCase(100, 100, 0)]
		public void ErrMax(double pMaxX, double pMaxY, double pMaxZ) {
			vRangeLocType.MaxX = pMaxX;
			vRangeLocType.MaxY = pMaxY;
			vRangeLocType.MaxZ = pMaxZ;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

	}

}