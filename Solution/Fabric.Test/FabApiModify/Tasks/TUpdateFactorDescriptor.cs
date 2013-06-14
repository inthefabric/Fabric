using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TUpdateFactorDescriptor : TModifyTasks {

		private const string QueryStart = 
			"_V0=g.V('"+PropDbName.Factor_FactorId+"',_TP)"+
				".sideEffect{"+
					"it.setProperty('"+PropDbName.Factor_Descriptor_TypeId+"',_TP)"+
				"}"+
				".next();";

		private const string QueryPrimRef = 
			"_V{{PrimV}}=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			"g.addEdge(_V0,_V{{PrimV}},_TP);";

		private const string QueryRelRef = 
			"_V{{RelV}}=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			"g.addEdge(_V0,_V{{RelV}},_TP);";

		private const string QueryTypeRef = 
			"_V{{TypeV}}=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			"g.addEdge(_V0,_V{{TypeV}},_TP);";

		private Factor vFactor;
		private byte vDescTypeId;
		private long? vPrimArtRefId;
		private long? vRelArtRefId;
		private long? vDescTypeRefId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vFactor = new Factor { FactorId = 132414 };
			vDescTypeId = 9;
			vPrimArtRefId = 935823;
			vRelArtRefId = 25323;
			vDescTypeRefId = 5439225;

			MockApiCtx
				.Setup(x => x.DbData("UpdateFactorDescriptor", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction tx) => UpdateFactorDescriptor(tx));
		}

		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess UpdateFactorDescriptor(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			UsageMap.Increment("UpdateFactorDescriptor");

			string expect = QueryStart;
			int v = 1;

			var paramList = new List<object>();
			paramList.Add(vFactor.FactorId);
			paramList.Add(vDescTypeId);

			if ( vPrimArtRefId != null ) {
				expect += QueryPrimRef.Replace("{{PrimV}}", v+"");
				paramList.Add(vPrimArtRefId);
				paramList.Add(RelDbName.FactorDescriptorRefinesPrimaryWithArtifact);
				v++;
			}

			if ( vRelArtRefId != null ) {
				expect += QueryRelRef.Replace("{{RelV}}", v+"");
				paramList.Add(vRelArtRefId);
				paramList.Add(RelDbName.FactorDescriptorRefinesRelatedWithArtifact);
				v++;
			}

			if ( vDescTypeRefId != null ) {
				expect += QueryTypeRef.Replace("{{TypeV}}", v+"");
				paramList.Add(vDescTypeRefId);
				paramList.Add(RelDbName.FactorDescriptorRefinesTypeWithArtifact);
			}
			
			expect = TestUtil.InsertParamIndexes(expect, "_TP");
			Assert.AreEqual(expect, pTx.Script, "Incorrect Script.");

			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(123L, 456L, 789L)]
		[TestCase(null, 456L, 789L)]
		[TestCase(123L, null, 789L)]
		[TestCase(123L, 456L, null)]
		[TestCase(null, null, 789L)]
		[TestCase(123L, null, null)]
		[TestCase(null, 456L, null)]
		[TestCase(null, null, null)]
		public void Update(long? pPrimArtRefId, long? pRelArtRefId, long? pDescTypeRefId) {
			vPrimArtRefId = pPrimArtRefId;
			vRelArtRefId = pRelArtRefId;
			vDescTypeRefId = pDescTypeRefId;

			Tasks.UpdateFactorDescriptor(MockApiCtx.Object, vFactor, vDescTypeId, 
				vPrimArtRefId, vRelArtRefId, vDescTypeRefId);
		}

	}

}