using Fabric.Api.Modify;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class TAttachIdentor : TAttachFactorElement {

		private byte vIdenTypeId;
		private string vValue;

		private bool vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vIdenTypeId = 9;
			vValue = "my unique value";

			MockTasks
				.Setup(x => x.UpdateFactorIdentor(
					MockApiCtx.Object,
					ActiveFactor,
					vIdenTypeId,
					vValue
				));
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
			Assert.True(vResult, "Incorrect Result.");
			CheckValidation();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CheckValidation() {
			base.CheckValidation();

			MockValidator.Verify(x => x.FactorIdentor_TypeId(vIdenTypeId,
				AttachIdentor.IdenTypeParam), Times.Once());
			MockValidator.Verify(x => x.FactorIdentor_Value(vValue,
				AttachIdentor.ValueParam), Times.Once());
		}

	}

}