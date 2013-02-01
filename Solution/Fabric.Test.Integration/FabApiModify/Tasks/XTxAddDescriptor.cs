using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddDescriptor : XModifyTasks {

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

			IWeaverVarAlias<Descriptor> elemVar;
			var f = new Factor { FactorId = (long)SetupFactors.FactorId.FZ_Art_Music_Incomplete };

			Tasks.TxAddDescriptor(ApiCtx, TxBuild, (long)pDescTypeId,
				(long?)pPrimArtRefId, (long?)pRelArtRefId, (long?)pDescTypeRefId, f, out elemVar);
			FinishTx();

			ApiCtx.DbData("TEST.TxAddDescriptor", TxBuild.Transaction);

			Descriptor newDescriptor = GetNode<Descriptor>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newDescriptor, "New Descriptor was not created.");

			NodeConnections conn = GetNodeConnections(newDescriptor);
			int relCount;

			CheckNewDescriptorConns(conn, f.FactorId, (long)pDescTypeId, (long?)pPrimArtRefId,
				(long?)pRelArtRefId, (long?)pDescTypeRefId, out relCount);

			NewNodeCount = 1;
			NewRelCount = relCount;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void CheckNewDescriptorConns(NodeConnections pConn, long pFactorId,
											long pDescTypeId, long? pPrimArtRefId, long? pRelArtRefId, 
											long? pDescTypeRefId, out int pRelCount) {

			int refRels = 0;
			if ( pPrimArtRefId != null ) { refRels++; }
			if ( pRelArtRefId != null ) { refRels++; }
			if ( pDescTypeRefId != null ) { refRels++; }

			pConn.AssertRelCount(2, 1+refRels);
			pConn.AssertRel<RootContainsDescriptor, Root>(false, 0);
			pConn.AssertRel<FactorUsesDescriptor, Factor>(false, pFactorId);
			pConn.AssertRel<DescriptorUsesDescriptorType, DescriptorType>(true, pDescTypeId);

			if ( pPrimArtRefId != null ) {
				pConn.AssertRel<DescriptorRefinesPrimaryWithArtifact, Artifact>(
					true, (long)pPrimArtRefId);
			}

			if ( pRelArtRefId != null ) {
				pConn.AssertRel<DescriptorRefinesRelatedWithArtifact, Artifact>(
					true, (long)pRelArtRefId);
			}

			if ( pDescTypeRefId != null ) {
				pConn.AssertRel<DescriptorRefinesTypeWithArtifact, Artifact>(
					true, (long)pDescTypeRefId);
			}

			pRelCount = 3+refRels;
		}

	}

}