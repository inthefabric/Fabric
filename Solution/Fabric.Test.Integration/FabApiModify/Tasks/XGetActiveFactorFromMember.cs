using Fabric.Db.Data.Setups;
using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetActiveFactorFromMember : XModifyTasks {

		private long vFactorId;
		private long vMemberId;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Factor TestGo() {
			return Tasks.GetActiveFactorFromMember(ApiCtx, vFactorId, vMemberId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupFactors.FactorId.BZ_Game_MlbGame_IsA_Attendance, SetupUsers.MemberId.BookZach)]
		[TestCase(SetupFactors.FactorId.GG_CutePho_Photo_IsA_Focal, SetupUsers.MemberId.GalGalData)]
		[TestCase(SetupFactors.FactorId.FZ_Art_Music_Incomplete, SetupUsers.MemberId.FabZach)]
		public void Found(long pFactorId, long pMemberId) {
			vFactorId = pFactorId;
			vMemberId = pMemberId;

			Factor result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(vFactorId, result.FactorId, "Incorrect FactorId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupFactors.FactorId.FZ_Zach_Human_IsA_Male_Def, SetupUsers.MemberId.GalZach)]
		[TestCase(SetupFactors.FactorId.FZ_Zach_Human_IsA_Male_Def, SetupUsers.MemberId.FabMel)]
		[TestCase(SetupFactors.FactorId.FZ_Zach_Human_IsA_WeightC_Del, SetupUsers.MemberId.FabZach)]
		public void NotFound(long pFactorId, long pMemberId) {
			vFactorId = pFactorId;
			vMemberId = pMemberId;

			Factor result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}