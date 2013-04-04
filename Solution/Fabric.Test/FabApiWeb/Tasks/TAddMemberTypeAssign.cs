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
			"_V0=g.V('"+typeof(Member).Name+"Id',_TP0)[0].next();"+
			"_V1=_V0.outE('"+typeof(MemberHasMemberTypeAssign).Name+"').inV.next();"+
			"_V1.inE('"+typeof(MemberHasMemberTypeAssign).Name+"')"+
				".remove();"+
			"g.addEdge(_V0,_V1,_TP1);"+
			"_V2=g.V('"+typeof(Root).Name+"Id',_TP2)[0].next();"+
			"_V3=g.addVertex(["+
				typeof(MemberTypeAssign).Name+"Id:_TP3,"+
				"Performed:_TP4"+
			"]);"+
			"g.addEdge(_V2,_V3,_TP5);"+
			"_V4=g.V('"+typeof(Member).Name+"Id',_TP6)[0].next();"+
			"g.addEdge(_V4,_V3,_TP7);"+
			"g.addEdge(_V0,_V3,_TP8);"+
			"_V5=g.V('"+typeof(MemberType).Name+"Id',_TP9)[0].next();"+
			"g.addEdge(_V3,_V5,_TP10);"+
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

			Assert.AreEqual(Query, pTx.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pTx.Params, "_TP0", vMemberId);
			TestUtil.CheckParam(pTx.Params, "_TP1", typeof(MemberHasHistoricMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP2", 0);
			TestUtil.CheckParam(pTx.Params, "_TP3", vNewMtaId);
			TestUtil.CheckParam(pTx.Params, "_TP4", vUtcNow.Ticks);
			TestUtil.CheckParam(pTx.Params, "_TP5", typeof(RootContainsMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP6", vAssigningMemberId);
			TestUtil.CheckParam(pTx.Params, "_TP7", typeof(MemberCreatesMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP8", typeof(MemberHasMemberTypeAssign).Name);
			TestUtil.CheckParam(pTx.Params, "_TP9", vMemberTypeId);
			TestUtil.CheckParam(pTx.Params, "_TP10", typeof(MemberTypeAssignUsesMemberType).Name);

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