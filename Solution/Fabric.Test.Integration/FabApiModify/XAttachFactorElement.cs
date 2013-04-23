using Fabric.Db.Data.Setups;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	public abstract class XAttachFactorElement : XBaseModifyFunc {

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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrFactorIdValue() {
			FactorId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}

	}

}