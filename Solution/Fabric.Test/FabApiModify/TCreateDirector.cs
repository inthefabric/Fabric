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
	public class TCreateDirector : TCreateFactorElement<Director> {

		private long vDirTypeId;
		private long vPrimActId;
		private long vRelActId;

		private Director vResultDirector;
		private Director vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vDirTypeId = 9;
			vPrimActId = 935823;
			vRelActId = 25323;

			IWeaverVarAlias<Director> outVar = GetTxVar<Director>("DIR");

			MockTasks
				.Setup(x => x.TxAddDirector(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vDirTypeId,
						vPrimActId,
						vRelActId,
						ActiveFactor,
					out outVar
					)
				);

			vResultDirector = new Director();

			MockApiCtx
				.Setup(x => x.DbSingle<Director>("CreateDirectorTx", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction q) => CreateDirectorTx(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Director CreateDirectorTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);

			const string expectPartial = "DIR;";
			Assert.AreEqual(expectPartial, pTx.Script, "Incorrect partial script.");
			return vResultDirector;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void SetupFactorHasElement(bool pResult) {
			MockTasks
				.Setup(x => x.FactorHasDirector(MockApiCtx.Object, ActiveFactor))
				.Returns(pResult);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			var func = new AttachDirector(MockTasks.Object, FactorId, vDirTypeId, vPrimActId,vRelActId);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewDirector() {
			TestGo();
			Assert.AreEqual(vResultDirector, vResult, "Incorrect Result.");
			CheckValidation();
		}


		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExistingDirector() {
			var existing = new Director();

			MockTasks
				.Setup(x => x.GetDirectorMatch(
						MockApiCtx.Object,
						vDirTypeId,
						vPrimActId,
						vRelActId
					)
				)
				.Returns(existing);

			TestGo();

			Assert.AreEqual(existing, vResult, "Incorrect Result.");
			CheckValidation();

			MockTasks
				.Verify(x => x.AttachExistingElement<Director, FactorUsesDirector>(
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

			MockValidator.Verify(x => x.DirectorTypeId(vDirTypeId,
				AttachDirector.DirTypeParam), Times.Once());
			MockValidator.Verify(x => x.DirectorActionId(vPrimActId,
				AttachDirector.PrimActionParam), Times.Once());
			MockValidator.Verify(x => x.DirectorActionId(vRelActId,
				AttachDirector.RelActionParam), Times.Once());
		}

	}

}