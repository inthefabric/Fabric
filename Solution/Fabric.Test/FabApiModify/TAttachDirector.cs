using Fabric.Api.Modify;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class TAttachDirector : TAttachFactorElement {

		private byte vDirTypeId;
		private byte vPrimActId;
		private byte vEdgeActId;

		private bool vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vDirTypeId = 9;
			vPrimActId = 65;
			vEdgeActId = 23;

			MockTasks
				.Setup(x => x.UpdateFactorDirector(
					MockApiCtx.Object,
					ActiveFactor,
					vDirTypeId,
					vPrimActId,
					vEdgeActId
				));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			var func = new AttachDirector(MockTasks.Object, FactorId, vDirTypeId, vPrimActId,vEdgeActId);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewDirector() {
			TestGo();
			Assert.True(vResult, "Incorrect Result.");
			CheckValidation();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CheckValidation() {
			base.CheckValidation();

			MockValidator.Verify(x => x.FactorDirector_TypeId(vDirTypeId,
				AttachDirector.DirTypeParam), Times.Once());
			MockValidator.Verify(x => x.FactorDirector_PrimaryActionId(vPrimActId,
				AttachDirector.PrimActionParam), Times.Once());
			MockValidator.Verify(x => x.FactorDirector_RelatedActionId(vEdgeActId,
				AttachDirector.EdgeActionParam), Times.Once());
		}

	}

}