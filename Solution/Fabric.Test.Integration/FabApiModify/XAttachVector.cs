﻿using Fabric.Api.Modify;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Domain.Types;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Integration.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XAttachVector : XAttachFactorElement {

		private byte vVecTypeId;
		private long vValue;
		private long vAxisArtId;
		private byte vVecUnitId;
		private byte vVecUnitPrefId;
		
		private bool vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;

			vVecTypeId = (byte)VectorTypeId.FullLong;
			vValue = 42;
			vAxisArtId = (long)SetupArtifacts.ArtifactId.Thi_Aei;
			vVecUnitId = (byte)VectorUnitId.Hertz;
			vVecUnitPrefId = (byte)VectorUnitPrefixId.Milli;
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

			Assert.True(vResult, "Incorrect Result.");

			Factor updatedFactor = GetVertex<Factor>(FactorId);
			Assert.NotNull(updatedFactor, "Updated Factor was deleted.");
			Assert.AreEqual(vVecTypeId, updatedFactor.Vector_TypeId, "Incorrect Vector_TypeId.");

			////
			
			VertexConnections conn = GetVertexConnections(updatedFactor);
			conn.AssertEdgeCount(1, 2+1); //Factor starts with (1,2) (in,out) edges
			conn.AssertEdge<FactorVectorUsesAxisArtifact, Artifact>(true,
				vAxisArtId, PropDbName.Artifact_ArtifactId);
			
			NewEdgeCount = 1;
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(1)]
		public void ErrVectorTypeRange(byte pId) {
			vVecTypeId = pId;

			if ( pId == 1 ) {
				vVecTypeId = (byte)(StaticTypes.VectorTypes.Keys.Count+1);
			}

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
		[TestCase(1)]
		public void ErrVectorUnitRange(byte pId) {
			vVecUnitId = pId;

			if ( pId == 1 ) {
				vVecUnitId = (byte)(StaticTypes.VectorUnits.Keys.Count+1);
			}

			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(1)]
		public void ErrVectorUnitPrefixRange(byte pId) {
			vVecUnitPrefId = pId;

			if ( pId == 1 ) {
				vVecUnitPrefId = (byte)(StaticTypes.VectorUnitPrefixs.Keys.Count+1);
			}

			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, TestGo);
		}

	}

}