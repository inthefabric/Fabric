using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Domain.Types;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetDescriptorMatch : XModifyTasks {

		private long vDescTypeId;
		private long? vPrimArtRefId;
		private long? vRelArtRefId;
		private long? vDescTypeRefId;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Descriptor TestGo() {
			return Tasks.GetDescriptorMatch(ApiCtx, vDescTypeId,
				vPrimArtRefId, vRelArtRefId, vDescTypeRefId);
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
			null, SetupArtifacts.ArtifactId.Thi_Blue, SetupFactors.DescriptorId.HasA_Object_Blue)]
		public void Found(DescriptorTypeId pDescTypeId, SetupArtifacts.ArtifactId? pPrimArtRefId,
				SetupArtifacts.ArtifactId? pDescTypeRefId, SetupArtifacts.ArtifactId? pRelArtRefId,
				SetupFactors.DescriptorId pExpectDescId) {
			vDescTypeId = (long)pDescTypeId;
			vPrimArtRefId = (long?)pPrimArtRefId;
			vRelArtRefId = (long?)pRelArtRefId;
			vDescTypeRefId = (long?)pDescTypeRefId;

			Descriptor result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual((long)pExpectDescId, result.DescriptorId, "Incorrect DescriptorId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(DescriptorTypeId.IsA, null, SetupArtifacts.ArtifactId.Thi_Male, null)]
		[TestCase(DescriptorTypeId.IsA, SetupArtifacts.ArtifactId.Thi_Male, null, null)]
		[TestCase(DescriptorTypeId.HasA, null, SetupArtifacts.ArtifactId.Thi_Object,
			SetupArtifacts.ArtifactId.Thi_Blue)]
		[TestCase(DescriptorTypeId.HasA, SetupArtifacts.ArtifactId.Thi_Object,
			SetupArtifacts.ArtifactId.Thi_Blue, null)]
		[TestCase(DescriptorTypeId.HasA, null, null, SetupArtifacts.ArtifactId.Thi_FocalLength)]
		public void NotFound(DescriptorTypeId pDescTypeId, SetupArtifacts.ArtifactId? pPrimArtRefId,
				SetupArtifacts.ArtifactId? pDescTypeRefId, SetupArtifacts.ArtifactId? pRelArtRefId) {
			vDescTypeId = (long)pDescTypeId;
			vPrimArtRefId = (long?)pPrimArtRefId;
			vRelArtRefId = (long?)pRelArtRefId;
			vDescTypeRefId = (long?)pDescTypeRefId;

			Descriptor result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}