using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Db;
using Fabric.Test.Integration.Common;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XTxAddVector : XModifyTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(VectorTypeId.OppFavor, 92, SetupArtifacts.ArtifactId.Thi_Quality,
			VectorUnitId.None, VectorUnitPrefixId.Base)]
		public void Success(VectorTypeId pVecTypeId, long pValue, SetupArtifacts.ArtifactId pAxisArtId,
										VectorUnitId pVecUnitId, VectorUnitPrefixId pVecUnitPrefId) {
			IWeaverVarAlias<Vector> elemVar;
			var f = new Factor { FactorId = (long)SetupFactors.FactorId.FZ_Art_Music_Incomplete };

			Tasks.TxAddVector(ApiCtx, TxBuild,
				(long)pVecTypeId, pValue, (long)pAxisArtId, (long)pVecUnitId,
				(long)pVecUnitPrefId, f, out elemVar);
			FinishTx();

			ApiCtx.DbData("TEST.TxAddVector", TxBuild.Transaction);

			Vector newVector = GetNode<Vector>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newVector, "New Vector was not created.");
			Assert.AreNotEqual(0, newVector.VectorId, "Incorrect VectorId.");
			Assert.AreEqual(pValue, newVector.Value, "Incorrect Value.");

			NodeConnections conn = GetNodeConnections(newVector);
			conn.AssertRelCount(2, 4);
			conn.AssertRel<RootContainsVector, Root>(false, 0);
			conn.AssertRel<FactorUsesVector, Factor>(false, f.FactorId);
			conn.AssertRel<VectorUsesVectorType, VectorType>(true, (long)pVecTypeId);
			conn.AssertRel<VectorUsesAxisArtifact, Artifact>(true, (long)pAxisArtId);
			conn.AssertRel<VectorUsesVectorUnit, VectorUnit>(true, (long)pVecUnitId);
			conn.AssertRel<VectorUsesVectorUnitPrefix, VectorUnitPrefix>(true, (long)pVecUnitPrefId);

			NewNodeCount = 1;
			NewRelCount = 6;
		}

	}

}