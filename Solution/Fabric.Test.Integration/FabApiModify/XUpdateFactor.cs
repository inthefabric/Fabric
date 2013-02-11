using Fabric.Db.Data.Setups;
using Fabric.Domain;

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

	}

}