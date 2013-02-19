using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Db;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XGetVectorMatch : XModifyTasks {

		private long vVecTypeId;
		private long vValue;
		private long vAxisArtId;
		private long vVecUnitId;
		private long vVecUnitPrefId;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		private Vector TestGo() {
			return Tasks.GetVectorMatch(ApiCtx, vVecTypeId, vValue,
				vAxisArtId, vVecUnitId, vVecUnitPrefId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(VectorTypeId.PosLong, 3960, SetupArtifacts.ArtifactId.Thi_GradePointAvg,
			VectorUnitId.Point, VectorUnitPrefixId.Milli, SetupFactors.VectorId.GPA_3960_MilliPoints)]
		[TestCase(VectorTypeId.OppFavor, 92, SetupArtifacts.ArtifactId.Thi_Quality,
			VectorUnitId.None, VectorUnitPrefixId.Base, SetupFactors.VectorId.Quality_92_None)]
		public void Found(VectorTypeId pVecTypeId, long pValue, SetupArtifacts.ArtifactId pAxisArtId,
											VectorUnitId pVecUnitId, VectorUnitPrefixId pVecUnitPrefId,
											SetupFactors.VectorId pExpectVecId) {	
			vVecTypeId = (long)pVecTypeId;
			vValue = pValue;
			vAxisArtId = (long)pAxisArtId;
			vVecUnitId = (long)pVecUnitId;
			vVecUnitPrefId = (long)pVecUnitPrefId;

			Vector result = TestGo();

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual((long)pExpectVecId, result.VectorId, "Incorrect VectorId.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(VectorTypeId.OppAgree, 92, SetupArtifacts.ArtifactId.Thi_Quality,
			VectorUnitId.None, VectorUnitPrefixId.Base)]
		[TestCase(VectorTypeId.OppFavor, 93, SetupArtifacts.ArtifactId.Thi_Quality,
			VectorUnitId.None, VectorUnitPrefixId.Base)]
		[TestCase(VectorTypeId.OppFavor, 92, SetupArtifacts.ArtifactId.Thi_Art,
			VectorUnitId.None, VectorUnitPrefixId.Base)]
		[TestCase(VectorTypeId.OppFavor, 92, SetupArtifacts.ArtifactId.Thi_Quality,
			VectorUnitId.Area, VectorUnitPrefixId.Base)]
		[TestCase(VectorTypeId.OppFavor, 92, SetupArtifacts.ArtifactId.Thi_Quality,
			VectorUnitId.None, VectorUnitPrefixId.Milli)]
		public void NotFound(VectorTypeId pVecTypeId, long pValue, 
										SetupArtifacts.ArtifactId pAxisArtId, VectorUnitId pVecUnitId,
										VectorUnitPrefixId pVecUnitPrefId) {	
			vVecTypeId = (long)pVecTypeId;
			vValue = pValue;
			vAxisArtId = (long)pAxisArtId;
			vVecUnitId = (long)pVecUnitId;
			vVecUnitPrefId = (long)pVecUnitPrefId;

			Vector result = TestGo();

			Assert.Null(result, "Result should be null.");
		}

	}

}