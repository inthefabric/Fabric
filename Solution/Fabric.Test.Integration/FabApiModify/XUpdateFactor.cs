using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	public abstract class XUpdateFactor : XBaseModifyFunc {

		protected long vFactorId;
		protected bool vCompleted;
		protected bool vDeleted;

		protected Factor vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;

			vFactorId = (long)SetupFactors.FactorId.FZ_Zach_AEI_RelTo_ViewSuggView;
			vCompleted = false;
			vDeleted = false;

			ApiCtx.SetAppUserId((long)AppFab, (long)UserZach);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void TestGo();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrFactorIdValue() {
			vFactorId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}

	}

}