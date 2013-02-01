using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetDescriptorMatch : XModifyTasks {

		private long vDescTypeId;
		private long? vPrimArtModId;
		private long? vRelArtModId;
		private long? vDescTypeModId;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private void SetParams(DescriptorTypeId pDescTypeId, SetupArtifacts.ArtifactId? pPrimArtModId,
				SetupArtifacts.ArtifactId? pRelArtModId, SetupArtifacts.ArtifactId? pDescTypeModId) {
			vDescTypeId = (long)pDescTypeId;
			vPrimArtModId = (long?)pPrimArtModId;
			vRelArtModId = (pRelArtModId == null ? (long?)null : (long)pRelArtModId);
			vDescTypeModId = (pDescTypeModId == null ? (long?)null : (long)pDescTypeModId);

		}

		/*--------------------------------------------------------------------------------------------*/
		private Descriptor TestGo() {
			return Tasks.GetDescriptorMatch(ApiCtx, vDescTypeId,
				vPrimArtModId, vRelArtModId, vDescTypeModId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(DescriptorTypeId.IsA, null, null, null, SetupFactors.DescriptorId.IsA)]
		[TestCase(DescriptorTypeId.IsA, null, null, SetupArtifacts.ArtifactId.Thi_Male,
			SetupFactors.DescriptorId.IsA_Male)]
		[TestCase(DescriptorTypeId.IsFoundIn, null, SetupArtifacts.ArtifactId.Thi_Home, null,
			SetupFactors.DescriptorId.IsFoundIn_Home)]
		[TestCase(DescriptorTypeId.HasA, SetupArtifacts.ArtifactId.Thi_Subject, null, null,
			SetupFactors.DescriptorId.HasA_Subject)]
		[TestCase(DescriptorTypeId.HasA, SetupArtifacts.ArtifactId.Thi_Object, 
			SetupArtifacts.ArtifactId.Thi_Blue, null, SetupFactors.DescriptorId.HasA_Object_Blue)]
		public void Found(DescriptorTypeId pDescTypeId, SetupArtifacts.ArtifactId? pPrimArtModId,
				SetupArtifacts.ArtifactId? pRelArtModId, SetupArtifacts.ArtifactId? pDescTypeModId,
				SetupFactors.DescriptorId pExpectDescId) {
			SetParams(pDescTypeId, pPrimArtModId, pRelArtModId, pDescTypeModId);

			Descriptor result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual((long)pExpectDescId, result.DescriptorId, "Incorrect DescriptorId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void NotFound(DescriptorTypeId pDescTypeId, SetupArtifacts.ArtifactId? pPrimArtModId,
				SetupArtifacts.ArtifactId? pRelArtModId, SetupArtifacts.ArtifactId? pDescTypeModId,
				SetupFactors.DescriptorId pExpectDescId) {
			SetParams(pDescTypeId, pPrimArtModId, pRelArtModId, pDescTypeModId);

			Descriptor result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}