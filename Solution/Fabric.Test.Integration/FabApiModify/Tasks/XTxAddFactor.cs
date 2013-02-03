using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddFactor : XModifyTasks {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupArtifacts.ArtifactId.App_KinPhoGal, SetupArtifacts.ArtifactId.Thi_Favorite,
			FactorAssertionId.Fact, true, "this is a note.", SetupUsers.MemberId.GalZach)]
		public void Success(SetupArtifacts.ArtifactId pPrimArtId, SetupArtifacts.ArtifactId pRelArtId,
				FactorAssertionId pAssertId, bool pIsDef, string pNote, SetupUsers.MemberId pMemberId) {
			IWeaverVarAlias<Root> rootVar;
			var mem = new Member { MemberId = (long)pMemberId };
			IWeaverVarAlias<Factor> factorVar;

			TxBuild.GetRoot(out rootVar);
			Tasks.TxAddFactor(ApiCtx, TxBuild, (long)pPrimArtId, (long)pRelArtId, (long)pAssertId, 
				pIsDef, pNote, mem, out factorVar);
			FinishTx();

			ApiCtx.DbData("TEST.TxAddFactor", TxBuild.Transaction);

			////

			Factor newFactor = GetNode<Factor>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newFactor, "New Factor was not created.");
			Assert.AreNotEqual(0, newFactor.FactorId, "Incorrect FactorId.");
			Assert.AreEqual(pIsDef, newFactor.IsDefining, "Incorrect IsDefining.");
			Assert.AreEqual(pNote, newFactor.Note, "Incorrect Note.");
			Assert.AreNotEqual(0, newFactor.Created, "Incorrect Created.");
			Assert.Null(newFactor.Completed, "Incorrect Completed.");
			Assert.Null(newFactor.Deleted, "Incorrect Deleted.");
			
			NodeConnections conn = GetNodeConnections(newFactor);
			conn.AssertRelCount(2, 3);
			conn.AssertRel<RootContainsFactor, Root>(false, 0);
			conn.AssertRel<MemberCreatesFactor, Member>(false, (long)pMemberId);
			conn.AssertRel<FactorUsesPrimaryArtifact, Artifact>(true, (long)pPrimArtId);
			conn.AssertRel<FactorUsesRelatedArtifact, Artifact>(true, (long)pRelArtId);
			conn.AssertRel<FactorUsesFactorAssertion, FactorAssertion>(true, (long)pAssertId);

			NewNodeCount = 1;
			NewRelCount = 5;
		}

	}

}