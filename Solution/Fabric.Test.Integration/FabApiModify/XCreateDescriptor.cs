using Fabric.Api.Modify;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Fabric.Test.Integration.Common;
using Fabric.Test.Integration.FabApiModify.Tasks;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XCreateDescriptor : XCreateFactorElement {

		private const SetupArtifacts.ArtifactId ArtA = SetupArtifacts.ArtifactId.Thi_Male;
		private const SetupArtifacts.ArtifactId ArtB = SetupArtifacts.ArtifactId.User_Ellie;
		private const SetupArtifacts.ArtifactId ArtC = SetupArtifacts.ArtifactId.App_Bookmarker;

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

			vDescTypeId = (long)DescriptorTypeId.IsA;
			vPrimArtRefId = (long)SetupArtifacts.ArtifactId.Thi_Aei;
			vRelArtRefId = (long)SetupArtifacts.ArtifactId.Thi_Evolution;
			vDescTypeRefId = (long)SetupArtifacts.ArtifactId.Thi_Blue;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			var func = new CreateDescriptor(Tasks, FactorId, vDescTypeId,
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

			XTxAddDescriptor.CheckNewDescriptorConns(conn, FactorId, vDescTypeId, vPrimArtRefId,
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
			conn.AssertRel<FactorUsesDescriptor, Factor>(false, FactorId);

			NewNodeCount = 0;
			NewRelCount = 1;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(SetupTypes.NumDescriptorTypes+1)]
		public void ErrDescriptorTypeRange(int pId) {
			vDescTypeId = pId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrPrimaryArtifactValue() {
			vPrimArtRefId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrRelatedArtifactValue() {
			vRelArtRefId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrTypeArtifactValue() {
			vDescTypeRefId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}

	}

}