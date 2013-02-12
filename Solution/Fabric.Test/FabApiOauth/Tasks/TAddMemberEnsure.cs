﻿using System;
using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
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
			"g.V('"+typeof(User).Name+"Id',{{UserId}}L)[0]"+
			".outE('"+typeof(UserDefinesMember).Name+"').inV"+
				".as('step3')"+
			".inE('"+typeof(AppDefinesMember).Name+"').outV"+
			".has('"+typeof(App).Name+"Id',Tokens.T.eq,{{AppId}}L)"+
			".back('step3')"+
				".aggregate(_V0)"+
			".outE('"+typeof(MemberHasMemberTypeAssign).Name+"').inV"+
				".aggregate(_V0)"+
			".outE('"+typeof(MemberTypeAssignUsesMemberType).Name+"').inV"+
				".aggregate(_V0)"+
				".iterate();"+
			"_V0;";
			
		private readonly static string QueryAddMemberTx =
			"g.V('RootId',0)[0]"+
				".each{_V0=g.v(it)};"+
			"_V1=g.addVertex(["+typeof(Member).Name+"Id:{{NewMemberId}}L]);"+
			"g.addEdge(_V0,_V1,_TP0);"+
			"g.V('"+typeof(App).Name+"Id',{{AppId}}L)[0]"+
				".each{_V2=g.v(it)};"+
			"g.addEdge(_V2,_V1,_TP1);"+
			"g.V('"+typeof(User).Name+"Id',{{UserId}}L)[0]"+
				".each{_V3=g.v(it)};"+
			"g.addEdge(_V3,_V1,_TP2);"+
			"_V4=g.addVertex(["+
				typeof(MemberTypeAssign).Name+"Id:{{NewMtaId}}L,"+
				"Performed:{{UtcNowTicks}}L,"+
				"Note:_TP3"+
			"]);"+
			"g.addEdge(_V0,_V4,_TP4);"+
			"g.addEdge(_V1,_V4,_TP5);"+
			"g.V('"+typeof(MemberType).Name+"Id',{{NewMemTypeId}}L)[0]"+
				".each{_V5=g.v(it)};"+
			"g.addEdge(_V4,_V5,_TP6);"+
			"g.V('"+typeof(Member).Name+"Id',{{CreatorMemId}}L)[0]"+
				".each{_V6=g.v(it)};"+
			"g.addEdge(_V6,_V4,_TP7);";

		private readonly static string QueryUpdateMemberTx =
			"g.V('RootId',0)[0]"+
				".each{_V0=g.v(it)};"+
			"g.V('"+typeof(MemberTypeAssign).Name+"Id',{{MtaId}}L)[0]"+
			".inE('"+typeof(MemberHasMemberTypeAssign).Name+"')"+
				".sideEffect{g.removeEdge(it)}"+
				".iterate();"+
			"g.V('"+typeof(Member).Name+"Id',{{MemId}}L)[0]"+
				".each{_V1=g.v(it)};"+
			"g.V('"+typeof(MemberTypeAssign).Name+"Id',{{MtaId}}L)[0]"+
				".each{_V2=g.v(it)};"+
			"g.addEdge(_V1,_V2,_TP0);"+
			"_V3=g.addVertex(["+
				typeof(MemberTypeAssign).Name+"Id:{{NewMtaId}}L,"+
				"Performed:{{UtcNowTicks}}L,"+
				"Note:_TP1"+
			"]);"+
			"g.addEdge(_V0,_V3,_TP2);"+
			"g.addEdge(_V1,_V3,_TP3);"+
			"g.V('"+typeof(MemberType).Name+"Id',{{NewMemTypeId}}L)[0]"+
				".each{_V4=g.v(it)};"+
			"g.addEdge(_V3,_V4,_TP4);"+
			"g.V('"+typeof(Member).Name+"Id',{{CreatorMemId}}L)[0]"+
				".each{_V5=g.v(it)};"+
			"g.addEdge(_V5,_V3,_TP5);";
		
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
			
			string expect = QueryGetMemberTx
				.Replace("{{AppId}}", vAppId+"")
				.Replace("{{UserId}}", vUserId+"");

			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");

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
				.Replace("{{NewMemTypeId}}", ((long)MemberTypeId.Member)+"")
				.Replace("{{CreatorMemId}}", ((long)MemberId.FabFabData)+"");
			
			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", typeof(RootContainsMember).Name);
			TestUtil.CheckParam(pTx.Params, "_TP1", typeof(AppDefinesMember).Name);
			TestUtil.CheckParam(pTx.Params, "_TP2", typeof(UserDefinesMember).Name);
			TestUtil.CheckParam(pTx.Params, "_TP3", "First login.");
			TestUtil.CheckParam(pTx.Params, "_TP4", typeof(RootContainsMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP5", typeof(MemberHasMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP6", typeof(MemberTypeAssignUsesMemberType).Name);
			TestUtil.CheckParam(pTx.Params, "_TP7", typeof(MemberCreatesMemberTypeAssign).Name);
			
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
				.Replace("{{NewMemTypeId}}", ((long)MemberTypeId.Member)+"")
				.Replace("{{CreatorMemId}}", ((long)MemberId.FabFabData)+"");
			
			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", typeof(MemberHasHistoricMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP1", "First login.");
			TestUtil.CheckParam(pTx.Params, "_TP2", typeof(RootContainsMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP3", typeof(MemberHasMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP4", typeof(MemberTypeAssignUsesMemberType).Name);
			TestUtil.CheckParam(pTx.Params, "_TP5", typeof(MemberCreatesMemberTypeAssign).Name);
			
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