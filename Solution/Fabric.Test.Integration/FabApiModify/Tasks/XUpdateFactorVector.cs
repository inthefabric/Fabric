using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Domain;
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

			Factor fac = GetNode<Factor>(f.FactorId);
			Assert.NotNull(fac, "Updated Factor was deleted.");
			Assert.AreEqual((byte)pVecTypeId, fac.Vector_TypeId, "Incorrect Vector_TypeId.");

			////

			NodeConnections conn = GetNodeConnections(fac);
			conn.AssertRelCount(1, 2+1); //Factor starts with (1,2) (in,out) rels
			conn.AssertRel<FactorUsesAxisArtifact, Artifact>(true,
				(long)pAxisArtId, typeof(Artifact).Name+"Id");

			NewRelCount = 1;
		}

	}

}