using Fabric.Api.Modify;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Domain.Types;
using Fabric.Test.Integration.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XAttachVector : XCreateFactorElement {

		private long vVecTypeId;
		private long vValue;
		private long vAxisArtId;
		private long vVecUnitId;
		private long vVecUnitPrefId;
		
		private Vector vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;

			vVecTypeId = (long)VectorTypeId.FullLong;
			vValue = 42;
			vAxisArtId = (long)SetupArtifacts.ArtifactId.Thi_Aei;
			vVecUnitId = (long)VectorUnitId.Hertz;
			vVecUnitPrefId = (long)VectorUnitPrefixId.Milli;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected  override void TestGo() {
			var func = new AttachVector(Tasks, FactorId, vVecTypeId, vValue,
				vAxisArtId, vVecUnitId, vVecUnitPrefId);
			vResult = func.Go(ApiCtx);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewVector() {
			IsReadOnlyTest = false;

			TestGo();
			
			Assert.NotNull(vResult, "Result should not be null.");
			
			////
			
			Vector newVector = GetNode<Vector>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newVector, "New Vector was not created.");
			Assert.AreEqual(newVector.VectorId, vResult.VectorId,
				"Incorrect Result.VectorId.");

			NodeConnections conn = GetNodeConnections(newVector);
			conn.AssertRelCount(1, 4);
			conn.AssertRel<FactorUsesVector, Factor>(false, FactorId);
			conn.AssertRel<VectorUsesVectorType, VectorType>(true, vVecTypeId);
			conn.AssertRel<VectorUsesAxisArtifact, Artifact>(true,
				vAxisArtId, typeof(Artifact).Name+"Id");
			conn.AssertRel<VectorUsesVectorUnit, VectorUnit>(true, vVecUnitId);
			conn.AssertRel<VectorUsesVectorUnitPrefix, VectorUnitPrefix>(true, vVecUnitPrefId);
			
			NewNodeCount = 1;
			NewRelCount = 5;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void ExistingVector() {
			IsReadOnlyTest = false;
			
			vVecTypeId = (long)VectorTypeId.OppFavor;
			vValue = 92;
			vAxisArtId = (long)SetupArtifacts.ArtifactId.Thi_Quality;
			vVecUnitId = (long)VectorUnitId.None;
			vVecUnitPrefId = (long)VectorUnitPrefixId.Base;
			const long expectVectorId = (long)SetupFactors.VectorId.Quality_92_None;

			TestGo();

			Assert.NotNull(vResult, "Result should not be null.");

			////

			Vector newVector = GetNode<Vector>(expectVectorId);
			NodeConnections conn = GetNodeConnections(newVector);
			conn.AssertRel<FactorUsesVector, Factor>(false, FactorId);

			NewNodeCount = 0;
			NewRelCount = 1;
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(SetupTypes.NumVectorTypes+1)]
		public void ErrVectorTypeRange(int pId) {
			vVecTypeId = pId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrAxisArtifactValue() {
			vAxisArtId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(SetupTypes.NumVectorUnits+1)]
		public void ErrVectorUnitRange(int pId) {
			vVecUnitId = pId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(SetupTypes.NumVectorUnitPrefixes+1)]
		public void ErrVectorUnitPrefixRange(int pId) {
			vVecUnitPrefId = pId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

	}

}