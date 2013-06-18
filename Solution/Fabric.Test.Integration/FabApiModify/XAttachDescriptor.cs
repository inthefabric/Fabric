using Fabric.Api.Modify;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Domain.Types;
using Fabric.Test.Integration.Common;
using Fabric.Test.Integration.FabApiModify.Tasks;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XAttachDescriptor : XAttachFactorElement {

		private const SetupArtifacts.ArtifactId ArtA = SetupArtifacts.ArtifactId.Thi_Male;
		private const SetupArtifacts.ArtifactId ArtB = SetupArtifacts.ArtifactId.User_Ellie;
		private const SetupArtifacts.ArtifactId ArtC = SetupArtifacts.ArtifactId.App_Bookmarker;

		private byte vDescTypeId;
		private long? vPrimArtRefId;
		private long? vRelArtRefId;
		private long? vDescTypeRefId;
		
		private bool vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;

			vDescTypeId = (byte)DescriptorTypeId.IsA;
			vPrimArtRefId = (long)SetupArtifacts.ArtifactId.Thi_Aei;
			vRelArtRefId = (long)SetupArtifacts.ArtifactId.Thi_Evolution;
			vDescTypeRefId = (long)SetupArtifacts.ArtifactId.Thi_Blue;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestGo() {
			var func = new AttachDescriptor(Tasks, FactorId, vDescTypeId,
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

			vDescTypeId = (byte)pDescTypeId;
			vPrimArtRefId = (long?)pPrimArtRefId;
			vRelArtRefId = (long?)pRelArtRefId;
			vDescTypeRefId = (long?)pDescTypeRefId;
			
			TestGo();

			Assert.True(vResult, "Incorrect Result.");
			
			Factor updatedFactor = GetVertex<Factor>(FactorId);
			Assert.NotNull(updatedFactor, "Updated Factor was deleted.");
			Assert.AreEqual(vDescTypeId, updatedFactor.Descriptor_TypeId,
				"Incorrect Descriptor_TypeId.");

			VertexConnections conn = GetVertexConnections(updatedFactor);
			int relCount;

			XUpdateFactorDescriptor.CheckNewDescriptorConns(conn, FactorId, vDescTypeId, vPrimArtRefId,
				vRelArtRefId, vDescTypeRefId, out relCount);

			NewRelCount = relCount;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(1)]
		public void ErrDescriptorTypeRange(byte pId) {
			vDescTypeId = pId;

			if ( pId == 1 ) {
				vDescTypeId = (byte)(StaticTypes.DescriptorTypes.Keys.Count+1);
			}

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