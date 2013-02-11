using Fabric.Db.Data.Setups;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	public abstract class XCreateFactorElement : XBaseModifyFunc {

		protected long FactorId { get; private set; }
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			FactorId = (long)SetupFactors.FactorId.FZ_Art_Music_Incomplete;
			ApiCtx.SetAppUserId((long)AppFab, (long)UserZach);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected abstract void TestGo();

	}

}