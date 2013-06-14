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

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TAddMemberEnsure {

		private const string QueryGetMemberTx =
			"_V0=[];"+
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_TP)"+
			".outE('"+RelDbName.UserDefinesMember+"').inV"+
				".as('step3')"+
			".inE('"+RelDbName.AppDefinesMember+"').outV"+
			".has('"+PropDbName.Artifact_ArtifactId+"',Tokens.T.eq,_TP)"+
			".back('step3')"+
				".aggregate(_V0)"+
			".outE('"+RelDbName.MemberHasMemberTypeAssign+"').inV"+
				".aggregate(_V0)"+
				".iterate();"+
			"_V0;";

		private const string QueryAddMemberTx =
			"_V0=g.addVertex(["+
				PropDbName.Member_MemberId+":_TP,"+
				PropDbName.Node_FabType+":_TP"+
			"]);"+
			"_V1=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			"g.addEdge(_V1,_V0,_TP);"+
			"_V2=g.V('"+PropDbName.Artifact_ArtifactId+"',_TP).next();"+
			"g.addEdge(_V2,_V0,_TP);"+
			"_V3=g.addVertex(["+
				PropDbName.MemberTypeAssign_MemberTypeAssignId+":_TP,"+
				PropDbName.MemberTypeAssign_MemberTypeId+":_TP,"+
				PropDbName.NodeForAction_Performed+":_TP,"+
				PropDbName.NodeForAction_Note+":_TP,"+
				PropDbName.Node_FabType+":_TP"+
			"]);"+
			"g.addEdge(_V0,_V3,_TP);"+
			"_V4=g.V('"+PropDbName.Member_MemberId+"',_TP).next();"+
			"g.addEdge(_V4,_V3,_TP);";

		private const string QueryUpdateMemberTx =
			"_V0=g.V('"+PropDbName.MemberTypeAssign_MemberTypeAssignId+"',_TP).next();"+
			"_V0.inE('"+RelDbName.MemberHasMemberTypeAssign+"')"+
				".remove();"+
			"_V1=g.V('"+PropDbName.Member_MemberId+"',_TP).next();"+
			"g.addEdge(_V1,_V0,_TP);"+
			"_V2=g.addVertex(["+
				PropDbName.MemberTypeAssign_MemberTypeAssignId+":_TP,"+
				PropDbName.MemberTypeAssign_MemberTypeId+":_TP,"+
				PropDbName.NodeForAction_Performed+":_TP,"+
				PropDbName.NodeForAction_Note+":_TP,"+
				PropDbName.Node_FabType+":_TP"+
			"]);"+
			"g.addEdge(_V1,_V2,_TP);"+
			"_V3=g.V('"+PropDbName.Member_MemberId+"',_TP).next();"+
			"g.addEdge(_V3,_V2,_TP);";
		
		private long vAppId;
		private long vUserId;
		private Member vMemberResult;
		private MemberTypeAssign vMtaResult;
		private DateTime vUtcNow;
		private long vNewMtaId;
		private long vNewMemId;
		private Mock<IApiContext> vMockCtx;
		private Mock<IApiDataAccess> vMockGetMemberTxResult;
		private UsageMap vUsageMap;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vAppId = 345;
			vUserId = 9876;
			vUtcNow = DateTime.UtcNow;
			vNewMtaId = 82395829385;
			vNewMemId = 52923582934;
			vUsageMap = new UsageMap();

			vMemberResult = new Member { MemberId = 1253 };
			vMtaResult = new MemberTypeAssign { MemberTypeAssignId = 9253 };
			
			vMockGetMemberTxResult = new Mock<IApiDataAccess>();
			vMockGetMemberTxResult.Setup(x => x.GetResultAt<Member>(0)).Returns(vMemberResult);
			vMockGetMemberTxResult.Setup(x => x.GetResultAt<MemberTypeAssign>(1)).Returns(vMtaResult);
			vMockGetMemberTxResult.Setup(x => x.GetResultCount()).Returns(2);

			vMockCtx = new Mock<IApiContext>();
			vMockCtx.SetupGet(x => x.UtcNow).Returns(vUtcNow);
			vMockCtx.Setup(x => x.GetSharpflakeId<MemberTypeAssign>()).Returns(vNewMtaId);
			vMockCtx.Setup(x => x.GetSharpflakeId<Member>()).Returns(vNewMemId);
			
			vMockCtx
				.Setup(x => x.DbData(
					AddMemberEnsure.Query.GetMemberTx+"", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction tx) => GetMemberTx(tx));
				
			vMockCtx
				.Setup(x => x.DbData(
					AddMemberEnsure.Query.AddMemberTx+"", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction tx) => AddMemberTx(tx));
					
			vMockCtx
				.Setup(x => x.DbData(
					AddMemberEnsure.Query.UpdateMemberTx+"", It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction tx) => UpdateMemberTx(tx));
		}

		/*--------------------------------------------------------------------------------------------*/
		private bool TestGo(bool pViaTask=false) {
			if ( pViaTask ) {
				return new OauthTasks().AddMemberEnsure(vAppId, vUserId, vMockCtx.Object);
			}

			var task = new AddMemberEnsure(vAppId, vUserId);
			return task.Go(vMockCtx.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess GetMemberTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			vUsageMap.Increment(AddMemberEnsure.Query.GetMemberTx+"");

			string expect = TestUtil.InsertParamIndexes(QueryGetMemberTx, "_TP");
			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", vUserId);
			TestUtil.CheckParam(pTx.Params, "_TP1", vAppId);

			return vMockGetMemberTxResult.Object;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess AddMemberTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			vUsageMap.Increment(AddMemberEnsure.Query.AddMemberTx+"");

			string expect = TestUtil.InsertParamIndexes(QueryAddMemberTx, "_TP");
			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(pTx.Params, "_TP", new object[] {
				vNewMemId,
				(byte)NodeFabType.Member,
				vAppId,
				RelDbName.AppDefinesMember,
				vUserId,
				RelDbName.UserDefinesMember,
				vNewMtaId,
				(long)MemberTypeId.Member,
				vUtcNow.Ticks,
				"First login.",
				(byte)NodeFabType.MemberTypeAssign,
				RelDbName.MemberHasMemberTypeAssign,
				(long)MemberId.FabFabData,
				RelDbName.MemberCreatesMemberTypeAssign
			});
			
			return vMockGetMemberTxResult.Object;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess UpdateMemberTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			vUsageMap.Increment(AddMemberEnsure.Query.UpdateMemberTx+"");

			string expect = TestUtil.InsertParamIndexes(QueryUpdateMemberTx, "_TP");
			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(pTx.Params, "_TP", new object[] {
				vMtaResult.MemberTypeAssignId,
				vMemberResult.MemberId,
				RelDbName.MemberHasHistoricMemberTypeAssign,
				vNewMtaId,
				(long)MemberTypeId.Member,
				vUtcNow.Ticks,
				"First login.",
				(byte)NodeFabType.MemberTypeAssign,
				RelDbName.MemberHasMemberTypeAssign,
				(long)MemberId.FabFabData,
				RelDbName.MemberCreatesMemberTypeAssign
			});
			
			return vMockGetMemberTxResult.Object;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void MemberAlreadyExists(bool pViaTask) {
			vMtaResult.MemberTypeId = (byte)MemberTypeId.Member;
			
			bool result = TestGo(pViaTask);
			
			vUsageMap.AssertUses(AddMemberEnsure.Query.GetMemberTx+"", 1);
			vUsageMap.AssertUses(AddMemberEnsure.Query.AddMemberTx+"", 0);
			vUsageMap.AssertUses(AddMemberEnsure.Query.UpdateMemberTx+"", 0);
			Assert.False(result, "Incorrect result.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true, MemberTypeId.None)]
		[TestCase(true, MemberTypeId.Invite)]
		[TestCase(true, MemberTypeId.Request)]
		[TestCase(false, MemberTypeId.None)]
		public void UpdateMember(bool pViaTask, MemberTypeId pMemTypeId) {
			vMtaResult.MemberTypeId = (byte)pMemTypeId;
			bool result = TestGo(pViaTask);
			
			vUsageMap.AssertUses(AddMemberEnsure.Query.GetMemberTx+"", 1);
			vUsageMap.AssertUses(AddMemberEnsure.Query.AddMemberTx+"", 0);
			vUsageMap.AssertUses(AddMemberEnsure.Query.UpdateMemberTx+"", 1);
			Assert.True(result, "Incorrect result.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true, -1)]
		[TestCase(true, 0)]
		[TestCase(false, -1)]
		[TestCase(false, 0)]
		public void AddMember(bool pViaTask, int pCount) {
			vMockGetMemberTxResult.Setup(x => x.GetResultCount()).Returns(pCount);
			
			bool result = TestGo(pViaTask);
			
			vUsageMap.AssertUses(AddMemberEnsure.Query.GetMemberTx+"", 1);
			vUsageMap.AssertUses(AddMemberEnsure.Query.AddMemberTx+"", 1);
			vUsageMap.AssertUses(AddMemberEnsure.Query.UpdateMemberTx+"", 0);
			Assert.True(result, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrInvalidAppId() {
			vAppId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrInvalidUserId() {
			vUserId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

	}

}