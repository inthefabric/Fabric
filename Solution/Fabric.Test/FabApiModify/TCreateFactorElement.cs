using Fabric.Api.Modify;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	public abstract class TCreateFactorElement<T> : TBaseModifyFunc where T : FactorElementNode, new() {

		protected long FactorId { get; private set; }
		protected Factor ActiveFactor { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			FactorId = 89643743;
			SetUpMember(1, 2, new Member { MemberId = 2523 });
			SetupActiveFactor(new Factor { FactorId = FactorId });
			SetupFactorHasElement(false);
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
		protected abstract void SetupFactorHasElement(bool pResult);
		protected abstract void TestGo();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected virtual void CheckValidation() {
			MockValidator.Verify(x => x.FactorId(FactorId,
				CreateFactorElement.FactorParam), Times.Once());
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrFactorHasElement() {
			SetupFactorHasElement(true);
			TestUtil.CheckThrows<FabPreventedFault>(true, TestGo);
		}

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

	}

}