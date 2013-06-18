using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
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
				SetupArtifacts.ArtifactId? pDescTypeRefId, SetupArtifacts.ArtifactId? pEdgeArtRefId) {
			var f = new Factor { FactorId = (long)SetupFactors.FactorId.FZ_Art_Music_Incomplete };

			Tasks.UpdateFactorDescriptor(ApiCtx, f, (byte)pDescTypeId,
				(long?)pPrimArtRefId, (long?)pEdgeArtRefId, (long?)pDescTypeRefId);

			Factor updatedFactor = GetVertex<Factor>(f.FactorId);
			Assert.NotNull(updatedFactor, "Updated Factor was deleted.");

			VertexConnections conn = GetVertexConnections(updatedFactor);
			int edgeCount;

			CheckNewDescriptorConns(conn, f.FactorId, (byte)pDescTypeId, (long?)pPrimArtRefId,
				(long?)pEdgeArtRefId, (long?)pDescTypeRefId, out edgeCount);

			NewEdgeCount = edgeCount;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void CheckNewDescriptorConns(VertexConnections pConn, long pFactorId,
											byte pDescTypeId, long? pPrimArtRefId, long? pEdgeArtRefId, 
											long? pDescTypeRefId, out int pEdgeCount) {

			int refEdges = 0;
			if ( pPrimArtRefId != null ) { refEdges++; }
			if ( pEdgeArtRefId != null ) { refEdges++; }
			if ( pDescTypeRefId != null ) { refEdges++; }

			const string idProp = PropDbName.Artifact_ArtifactId;

			if ( pPrimArtRefId != null ) {
				pConn.AssertEdge<FactorDescriptorRefinesPrimaryWithArtifact, Artifact>(
					true, (long)pPrimArtRefId, idProp);
			}

			if ( pEdgeArtRefId != null ) {
				pConn.AssertEdge<FactorDescriptorRefinesRelatedWithArtifact, Artifact>(
					true, (long)pEdgeArtRefId, idProp);
			}

			if ( pDescTypeRefId != null ) {
				pConn.AssertEdge<FactorDescriptorRefinesTypeWithArtifact, Artifact>(
					true, (long)pDescTypeRefId, idProp);
			}

			pConn.AssertEdgeCount(1, 2+refEdges); //factor has 3 initial edges
			pEdgeCount = refEdges;
		}

	}

}