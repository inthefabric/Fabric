using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TUpdateFactorDescriptor : TModifyTasks {

		private const string QueryStart = 
			"_F=g.V('"+PropDbName.Factor_FactorId+"',_TP)"+
				".sideEffect{"+
					"it.setProperty('"+PropDbName.Factor_Descriptor_TypeId+"',_TP);"+
				"}"+
				".next();";
		
		private const string QueryPrimRef = 
			"_V{{PrimV}}=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			"_PROP=[:];"+
			"_TRY=[F_Fa:_F,F_Df:_F,F_Cr:_F,F_DeT:_F,F_DiT:_F,F_DiP:_F,F_DiR:_F,F_EvT:_F,F_EvP:_F,"+
				"F_EvD:_F,F_IdT:_F,F_IdV:_F,F_LoT:_F,F_LoX:_F,F_LoY:_F,F_LoZ:_F,F_VeT:_F,F_VeU:_F,"+
				"F_VeP:_F,F_VeV:_F,A_Cr:_V{{PrimV}}];"+
			TestUtil.TryPropScript+
			"g.addEdge(_F,_V{{PrimV}},_TP,_PROP);";

		private const string QueryEdgeRef = 
			"_V{{EdgeV}}=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			"_PROP=[:];"+
			"_TRY=[F_Fa:_F,F_Df:_F,F_Cr:_F,F_DeT:_F,F_DiT:_F,F_DiP:_F,F_DiR:_F,F_EvT:_F,F_EvP:_F,"+
				"F_EvD:_F,F_IdT:_F,F_IdV:_F,F_LoT:_F,F_LoX:_F,F_LoY:_F,F_LoZ:_F,F_VeT:_F,F_VeU:_F,"+
				"F_VeP:_F,F_VeV:_F,A_Cr:_V{{EdgeV}}];"+
			TestUtil.TryPropScript+
			"g.addEdge(_F,_V{{EdgeV}},_TP,_PROP);";

		private const string QueryTypeRef = 
			"_V{{TypeV}}=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			"_PROP=[:];"+
			"_TRY=[F_Fa:_F,F_Df:_F,F_Cr:_F,F_DeT:_F,F_DiT:_F,F_DiP:_F,F_DiR:_F,F_EvT:_F,F_EvP:_F,"+
				"F_EvD:_F,F_IdT:_F,F_IdV:_F,F_LoT:_F,F_LoX:_F,F_LoY:_F,F_LoZ:_F,F_VeT:_F,F_VeU:_F,"+
				"F_VeP:_F,F_VeV:_F,A_Cr:_V{{TypeV}}];"+
			TestUtil.TryPropScript+
			"g.addEdge(_F,_V{{TypeV}},_TP,_PROP);";

		private Factor vFactor;
		private byte vDescTypeId;
		private long? vPrimArtRefId;
		private long? vEdgeArtRefId;
		private long? vDescTypeRefId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vFactor = new Factor { FactorId = 132414 };
			vDescTypeId = 9;
			vPrimArtRefId = 935823;
			vEdgeArtRefId = 25323;
			vDescTypeRefId = 5439225;

			var mda = MockDataAccess.Create(OnExecute);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			string expect = QueryStart;
			int v = 1;

			var paramList = new List<object>();
			paramList.Add(vFactor.FactorId);
			paramList.Add(vDescTypeId);

			if ( vPrimArtRefId != null ) {
				expect += QueryPrimRef.Replace("{{PrimV}}", v+"");
				paramList.Add(vPrimArtRefId);
				paramList.Add(EdgeDbName.FactorDescriptorRefinesPrimaryWithArtifact);
				v++;
			}

			if ( vEdgeArtRefId != null ) {
				expect += QueryEdgeRef.Replace("{{EdgeV}}", v+"");
				paramList.Add(vEdgeArtRefId);
				paramList.Add(EdgeDbName.FactorDescriptorRefinesRelatedWithArtifact);
				v++;
			}

			if ( vDescTypeRefId != null ) {
				expect += QueryTypeRef.Replace("{{TypeV}}", v+"");
				paramList.Add(vDescTypeRefId);
				paramList.Add(EdgeDbName.FactorDescriptorRefinesTypeWithArtifact);
			}
			
			expect = TestUtil.InsertParamIndexes(expect, "_TP");
			Assert.AreEqual(expect, cmd.Script, "Incorrect Script.");
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
		public void Update(long? pPrimArtRefId, long? pEdgeArtRefId, long? pDescTypeRefId) {
			vPrimArtRefId = pPrimArtRefId;
			vEdgeArtRefId = pEdgeArtRefId;
			vDescTypeRefId = pDescTypeRefId;

			Tasks.UpdateFactorDescriptor(MockApiCtx.Object, vFactor, vDescTypeId, 
				vPrimArtRefId, vEdgeArtRefId, vDescTypeRefId);
			AssertDataExecution(true);
		}

	}

}