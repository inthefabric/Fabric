using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XUpdateFactorDescriptor : XModifyTasks {

		private const SetupArtifacts.ArtifactId ArtA = SetupArtifacts.ArtifactId.Thi_Male;
		private const SetupArtifacts.ArtifactId ArtB = SetupArtifacts.ArtifactId.User_Ellie;
		private const SetupArtifacts.ArtifactId ArtC = SetupArtifacts.ArtifactId.App_Bookmarker;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(DescriptorTypeId.IsA, null, null, null)]
		[TestCase(DescriptorTypeId.IsA, ArtA, null, null)]
		[TestCase(DescriptorTypeId.IsA, null, ArtA, null)]
		[TestCase(DescriptorTypeId.IsA, null, null, ArtA)]
		[TestCase(DescriptorTypeId.IsA, ArtA, ArtB, null)]
		[TestCase(DescriptorTypeId.IsA, ArtB, null, ArtA)]
		[TestCase(DescriptorTypeId.IsA, null, ArtA, ArtB)]
		[TestCase(DescriptorTypeId.IsA, ArtA, ArtB, ArtC)]
		public void Success(DescriptorTypeId pDescTypeId, SetupArtifacts.ArtifactId? pPrimArtRefId,
				SetupArtifacts.ArtifactId? pDescTypeRefId, SetupArtifacts.ArtifactId? pRelArtRefId) {
			var f = new Factor { FactorId = (long)SetupFactors.FactorId.FZ_Art_Music_Incomplete };

			Tasks.UpdateFactorDescriptor(ApiCtx, f, (byte)pDescTypeId,
				(long?)pPrimArtRefId, (long?)pRelArtRefId, (long?)pDescTypeRefId);

			Factor updatedFactor = GetNode<Factor>(f.FactorId);
			Assert.NotNull(updatedFactor, "Updated Factor was deleted.");

			NodeConnections conn = GetNodeConnections(updatedFactor);
			int relCount;

			CheckNewDescriptorConns(conn, f.FactorId, (byte)pDescTypeId, (long?)pPrimArtRefId,
				(long?)pRelArtRefId, (long?)pDescTypeRefId, out relCount);

			NewRelCount = relCount;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void CheckNewDescriptorConns(NodeConnections pConn, long pFactorId,
											byte pDescTypeId, long? pPrimArtRefId, long? pRelArtRefId, 
											long? pDescTypeRefId, out int pRelCount) {

			int refRels = 0;
			if ( pPrimArtRefId != null ) { refRels++; }
			if ( pRelArtRefId != null ) { refRels++; }
			if ( pDescTypeRefId != null ) { refRels++; }

			string idProp = typeof(Artifact).Name+"Id";

			if ( pPrimArtRefId != null ) {
				pConn.AssertRel<FactorRefinesPrimaryWithArtifact, Artifact>(
					true, (long)pPrimArtRefId, idProp);
			}

			if ( pRelArtRefId != null ) {
				pConn.AssertRel<FactorRefinesRelatedWithArtifact, Artifact>(
					true, (long)pRelArtRefId, idProp);
			}

			if ( pDescTypeRefId != null ) {
				pConn.AssertRel<FactorRefinesTypeWithArtifact, Artifact>(
					true, (long)pDescTypeRefId, idProp);
			}

			pConn.AssertRelCount(1, 2+refRels); //factor has 3 initial rels
			pRelCount = refRels;
		}

	}

}