using System;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TAddMemberTypeAssign : TWebTasks {

		private static readonly string Query =
			"_V0=g.V('"+PropDbName.Member_MemberId+"',_TP).next();"+
			"_MTA=_V0.outE('"+EdgeDbName.MemberHasMemberTypeAssign+"').inV.next();"+
			"_MTA.inE('"+EdgeDbName.MemberHasMemberTypeAssign+"')"+
				".remove();"+
			"g.addEdge(_V0,_MTA,_TP);"+
			"_V2=g.addVertex(["+
				PropDbName.MemberTypeAssign_MemberTypeAssignId+":_TP,"+
				PropDbName.MemberTypeAssign_MemberTypeId+":_TP,"+
				PropDbName.VertexForAction_Performed+":_TP,"+
				PropDbName.Vertex_FabType+":_TP"+
			"]);"+
			"_V3=g.V('"+PropDbName.Member_MemberId+"',_TP).next();"+
			"g.addEdge(_V3,_V2,_TP);"+
			"g.addEdge(_V0,_V2,_TP);"+
			"_V2;";

		private long vAssigningMemberId;
		private long vMemberId;
		private byte vMemberTypeId;

		private long vNewMtaId;
		private MemberTypeAssign vMtaResult;
		private DateTime vUtcNow;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAssigningMemberId = 436123;
			vMemberId = 53275;
			vMemberTypeId = 3;

			vNewMtaId = 874265982347;
			vUtcNow = DateTime.UtcNow;
			vMtaResult = new MemberTypeAssign();

			MockApiCtx.Setup(x => x.GetSharpflakeId<MemberTypeAssign>()).Returns(vNewMtaId);
			MockApiCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
			
			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vMtaResult);
			MockDataList.Add(mda);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);

			string expect = TestUtil.InsertParamIndexes(Query, "_TP");
			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(cmd.Params, "_TP", new object[] {
				vMemberId,
				EdgeDbName.MemberHasHistoricMemberTypeAssign,
				vNewMtaId,
				vMemberTypeId,
				vUtcNow.Ticks,
				(byte)VertexFabType.MemberTypeAssign,
				vAssigningMemberId,
				EdgeDbName.MemberCreatesMemberTypeAssign,
				EdgeDbName.MemberHasMemberTypeAssign
			});
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			MemberTypeAssign result = Tasks.AddMemberTypeAssign(MockApiCtx.Object,
				vAssigningMemberId, vMemberId, vMemberTypeId);
				
			AssertDataExecution(true);
			Assert.AreEqual(vMtaResult, result, "Incorrect Result.");
		}

	}

}