using Fabric.Api.Modify;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Integration.Common;
using Fabric.Test.Integration.FabApiModify.Tasks;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XCreateDescriptor : XBaseModifyFunc {

		private const SetupArtifacts.ArtifactId ArtA = SetupArtifacts.ArtifactId.Thi_Male;
		private const SetupArtifacts.ArtifactId ArtB = SetupArtifacts.ArtifactId.User_Ellie;
		private const SetupArtifacts.ArtifactId ArtC = SetupArtifacts.ArtifactId.App_Bookmarker;

		private long vFactorId; //TODO: base class

		private long vDescTypeId;
		private long? vPrimArtRefId;
		private long? vRelArtRefId;
		private long? vDescTypeRefId;
		
		private Descriptor vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;

			vFactorId = (long)SetupFactors.FactorId.FZ_Art_Music_Incomplete; //TODO: base class
			ApiCtx.SetAppUserId((long)AppFab, (long)UserZach); //TODO: base class

			/*vDescTypeId = (long)DescriptorTypeId.IsA;
			vPrimArtRefId = (long)SetupArtifacts.ArtifactId.Thi_Aei;
			vRelArtRefId = (long)SetupArtifacts.ArtifactId.Thi_Evolution;
			vDescTypeRefId = (long)SetupArtifacts.ArtifactId.Thi_Blue;*/
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new CreateDescriptor(Tasks, vFactorId, vDescTypeId,
				vPrimArtRefId, vRelArtRefId, vDescTypeRefId);
			vResult = func.Go(ApiCtx);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(DescriptorTypeId.SmellsLike, null, null, null)]
		[TestCase(DescriptorTypeId.SmellsLike, ArtA, null, null)]
		[TestCase(DescriptorTypeId.SmellsLike, null, ArtA, null)]
		[TestCase(DescriptorTypeId.SmellsLike, null, null, ArtA)]
		[TestCase(DescriptorTypeId.SmellsLike, ArtA, ArtB, null)]
		[TestCase(DescriptorTypeId.SmellsLike, ArtB, null, ArtA)]
		[TestCase(DescriptorTypeId.SmellsLike, null, ArtA, ArtB)]
		[TestCase(DescriptorTypeId.SmellsLike, ArtA, ArtB, ArtC)]
		public void NewDescriptor(DescriptorTypeId pDescTypeId,SetupArtifacts.ArtifactId? pPrimArtRefId,
				SetupArtifacts.ArtifactId? pDescTypeRefId, SetupArtifacts.ArtifactId? pRelArtRefId) {
			IsReadOnlyTest = false;

			vDescTypeId = (long)pDescTypeId;
			vPrimArtRefId = (long?)pPrimArtRefId;
			vRelArtRefId = (long?)pRelArtRefId;
			vDescTypeRefId = (long?)pDescTypeRefId;
			
			TestGo();
			
			Assert.NotNull(vResult, "Result should not be null.");
			
			////
			
			Descriptor newDescriptor = GetNode<Descriptor>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newDescriptor, "New Descriptor was not created.");
			Assert.AreEqual(newDescriptor.DescriptorId, vResult.DescriptorId,
				"Incorrect Result.DescriptorId.");

			NodeConnections conn = GetNodeConnections(newDescriptor);
			int relCount;

			XTxAddDescriptor.CheckNewDescriptorConns(conn, vFactorId, vDescTypeId, vPrimArtRefId,
				vRelArtRefId, vDescTypeRefId, out relCount);

			NewNodeCount = 1;
			NewRelCount = relCount;
		}

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
		public void ExistingDescriptor(DescriptorTypeId pDescTypeId,
					SetupArtifacts.ArtifactId? pPrimArtRefId, SetupArtifacts.ArtifactId? pDescTypeRefId,
					SetupArtifacts.ArtifactId? pRelArtRefId, SetupFactors.DescriptorId pExpectDescId) {
			IsReadOnlyTest = false;

			vDescTypeId = (long)pDescTypeId;
			vPrimArtRefId = (long?)pPrimArtRefId;
			vRelArtRefId = (long?)pRelArtRefId;
			vDescTypeRefId = (long?)pDescTypeRefId;

			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");

			////

			Descriptor newDescriptor = GetNode<Descriptor>((long)pExpectDescId);
			NodeConnections conn = GetNodeConnections(newDescriptor);
			conn.AssertRel<FactorUsesDescriptor, Factor>(false, vFactorId);

			NewNodeCount = 0;
			NewRelCount = 1;
		}

		
		//TEST: XCreateDescriptor validation

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void ErrNameNull() {
			vName = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------* /
		[TestCase(3)]
		[TestCase(17)]
		public void ErrNameLength(int pLength) {
			vName = new string('a', pLength);
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void ErrNameInvalid() {
			vName = "zach@test";
			TestUtil.CheckThrows<FabArgumentFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------* /
		[Test]
		public void ErrNameDuplicate() {
			vName = "ZachKinstner";
			TestUtil.CheckThrows<FabDuplicateFault>(true, TestGo);
		}*/

	}

}