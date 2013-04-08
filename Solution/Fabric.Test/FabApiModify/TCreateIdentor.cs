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
	public class TCreateIdentor : TCreateFactorElement<Identor> {

		private long vIdenTypeId;
		private string vValue;

		private Identor vResultIdentor;
		private Identor vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vIdenTypeId = 9;
			vValue = "my unique value";

			IWeaverVarAlias<Identor> outVar = GetTxVar<Identor>("IDEN");

			MockTasks
				.Setup(x => x.TxAddIdentor(
						MockApiCtx.Object,
						It.IsAny<TxBuilder>(),
						vIdenTypeId,
						vValue,
						ActiveFactor,
						out outVar
					)
				);

			vResultIdentor = new Identor();

			MockApiCtx
				.Setup(x => x.DbSingle<Identor>("CreateIdentorTx", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction q) => CreateIdentorTx(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Identor CreateIdentorTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);

			const string expectPartial = "IDEN;";
			Assert.AreEqual(expectPartial, pTx.Script, "Incorrect partial script.");
			return vResultIdentor;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void SetupFactorHasElement(bool pResult) {
			MockTasks
				.Setup(x => x.FactorHasIdentor(MockApiCtx.Object, ActiveFactor))
				.Returns(pResult);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			var func = new AttachIdentor(MockTasks.Object, FactorId, vIdenTypeId,vValue);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewIdentor() {
			TestGo();
			Assert.AreEqual(vResultIdentor, vResult, "Incorrect Result.");
			CheckValidation();
		}


		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ExistingIdentor() {
			var existing = new Identor();

			MockTasks
				.Setup(x => x.GetIdentorMatch(
						MockApiCtx.Object,
						vIdenTypeId,
						vValue
					)
				)
				.Returns(existing);

			TestGo();

			Assert.AreEqual(existing, vResult, "Incorrect Result.");
			CheckValidation();

			MockTasks
				.Verify(x => x.AttachExistingElement<Identor, FactorUsesIdentor>(
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

			MockValidator.Verify(x => x.IdentorTypeId(vIdenTypeId,
				AttachIdentor.IdenTypeParam), Times.Once());
			MockValidator.Verify(x => x.IdentorValue(vValue, AttachIdentor.ValueParam), Times.Once());
		}

	}

}