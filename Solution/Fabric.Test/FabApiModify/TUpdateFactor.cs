using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify {

	/*================================================================================================*/
	public abstract class TUpdateFactor : TBaseModifyFunc {

		protected long vFactorId;
		protected bool vCompleted;
		protected bool vDeleted;

		protected Factor vResultFactor;
		protected Factor vResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vFactorId = 1251253;

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
		protected abstract void TestGo();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
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
		[Test]
		public void ErrFactorNotFound() {
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

	}

}