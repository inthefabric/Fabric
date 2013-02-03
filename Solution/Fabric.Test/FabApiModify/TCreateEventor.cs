using Fabric.Api.Modify;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateEventor : TCreateFactorElement<Eventor> {

		private long vEveTypeId;
		private long vEvePrecId;
		private long vDateTime;

		private Eventor vResultEventor;
		private Eventor vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vEveTypeId = 9;
			vEvePrecId = 935823;
			vDateTime = 2529342323;

			IWeaverVarAlias<Eventor> outVar = GetTxVar<Eventor>("EVE");

			MockTasks
				.Setup(x => x.TxAddEventor(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vEveTypeId,
						vEvePrecId,
						vDateTime,
						ActiveFactor,
						out outVar
					)
				);

			vResultEventor = new Eventor();

			MockApiCtx
				.Setup(x => x.DbSingle<Eventor>("CreateEventorTx", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction q) => CreateEventorTx(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Eventor CreateEventorTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);

			const string expectPartial = "EVE;";
			Assert.AreEqual(expectPartial, pTx.Script, "Incorrect partial script.");
			return vResultEventor;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void SetupFactorHasElement(bool pResult) {
			MockTasks
				.Setup(x => x.FactorHasEventor(MockApiCtx.Object, ActiveFactor))
				.Returns(pResult);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			var func = new CreateEventor(MockTasks.Object, FactorId, vEveTypeId, vEvePrecId,vDateTime);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewEventor() {
			TestGo();
			Assert.AreEqual(vResultEventor, vResult, "Incorrect Result.");
			CheckValidation();
		}


		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExistingEventor() {
			var existing = new Eventor();

			MockTasks
				.Setup(x => x.GetEventorMatch(
						MockApiCtx.Object,
						vEveTypeId,
						vEvePrecId,
						vDateTime
					)
				)
				.Returns(existing);

			TestGo();

			Assert.AreEqual(existing, vResult, "Incorrect Result.");
			CheckValidation();

			MockTasks
				.Verify(x => x.AttachExistingElement<Eventor, FactorUsesEventor>(
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

			MockValidator.Verify(x => x.EventorTypeId(vEveTypeId,
				CreateEventor.EveTypeParam), Times.Once());
			MockValidator.Verify(x => x.EventorPrecisionId(vEvePrecId,
				CreateEventor.EvePrecParam), Times.Once());
		}

	}

}