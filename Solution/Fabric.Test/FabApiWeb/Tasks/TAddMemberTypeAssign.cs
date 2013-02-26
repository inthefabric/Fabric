using System;
using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TAddMemberTypeAssign : TWebTasks {

		private static readonly string Query =

			"g.V('"+typeof(Member).Name+"Id',{{MemberId}}L)[0]"+
				".each{_V0=g.v(it)}"+
			".outE('"+typeof(MemberHasMemberTypeAssign).Name+"').inV"+
				".each{_V1=g.v(it)}"+
			".inE('"+typeof(MemberHasMemberTypeAssign).Name+"')"+
				".sideEffect{g.removeEdge(it)};"+

			"g.addEdge(_V0,_V1,_TP0);"+

			"g.V('"+typeof(Root).Name+"Id',0)[0]"+
				".each{_V2=g.v(it)};"+

			"_V3=g.addVertex(["+
				typeof(MemberTypeAssign).Name+"Id:{{MemberTypeAssignId}}L,"+
				"Performed:{{UtcNowTicks}}L"+
			"]);"+

			"g.addEdge(_V2,_V3,_TP1);"+
			"g.V('"+typeof(Member).Name+"Id',{{AssigningMemberId}}L)[0]"+
				".each{_V4=g.v(it)};"+

			"g.addEdge(_V4,_V3,_TP2);"+

			"g.addEdge(_V0,_V3,_TP3);"+

			"g.V('"+typeof(MemberType).Name+"Id',{{MemberTypeId}}L)[0]"+
				".each{_V5=g.v(it)};"+

			"g.addEdge(_V3,_V5,_TP4);"+

			"_V3;";

		private long vAssigningMemberId;
		private long vMemberId;
		private long vMemberTypeId;

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
			MockApiCtx
				.Setup(x => x.DbSingle<MemberTypeAssign>("AddMemberTypeAssign",
					It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction tx) => AddMemberTypeAssign(tx));
		}

		/*--------------------------------------------------------------------------------------------*/
		private MemberTypeAssign AddMemberTypeAssign(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			UsageMap.Increment("AddMemberTypeAssign");

			string expect = Query
				.Replace("{{MemberTypeAssignId}}", vNewMtaId+"")
				.Replace("{{UtcNowTicks}}", vUtcNow.Ticks+"")
				.Replace("{{AssigningMemberId}}", vAssigningMemberId+"")
				.Replace("{{MemberId}}", vMemberId+"")
				.Replace("{{MemberTypeId}}", vMemberTypeId+"");

			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", typeof(MemberHasHistoricMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP1", typeof(RootContainsMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP2", typeof(MemberCreatesMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP3", typeof(MemberHasMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP4", typeof(MemberTypeAssignUsesMemberType).Name);

			return vMtaResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			MemberTypeAssign result = Tasks.AddMemberTypeAssign(MockApiCtx.Object,
				vAssigningMemberId, vMemberId, vMemberTypeId);

			UsageMap.AssertUses("AddMemberTypeAssign", 1);
			Assert.AreEqual(vMtaResult, result, "Incorrect Result.");
		}

	}

}