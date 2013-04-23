using Fabric.Api.Modify;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	public abstract class TAttachFactorElement : TBaseModifyFunc {

		protected long FactorId { get; private set; }
		protected Factor ActiveFactor { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			FactorId = 89643743;
			SetUpMember(1, 2, new Member { MemberId = 2523 });
			SetupActiveFactor(new Factor { FactorId = FactorId });
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void SetupActiveFactor(Factor pFactor) {
			ActiveFactor = pFactor;

			MockTasks
				.Setup(x =>x.GetActiveFactorFromMember(
						MockApiCtx.Object,
						FactorId,
						ApiCtxMember.MemberId
					)
				)
				.Returns(ActiveFactor);
		}

		/*--------------------------------------------------------------------------------------------*/
		//protected abstract void SetupFactorHasElement();
		protected abstract void TestGo();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected virtual void CheckValidation() {
			MockValidator.Verify(x => x.FactorId(FactorId,
				AttachFactorElement.FactorParam), Times.Once());
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrFactorNotFound() {
			SetupActiveFactor(null);
			TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrFactorCompleted() {
			ActiveFactor.Completed = 123456;
			TestUtil.CheckThrows<FabPreventedFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
 		[Test]
		public void ErrFactorHasElement() {
			ActiveFactor.Descriptor_TypeId = 1;
			ActiveFactor.Director_TypeId = 1;
			ActiveFactor.Eventor_TypeId = 1;
			ActiveFactor.Identor_TypeId = 1;
			ActiveFactor.Locator_TypeId = 1;
			ActiveFactor.Vector_TypeId = 1;
			TestUtil.CheckThrows<FabPreventedFault>(true, TestGo);
		}

	}

}