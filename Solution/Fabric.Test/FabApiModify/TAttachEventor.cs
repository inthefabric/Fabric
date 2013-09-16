using Fabric.Api.Modify;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class TAttachEventor : TAttachFactorElement {

		private byte vEveTypeId;
		private long vDateTime;

		private bool vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vEveTypeId = 9;
			vDateTime = 2529342323;

			MockTasks
				.Setup(x => x.UpdateFactorEventor(
					MockApiCtx.Object,
					ActiveFactor,
					vEveTypeId,
					vDateTime
				));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			var func = new AttachEventor(MockTasks.Object, FactorId, vEveTypeId, vDateTime);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewEventor() {
			TestGo();
			Assert.True(vResult, "Incorrect Result.");
			CheckValidation();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CheckValidation() {
			base.CheckValidation();

			MockValidator.Verify(x => x.FactorEventor_TypeId(vEveTypeId,
				AttachEventor.EveTypeParam), Times.Once());
			MockValidator.Verify(x => x.FactorEventor_DateTime(vDateTime,
				AttachEventor.DateTimeParam), Times.Once());
		}

	}

}