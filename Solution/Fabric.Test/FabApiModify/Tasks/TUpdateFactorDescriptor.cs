using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TUpdateFactorDescriptor : TModifyTasks {

		private static readonly string QueryStart = 
			"_V0=g.V('"+typeof(Factor).Name+"Id',_TP)"+
				".sideEffect{"+
					"it.setProperty('Descriptor_TypeId',_TP)"+
				"}"+
				".next();";

		private static readonly string QueryPrimRef = 
			"_V{{PrimV}}=g.V('"+typeof(Artifact).Name+"Id',_TP).next();"+
			"g.addEdge(_V0,_V{{PrimV}},_TP);";

		private static readonly string QueryRelRef = 
			"_V{{RelV}}=g.V('"+typeof(Artifact).Name+"Id',_TP).next();"+
			"g.addEdge(_V0,_V{{RelV}},_TP);";

		private static readonly string QueryTypeRef = 
			"_V{{TypeV}}=g.V('"+typeof(Artifact).Name+"Id',_TP).next();"+
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
				paramList.Add(typeof(FactorDescriptorRefinesPrimaryWithArtifact).Name);
				v++;
			}

			if ( vRelArtRefId != null ) {
				expect += QueryRelRef.Replace("{{RelV}}", v+"");
				paramList.Add(vRelArtRefId);
				paramList.Add(typeof(FactorDescriptorRefinesRelatedWithArtifact).Name);
				v++;
			}

			if ( vDescTypeRefId != null ) {
				expect += QueryTypeRef.Replace("{{TypeV}}", v+"");
				paramList.Add(vDescTypeRefId);
				paramList.Add(typeof(FactorDescriptorRefinesTypeWithArtifact).Name);
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