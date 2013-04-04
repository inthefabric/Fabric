using System;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TAddMemberEnsure {

		private readonly static string QueryGetMemberTx =
			"_V0=[];"+
			"g.V('"+typeof(User).Name+"Id',_TP0)[0]"+
			".outE('"+typeof(UserDefinesMember).Name+"').inV"+
				".as('step3')"+
			".inE('"+typeof(AppDefinesMember).Name+"').outV"+
			".has('"+typeof(App).Name+"Id',Tokens.T.eq,_TP1)"+
			".back('step3')"+
				".aggregate(_V0)"+
			".outE('"+typeof(MemberHasMemberTypeAssign).Name+"').inV"+
				".aggregate(_V0)"+
			".outE('"+typeof(MemberTypeAssignUsesMemberType).Name+"').inV"+
				".aggregate(_V0)"+
				".iterate();"+
			"_V0;";
			
		private readonly static string QueryAddMemberTx =
			"_V0=g.V('RootId',_TP0)[0].next();"+
			"_V1=g.addVertex(["+typeof(Member).Name+"Id:_TP1]);"+
			"g.addEdge(_V0,_V1,_TP2);"+
			"_V2=g.V('"+typeof(App).Name+"Id',_TP3)[0].next();"+
			"g.addEdge(_V2,_V1,_TP4);"+
			"_V3=g.V('"+typeof(User).Name+"Id',_TP5)[0].next();"+
			"g.addEdge(_V3,_V1,_TP6);"+
			"_V4=g.addVertex(["+
				typeof(MemberTypeAssign).Name+"Id:_TP7,"+
				"Performed:_TP8,"+
				"Note:_TP9"+
			"]);"+
			"g.addEdge(_V0,_V4,_TP10);"+
			"g.addEdge(_V1,_V4,_TP11);"+
			"_V5=g.V('"+typeof(MemberType).Name+"Id',_TP12)[0].next();"+
			"g.addEdge(_V4,_V5,_TP13);"+
			"_V6=g.V('"+typeof(Member).Name+"Id',_TP14)[0].next();"+
			"g.addEdge(_V6,_V4,_TP15);";

		private readonly static string QueryUpdateMemberTx =
			"_V0=g.V('RootId',_TP0)[0].next();"+
			"_V1=g.V('"+typeof(MemberTypeAssign).Name+"Id',_TP1)[0].next();"+
			"_V1.inE('"+typeof(MemberHasMemberTypeAssign).Name+"')"+
				".remove();"+
			"_V2=g.V('"+typeof(Member).Name+"Id',_TP2)[0].next();"+
			"g.addEdge(_V2,_V1,_TP3);"+
			"_V3=g.addVertex(["+
				typeof(MemberTypeAssign).Name+"Id:_TP4,"+
				"Performed:_TP5,"+
				"Note:_TP6"+
			"]);"+
			"g.addEdge(_V0,_V3,_TP7);"+
			"g.addEdge(_V2,_V3,_TP8);"+
			"_V4=g.V('"+typeof(MemberType).Name+"Id',_TP9)[0].next();"+
			"g.addEdge(_V3,_V4,_TP10);"+
			"_V5=g.V('"+typeof(Member).Name+"Id',_TP11)[0].next();"+
			"g.addEdge(_V5,_V3,_TP12);";
		
		private long vAppId;
		private long vUserId;
		private Member vMemberResult;
		private MemberType vMemTypeResult;
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
			vMemTypeResult = new MemberType { MemberTypeId = (long)MemberTypeId.Invite };
			
			vMockGetMemberTxResult = new Mock<IApiDataAccess>();
			vMockGetMemberTxResult.Setup(x => x.GetResultAt<Member>(0)).Returns(vMemberResult);
			vMockGetMemberTxResult.Setup(x => x.GetResultAt<MemberTypeAssign>(1)).Returns(vMtaResult);
			vMockGetMemberTxResult.Setup(x => x.GetResultAt<MemberType>(2)).Returns(vMemTypeResult);
			vMockGetMemberTxResult.Setup(x => x.GetResultCount()).Returns(3);

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
			
			Assert.AreEqual(QueryGetMemberTx, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", vUserId);
			TestUtil.CheckParam(pTx.Params, "_TP1", vAppId);

			return vMockGetMemberTxResult.Object;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess AddMemberTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			vUsageMap.Increment(AddMemberEnsure.Query.AddMemberTx+"");
			
			Assert.AreEqual(QueryAddMemberTx, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", 0);
			TestUtil.CheckParam(pTx.Params, "_TP1", vNewMemId);
			TestUtil.CheckParam(pTx.Params, "_TP2", typeof(RootContainsMember).Name);
			TestUtil.CheckParam(pTx.Params, "_TP3", vAppId);
			TestUtil.CheckParam(pTx.Params, "_TP4", typeof(AppDefinesMember).Name);
			TestUtil.CheckParam(pTx.Params, "_TP5", vUserId);
			TestUtil.CheckParam(pTx.Params, "_TP6", typeof(UserDefinesMember).Name);
			TestUtil.CheckParam(pTx.Params, "_TP7", vNewMtaId);
			TestUtil.CheckParam(pTx.Params, "_TP8", vUtcNow.Ticks);
			TestUtil.CheckParam(pTx.Params, "_TP9", "First login.");
			TestUtil.CheckParam(pTx.Params, "_TP10", typeof(RootContainsMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP11", typeof(MemberHasMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP12", (long)MemberTypeId.Member);
			TestUtil.CheckParam(pTx.Params, "_TP13", typeof(MemberTypeAssignUsesMemberType).Name);
			TestUtil.CheckParam(pTx.Params, "_TP14", (long)MemberId.FabFabData);
			TestUtil.CheckParam(pTx.Params, "_TP15", typeof(MemberCreatesMemberTypeAssign).Name);
			
			return vMockGetMemberTxResult.Object;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess UpdateMemberTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			vUsageMap.Increment(AddMemberEnsure.Query.UpdateMemberTx+"");
			
			Assert.AreEqual(QueryUpdateMemberTx, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", 0);
			TestUtil.CheckParam(pTx.Params, "_TP1", vMtaResult.MemberTypeAssignId);
			TestUtil.CheckParam(pTx.Params, "_TP2", vMemberResult.MemberId);
			TestUtil.CheckParam(pTx.Params, "_TP3", typeof(MemberHasHistoricMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP4", vNewMtaId);
			TestUtil.CheckParam(pTx.Params, "_TP5", vUtcNow.Ticks);
			TestUtil.CheckParam(pTx.Params, "_TP6", "First login.");
			TestUtil.CheckParam(pTx.Params, "_TP7", typeof(RootContainsMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP8", typeof(MemberHasMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP9", (long)MemberTypeId.Member);
			TestUtil.CheckParam(pTx.Params, "_TP10", typeof(MemberTypeAssignUsesMemberType).Name);
			TestUtil.CheckParam(pTx.Params, "_TP11", (long)MemberId.FabFabData);
			TestUtil.CheckParam(pTx.Params, "_TP12", typeof(MemberCreatesMemberTypeAssign).Name);
			
			return vMockGetMemberTxResult.Object;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void MemberAlreadyExists(bool pViaTask) {
			vMemTypeResult.MemberTypeId = (long)MemberTypeId.Member;
			
			bool result = TestGo(pViaTask);
			
			vUsageMap.AssertUses(AddMemberEnsure.Query.GetMemberTx+"", 1);
			vUsageMap.AssertUses(AddMemberEnsure.Query.AddMemberTx+"", 0);
			vUsageMap.AssertUses(AddMemberEnsure.Query.UpdateMemberTx+"", 0);
			Assert.False(result, "Incorrect result.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void UpdateMember(bool pViaTask) {
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