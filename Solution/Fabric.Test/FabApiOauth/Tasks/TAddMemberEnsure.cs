using System.Collections.Generic;
using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;
using System;
using Fabric.Db.Data;

namespace Fabric.Test.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TAddMemberEnsure {

		private readonly static string QueryGetMemberTx =
			"g.startTransaction();"+
				"_V0=[];"+
				"g.idx(_TP0).get('"+typeof(User).Name+"Id',{{UserId}}L)[0]"+
				".outE('"+typeof(UserDefinesMember).Name+"').inV"+
					".as('step3')"+
				".inE('"+typeof(AppDefinesMember).Name+"')[0].outV[0]"+
				".has('"+typeof(App).Name+"Id',Tokens.T.eq,{{AppId}}L)"+
				".back('step3')"+
					".aggregate(_V0)"+
				".outE('"+typeof(MemberHasMemberTypeAssign).Name+"')[0].inV[0]"+
					".aggregate(_V0)"+
				".outE('"+typeof(MemberTypeAssignUsesMemberType).Name+"')[0].inV[0]"+
					".aggregate(_V0);"+
			"g.stopTransaction(TransactionalGraph.Conclusion.SUCCESS);"+
			"_V0;";
			
		private readonly static string QueryAddMemberTx =
			"g.startTransaction();"+
				"_V0=g.v(0);"+
				"_V1=g.addVertex(["+typeof(Member).Name+"Id:{{NewMemberId}}L]);"+
				"g.idx(_TP0).put(_TP1,_V1."+typeof(Member).Name+"Id,_V1);"+
				"g.addEdge(_V0,_V1,_TP2);"+
				"_V2=g.idx(_TP3).get('"+typeof(App).Name+"Id',{{AppId}}L)[0];"+
				"g.addEdge(_V2,_V1,_TP4);"+
				"_V3=g.idx(_TP5).get('"+typeof(User).Name+"Id',{{UserId}}L)[0];"+
				"g.addEdge(_V3,_V1,_TP6);"+
				"_V4=g.addVertex(["+
					typeof(MemberTypeAssign).Name+"Id:{{NewMtaId}}L,"+
					"Performed:{{UtcNowTicks}}L,"+
					"Note:_TP7"+
				"]);"+
				"g.idx(_TP8).put(_TP9,_V4."+typeof(MemberTypeAssign).Name+"Id,_V4);"+
				"g.addEdge(_V0,_V4,_TP10);"+
				"g.addEdge(_V1,_V4,_TP11);"+
				"_V5=g.idx(_TP12).get('"+typeof(MemberType).Name+"Id',{{NewMemTypeId}}L)[0];"+
				"g.addEdge(_V4,_V5,_TP13);"+
				"_V6=g.idx(_TP14).get('"+typeof(Member).Name+"Id',{{CreatorMemId}}L)[0];"+
				"g.addEdge(_V6,_V4,_TP15);"+
			"g.stopTransaction(TransactionalGraph.Conclusion.SUCCESS);";

		private readonly static string QueryUpdateMemberTx =
			"g.startTransaction();"+
				"_V0=g.v(0);"+
				"g.idx(_TP0).get('"+typeof(MemberTypeAssign).Name+"Id',{{MtaId}}L)[0]"+
				".inE('"+typeof(MemberHasMemberTypeAssign).Name+"')[0]"+
					".each{g.removeEdge(it)};"+
				"_V1=g.idx(_TP1).get('"+typeof(Member).Name+"Id',{{MemId}}L)[0];"+
				"_V2=g.idx(_TP2).get('"+typeof(MemberTypeAssign).Name+"Id',{{MtaId}}L)[0];"+
				"g.addEdge(_V1,_V2,_TP3);"+
				"_V3=g.addVertex(["+
					typeof(MemberTypeAssign).Name+"Id:{{NewMtaId}}L,"+
					"Performed:{{UtcNowTicks}}L,"+
					"Note:_TP4"+
				"]);"+
				"g.idx(_TP5).put(_TP6,_V3."+typeof(MemberTypeAssign).Name+"Id,_V3);"+
				"g.addEdge(_V0,_V3,_TP7);"+
				"g.addEdge(_V1,_V3,_TP8);"+
				"_V4=g.idx(_TP9).get('"+typeof(MemberType).Name+"Id',{{NewMemTypeId}}L)[0];"+
				"g.addEdge(_V3,_V4,_TP10);"+
				"_V5=g.idx(_TP11).get('"+typeof(Member).Name+"Id',{{CreatorMemId}}L)[0];"+
				"g.addEdge(_V5,_V3,_TP12);"+
				"g.stopTransaction(TransactionalGraph.Conclusion.SUCCESS);";
		
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
			
			vMemberResult = new Member() { MemberId = 1253 };
			vMemTypeResult = new MemberType() { MemberTypeId = (byte)MemberTypeId.Invite };
			vMtaResult = new MemberTypeAssign() { MemberTypeAssignId = 9253 };
			
			var mockMemberDbDto = new Mock<IDbDto>();
			mockMemberDbDto.Setup(x => x.ToNode<Member>()).Returns(vMemberResult);
			
			var mockMtaDbDto = new Mock<IDbDto>();
			mockMtaDbDto.Setup(x => x.ToNode<MemberTypeAssign>()).Returns(vMtaResult);
			
			var mockMemTypeDbDto = new Mock<IDbDto>();
			mockMemTypeDbDto.Setup(x => x.ToNode<MemberType>()).Returns(vMemTypeResult);
			
