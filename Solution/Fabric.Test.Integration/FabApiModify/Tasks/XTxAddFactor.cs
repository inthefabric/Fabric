﻿using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddFactor : XModifyTasks {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(SetupArtifacts.ArtifactId.App_KinPhoGal, SetupArtifacts.ArtifactId.Thi_Favorite,
			FactorAssertionId.Fact, true, "this is a note.", SetupUsers.MemberId.GalZach)]
		public void Success(SetupArtifacts.ArtifactId pPrimArtId, SetupArtifacts.ArtifactId pEdgeArtId,
				FactorAssertionId pAssertId, bool pIsDef, string pNote, SetupUsers.MemberId pMemberId) {
			var mem = new Member { MemberId = (long)pMemberId };
			IWeaverVarAlias<Factor> factorVar;

			Tasks.TxAddFactor(ApiCtx, TxBuild, (long)pPrimArtId, (long)pEdgeArtId, (byte)pAssertId, 
				pIsDef, pNote, mem, out factorVar);
			FinishTx();

			ApiCtx.DbData("TEST.TxAddFactor", TxBuild.Transaction);

			////

			Factor newFactor = GetVertex<Factor>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newFactor, "New Factor was not created.");
			Assert.AreNotEqual(0, newFactor.FactorId, "Incorrect FactorId.");
			Assert.AreEqual(pIsDef, newFactor.IsDefining, "Incorrect IsDefining.");
			Assert.AreEqual(pNote, newFactor.Note, "Incorrect Note.");
			Assert.AreNotEqual(0, newFactor.Created, "Incorrect Created.");
			Assert.Null(newFactor.Completed, "Incorrect Completed.");
			Assert.Null(newFactor.Deleted, "Incorrect Deleted.");
			
			const string artId = PropDbName.Artifact_ArtifactId;

			VertexConnections conn = GetVertexConnections(newFactor);
			conn.AssertEdgeCount(1, 2);
			conn.AssertEdge<MemberCreatesFactor, Member>(false, (long)pMemberId);
			conn.AssertEdge<FactorUsesPrimaryArtifact, Artifact>(true, (long)pPrimArtId, artId);
			conn.AssertEdge<FactorUsesRelatedArtifact, Artifact>(true, (long)pEdgeArtId, artId);

			NewVertexCount = 1;
			NewEdgeCount = 3;
		}

	}

}