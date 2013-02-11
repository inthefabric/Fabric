using Fabric.Api.Modify;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class TUpdateFactor : TBaseModifyFunc {

		private long vFactorId;
		private bool vCompleted;
		private bool vDeleted;

		private Factor vResultFactor;
		private Factor vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vFactorId = 1251253;
			vCompleted = false;
			vDeleted = false;

			vResultFactor = new Factor();
			SetUpMember(1, 2, new Member { MemberId = 234623 });

			MockTasks
				.Setup(x => x.GetActiveFactorFromMember(
						MockApiCtx.Object,
						vFactorId,
						ApiCtxMember.MemberId
					)
				)
				.Returns(vResultFactor);

			MockTasks
				.Setup(x => x.FactorHasDescriptor(MockApiCtx.Object, vResultFactor))
				.Returns(true);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new UpdateFactor(MockTasks.Object, vFactorId, vCompleted, vDeleted);
			vResult = func.Go(MockApiCtx.Object);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void Success(bool pValue) {
			vCompleted = pValue;
			vDeleted = !vCompleted;

			MockTasks
				.Setup(x => x.UpdateFactor(
						MockApiCtx.Object,
						vResultFactor,
						vCompleted,
						vDeleted
					)
				)
				.Returns(vResultFactor);

			TestGo();

			Assert.AreEqual(vResultFactor, vResult, "Incorrect Result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void ErrCompletedEqualsDeleted(bool pValue) {
			vCompleted = vDeleted = pValue;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void ErrFactorNotFound(bool pValue) {
			vCompleted = pValue;
			vDeleted = !vCompleted;

			MockTasks
				.Setup(x => x.GetActiveFactorFromMember(
						MockApiCtx.Object,
						vFactorId,
						ApiCtxMember.MemberId
					)
				)
				.Returns((Factor)null);

			TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrFactorAlreadyCompleted() {
			vCompleted = true;
			vResultFactor.Completed = 12343255;
			TestUtil.CheckThrows<FabPreventedFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrFactorHasNoDescriptor() {
			vCompleted = true;

			MockTasks
				.Setup(x => x.FactorHasDescriptor(MockApiCtx.Object, vResultFactor))
				.Returns(false);

			TestUtil.CheckThrows<FabPreventedFault>(true, TestGo);
		}

	}

}