			var list = new List<IDbDto>();
			list.Add(mockMemberDbDto.Object);
			list.Add(mockMtaDbDto.Object);
			list.Add(mockMemTypeDbDto.Object);
			
			vMockGetMemberTxResult = new Mock<IApiDataAccess>();
			vMockGetMemberTxResult.SetupGet(x => x.ResultDtoList).Returns(list);

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
			
			string expect = QueryGetMemberTx
				.Replace("{{AppId}}", vAppId+"")
				.Replace("{{UserId}}", vUserId+"");

			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", typeof(User).Name);

			return vMockGetMemberTxResult.Object;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess AddMemberTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			vUsageMap.Increment(AddMemberEnsure.Query.AddMemberTx+"");
			
			string expect = QueryAddMemberTx
				.Replace("{{NewMemberId}}", vNewMemId+"")
				.Replace("{{AppId}}", vAppId+"")
				.Replace("{{UserId}}", vUserId+"")
				.Replace("{{MtaId}}", vMtaResult.MemberTypeAssignId+"")
				.Replace("{{NewMtaId}}", vNewMtaId+"")
				.Replace("{{UtcNowTicks}}", vUtcNow.Ticks+"")
				.Replace("{{NewMemTypeId}}", ((byte)MemberTypeId.Member)+"")
				.Replace("{{CreatorMemId}}", ((long)MemberId.FabFabData)+"");
			
			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", typeof(Member).Name);
			TestUtil.CheckParam(pTx.Params, "_TP1", typeof(Member).Name+"Id");
			TestUtil.CheckParam(pTx.Params, "_TP2", typeof(RootContainsMember).Name);
			TestUtil.CheckParam(pTx.Params, "_TP3", typeof(App).Name);
			TestUtil.CheckParam(pTx.Params, "_TP4", typeof(AppDefinesMember).Name);
			TestUtil.CheckParam(pTx.Params, "_TP5", typeof(User).Name);
			TestUtil.CheckParam(pTx.Params, "_TP6", typeof(UserDefinesMember).Name);
			TestUtil.CheckParam(pTx.Params, "_TP7", "First login.");
			TestUtil.CheckParam(pTx.Params, "_TP8", typeof(MemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP9", typeof(MemberTypeAssign).Name+"Id");
			TestUtil.CheckParam(pTx.Params, "_TP10", typeof(RootContainsMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP11", typeof(MemberHasMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP12", typeof(MemberType).Name);
			TestUtil.CheckParam(pTx.Params, "_TP13", typeof(MemberTypeAssignUsesMemberType).Name);
			TestUtil.CheckParam(pTx.Params, "_TP14", typeof(Member).Name);
			TestUtil.CheckParam(pTx.Params, "_TP15", typeof(MemberCreatesMemberTypeAssign).Name);
			
			return vMockGetMemberTxResult.Object;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private IApiDataAccess UpdateMemberTx(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			vUsageMap.Increment(AddMemberEnsure.Query.UpdateMemberTx+"");
			
			string expect = QueryUpdateMemberTx
				.Replace("{{MemId}}", vMemberResult.MemberId+"")
				.Replace("{{MtaId}}", vMtaResult.MemberTypeAssignId+"")
				.Replace("{{NewMtaId}}", vNewMtaId+"")
				.Replace("{{UtcNowTicks}}", vUtcNow.Ticks+"")
				.Replace("{{NewMemTypeId}}", ((byte)MemberTypeId.Member)+"")
				.Replace("{{CreatorMemId}}", ((long)MemberId.FabFabData)+"");
			
			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", typeof(MemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP1", typeof(Member).Name);
			TestUtil.CheckParam(pTx.Params, "_TP2", typeof(MemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP3", typeof(MemberHasHistoricMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP4", "First login.");
			TestUtil.CheckParam(pTx.Params, "_TP5", typeof(MemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP6", typeof(MemberTypeAssign).Name+"Id");
			TestUtil.CheckParam(pTx.Params, "_TP7", typeof(RootContainsMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP8", typeof(MemberHasMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP9", typeof(MemberType).Name);
			TestUtil.CheckParam(pTx.Params, "_TP10", typeof(MemberTypeAssignUsesMemberType).Name);
			TestUtil.CheckParam(pTx.Params, "_TP11", typeof(Member).Name);
			TestUtil.CheckParam(pTx.Params, "_TP12", typeof(MemberCreatesMemberTypeAssign).Name);
			
			return vMockGetMemberTxResult.Object;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void MemberAlreadyExists(bool pViaTask) {
			vMemTypeResult.MemberTypeId = (byte)MemberTypeId.Member;
			
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
		[TestCase(true)]
		[TestCase(false)]
		public void AddMember(bool pViaTask) {
			vMockGetMemberTxResult.SetupGet(x => x.ResultDtoList).Returns((IList<IDbDto>)null);
			
			bool result = TestGo(pViaTask);
			
			vUsageMap.AssertUses(AddMemberEnsure.Query.GetMemberTx+"", 1);
			vUsageMap.AssertUses(AddMemberEnsure.Query.AddMemberTx+"", 1);
			vUsageMap.AssertUses(AddMemberEnsure.Query.UpdateMemberTx+"", 0);
			Assert.True(result, "Incorrect result.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(-1)]
		public void ErrInvalidAppId(long pAppId) {
			vAppId = pAppId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(-1)]
		public void ErrInvalidUserId(long pUserId) {
			vUserId = pUserId;
			TestUtil.CheckThrows<FabArgumentOutOfRangeFault>(true, () => TestGo());
			vUsageMap.AssertNoOverallUses();
		}

	}

}