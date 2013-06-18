using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Integration.Common;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XUpdateFactorVector : XModifyTasks {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(VectorTypeId.OppFavor, 92, SetupArtifacts.ArtifactId.Thi_Quality,
			VectorUnitId.None, VectorUnitPrefixId.Base)]
		public void Success(VectorTypeId pVecTypeId, long pValue, SetupArtifacts.ArtifactId pAxisArtId,
										VectorUnitId pVecUnitId, VectorUnitPrefixId pVecUnitPrefId) {
			var f = new Factor { FactorId = (long)SetupFactors.FactorId.FZ_Art_Music_Incomplete };

			Tasks.UpdateFactorVector(ApiCtx, f, (byte)pVecTypeId, pValue, (long)pAxisArtId,
				(byte)pVecUnitId, (byte)pVecUnitPrefId);

			Factor fac = GetVertex<Factor>(f.FactorId);
			Assert.NotNull(fac, "Updated Factor was deleted.");
			Assert.AreEqual((byte)pVecTypeId, fac.Vector_TypeId, "Incorrect Vector_TypeId.");

			////

			VertexConnections conn = GetVertexConnections(fac);
			conn.AssertEdgeCount(1, 2+1); //Factor starts with (1,2) (in,out) edges
			conn.AssertEdge<FactorVectorUsesAxisArtifact, Artifact>(true,
				(long)pAxisArtId, PropDbName.Artifact_ArtifactId);

			NewEdgeCount = 1;
		}

	}

}