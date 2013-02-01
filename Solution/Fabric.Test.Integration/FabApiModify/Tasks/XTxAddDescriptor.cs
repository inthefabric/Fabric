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

			////

			Descriptor newDescriptor = GetNode<Descriptor>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newDescriptor, "New Descriptor was not created.");

			int refRels = 0;
			if ( pPrimArtRefId != null ) { refRels++; }
			if ( pRelArtRefId != null ) { refRels++; }
			if ( pDescTypeRefId != null ) { refRels++; }

			NodeConnections conn = GetNodeConnections(newDescriptor);
			Log.Debug(conn+"");
			conn.AssertRelCount(2, 1+refRels);
			conn.AssertRel<RootContainsDescriptor, Root>(false, 0);
			conn.AssertRel<FactorUsesDescriptor, Factor>(false, f.FactorId);
			conn.AssertRel<DescriptorUsesDescriptorType, DescriptorType>(true, (long)pDescTypeId);

			if ( pPrimArtRefId != null ) {
				conn.AssertRel<DescriptorRefinesPrimaryWithArtifact, Artifact>(
					true, (long)pPrimArtRefId);
			}

			if ( pRelArtRefId != null ) {
				conn.AssertRel<DescriptorRefinesRelatedWithArtifact, Artifact>(
					true, (long)pRelArtRefId);
			}

			if ( pDescTypeRefId != null ) {
				conn.AssertRel<DescriptorRefinesTypeWithArtifact, Artifact>(
					true, (long)pDescTypeRefId);
			}

			NewNodeCount = 1;
			NewRelCount = 3+refRels;
		}

	}

}