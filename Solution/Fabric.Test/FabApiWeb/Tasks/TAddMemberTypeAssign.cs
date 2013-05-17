﻿using System;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TAddMemberTypeAssign : TWebTasks {

		private static readonly string Query =
			"_V0=g.V('"+PropDbName.Member_MemberId+"',_TP).next();"+
			"_V1=_V0.outE('"+RelDbName.MemberHasMemberTypeAssign+"').inV.next();"+
			"_V1.inE('"+RelDbName.MemberHasMemberTypeAssign+"')"+
				".remove();"+
			"g.addEdge(_V0,_V1,_TP);"+
			"_V2=g.addVertex(["+
				PropDbName.MemberTypeAssign_MemberTypeAssignId+":_TP,"+
				PropDbName.MemberTypeAssign_MemberTypeId+":_TP,"+
				PropDbName.NodeForAction_Performed+":_TP,"+
				PropDbName.Node_FabType+":_TP"+
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
			MockApiCtx
				.Setup(x => x.DbSingle<MemberTypeAssign>("AddMemberTypeAssign",
					It.IsAny<IWeaverTransaction>()))
				.Returns((string s, IWeaverTransaction tx) => AddMemberTypeAssign(tx));
		}

		/*--------------------------------------------------------------------------------------------*/
		private MemberTypeAssign AddMemberTypeAssign(IWeaverTransaction pTx) {
			TestUtil.LogWeaverScript(pTx);
			UsageMap.Increment("AddMemberTypeAssign");

			string expect = TestUtil.InsertParamIndexes(Query, "_TP");
			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(pTx.Params, "_TP", new object[] {
				vMemberId,
				RelDbName.MemberHasHistoricMemberTypeAssign,
				vNewMtaId,
				vMemberTypeId,
				vUtcNow.Ticks,
				(byte)NodeFabType.MemberTypeAssign,
				vAssigningMemberId,
				RelDbName.MemberCreatesMemberTypeAssign,
				RelDbName.MemberHasMemberTypeAssign
			});

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