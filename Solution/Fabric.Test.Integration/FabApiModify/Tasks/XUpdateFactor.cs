using Fabric.Db.Data.Setups;
using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XUpdateFactor : XModifyTasks {

		private long vFactorId;
		private bool vCompleted;
		private bool vDeleted;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vFactorId = 0;
			vCompleted = false;
			vDeleted = false;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Factor TestGo() {
			var f = new Factor { FactorId = vFactorId };
			return Tasks.UpdateFactor(ApiCtx, f, vCompleted, vDeleted);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupFactors.FactorId.FZ_Art_Music_Incomplete)]
		public void Completed(SetupFactors.FactorId pFactorId) {
			vFactorId = (long)pFactorId;
			vCompleted = true;

			Factor result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vFactorId, result.FactorId, "Incorrect FactorId.");
			Assert.NotNull(result.Completed, "Completed should not be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupFactors.FactorId.FZ_Art_Music_Incomplete)]
		[TestCase(SetupFactors.FactorId.FZ_Zach_AEI_RelTo_ViewSuggView)]
		[TestCase(SetupFactors.FactorId.BB_Game_Tigers_HasA_Def)]
		[TestCase(SetupFactors.FactorId.GG_CutePho_Photo_IsA_Focal)]
		public void Deleted(SetupFactors.FactorId pFactorId) {
			vFactorId = (long)pFactorId;
			vDeleted = true;

			Factor result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vFactorId, result.FactorId, "Incorrect FactorId.");
			Assert.NotNull(result.Deleted, "Deleted should not be null.");
		}

	}

}