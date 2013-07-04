using System;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;
using Fabric.Test.Common;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TAddMemberEnsure : TTestBase {

		private const string QueryGetMemberTx =
			"_V0=[];"+
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_TP)"+
			".outE('"+EdgeDbName.UserDefinesMember+"').inV"+
				".as('step5')"+
			".inE('"+EdgeDbName.AppDefinesMember+"').outV"+
			".has('"+PropDbName.Artifact_ArtifactId+"',Tokens.T.eq,_TP)"+
			".back('step5')"+
				".aggregate(_V0)"+
			".outE('"+EdgeDbName.MemberHasMemberTypeAssign+"').inV"+
				".aggregate(_V0)"+
				".iterate();"+
			"_V0;";

		private const string QueryAddMemberTx =
			"_V0=g.addVertex(["+
				PropDbName.Member_MemberId+":_TP,"+
				PropDbName.Vertex_FabType+":_TP"+
			"]);"+
			"_V1=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			"_PROP=[:];"+
			"g.addEdge(_V1,_V0,_TP,_PROP);"+
			"_V2=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			"_PROP=[:];"+
			"g.addEdge(_V2,_V0,_TP,_PROP);"+
			"_V3=g.addVertex(["+
				PropDbName.MemberTypeAssign_MemberTypeAssignId+":_TP,"+
				PropDbName.MemberTypeAssign_MemberTypeId+":_TP,"+
				PropDbName.VertexForAction_Performed+":_TP,"+
				PropDbName.VertexForAction_Note+":_TP,"+
				PropDbName.Vertex_FabType+":_TP"+
			"]);"+
			"_PROP=[:];"+
			"g.addEdge(_V0,_V3,_TP,_PROP);"+
			"_V4=g.V('"+PropDbName.Member_MemberId+"',_TP).next();"+
			"_PROP=[:];"+
			"g.addEdge(_V4,_V3,_TP,_PROP);";

		private const string QueryUpdateMemberTx =
			"_V0=g.V('"+PropDbName.MemberTypeAssign_MemberTypeAssignId+"',_TP).next();"+
			"_V0.inE('"+EdgeDbName.MemberHasMemberTypeAssign+"')"+
				".remove();"+
			"_V1=g.V('"+PropDbName.Member_MemberId+"',_TP).next();"+
			"_PROP=[:];"+
			"g.addEdge(_V1,_V0,_TP,_PROP);"+
			"_V2=g.addVertex(["+
				PropDbName.MemberTypeAssign_MemberTypeAssignId+":_TP,"+
				PropDbName.MemberTypeAssign_MemberTypeId+":_TP,"+
				PropDbName.VertexForAction_Performed+":_TP,"+
				PropDbName.VertexForAction_Note+":_TP,"+
				PropDbName.Vertex_FabType+":_TP"+
			"]);"+
			"_PROP=[:];"+
			"g.addEdge(_V1,_V2,_TP,_PROP);"+
			"_V3=g.V('"+PropDbName.Member_MemberId+"',_TP).next();"+
			"_PROP=[:];"+
			"g.addEdge(_V3,_V2,_TP,_PROP);";
		
		private long vAppId;
		private long vUserId;
		private Member vMemberResult;
		private MemberTypeAssign vMtaResult;
		private DateTime vUtcNow;
		private long vNewMtaId;
		private long vNewMemId;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = 345;
			vUserId = 9876;
			vUtcNow = DateTime.UtcNow;
			vNewMtaId = 82395829385;
			vNewMemId = 52923582934;

			vMemberResult = new Member { MemberId = 1253 };
			vMtaResult = new MemberTypeAssign { MemberTypeAssignId = 9253 };
			
			MockApiCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
			MockApiCtx.Setup(x => x.GetSharpflakeId<MemberTypeAssign>()).Returns(vNewMtaId);
			MockApiCtx.Setup(x => x.GetSharpflakeId<Member>()).Returns(vNewMemId);
			
			var mda = MockDataAccess.Create(OnExecuteGet);
			mda.MockResult.Setup(x => x.ToElementAt<Member>(0, 0)).Returns(vMemberResult);
			mda.MockResult.Setup(x => x.ToElementAt<MemberTypeAssign>(0, 1)).Returns(vMtaResult);
			mda.MockResult.Setup(x => x.GetCommandResultCount(0)).Returns(2);
			MockDataList.Add(mda);
			
			mda = MockDataAccess.Create(OnExecuteAdd);
			MockDataList.Add(mda);
			
			mda = MockDataAccess.Create(OnExecuteUpdate);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private bool TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().AddMemberEnsure(vAppId, vUserId, MockApiCtx.Object);
			}

			var task = new AddMemberEnsure(vAppId, vUserId);
			return task.Go(MockApiCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecuteGet(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);

			string expect = TestUtil.InsertParamIndexes(QueryGetMemberTx, "_TP");
			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_TP0", vUserId);
			TestUtil.CheckParam(cmd.Params, "_TP1", vAppId);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecuteAdd(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			
			string expect = TestUtil.InsertParamIndexes(QueryAddMemberTx, "_TP");
			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(cmd.Params, "_TP", new object[] {
				vNewMemId,
				(byte)VertexFabType.Member,
				vAppId,
				EdgeDbName.AppDefinesMember,
				vUserId,
				EdgeDbName.UserDefinesMember,
				vNewMtaId,
				(long)MemberTypeId.Member,
				vUtcNow.Ticks,
				"First login.",
				(byte)VertexFabType.MemberTypeAssign,
				EdgeDbName.MemberHasMemberTypeAssign,
				(long)MemberId.FabFabData,
				EdgeDbName.MemberCreatesMemberTypeAssign
			});
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void OnExecuteUpdate(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			
			string expect = TestUtil.InsertParamIndexes(QueryUpdateMemberTx, "_TP");
			Assert.AreEqual(expect, cmd.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(cmd.Params, "_TP", new object[] {
				vMtaResult.MemberTypeAssignId,
				vMemberResult.MemberId,
				EdgeDbName.MemberHasHistoricMemberTypeAssign,
				vNewMtaId,
				(long)MemberTypeId.Member,
				vUtcNow.Ticks,
				"First login.",
				(byte)VertexFabType.MemberTypeAssign,
				EdgeDbName.MemberHasMemberTypeAssign,
				(long)MemberId.FabFabData,
				EdgeDbName.MemberCreatesMemberTypeAssign
			});
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void MemberAlreadyExists(bool pViaTask) {
			vMtaResult.MemberTypeId = (byte)MemberTypeId.Member;
			
			bool result = TestGo(pViaTask);
			
			AssertDataExecution(new [] { 1, 0, 0 });
			Assert.False(result, "Incorrect result.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true, MemberTypeId.None)]
		[TestCase(true, MemberTypeId.Invite)]
		[TestCase(true, MemberTypeId.Request)]
		[TestCase(false, MemberTypeId.None)]
		public void UpdateMember(bool pViaTask, MemberTypeId pMemTypeId) {
			MockDataList.RemoveAt(1); //remove the "Add" query
			
			vMtaResult.MemberTypeId = (byte)pMemTypeId;
			bool result = TestGo(pViaTask);
			
			AssertDataExecution(true);
			Assert.True(result, "Incorrect result.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true, -1)]
		[TestCase(true, 0)]
		[TestCase(false, -1)]
		[TestCase(false, 0)]
		public void AddMember(bool pViaTask, int pCount) {
			MockDataList[0].MockResult.Setup(x => x.GetCommandResultCount(0)).Returns(pCount);
			
			bool result = TestGo(pViaTask);
			
			AssertDataExecution(new [] { 1, 1, 0 });
			Assert.True(result, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrInvalidAppId() {
			vAppId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			AssertDataExecution(false);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrInvalidUserId() {
			vUserId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			AssertDataExecution(false);
		}

	}

}