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
			"_V0=g.V('"+typeof(Member).Name+"Id',_TP)[0].next();"+
			"_V1=_V0.outE('"+typeof(MemberHasMemberTypeAssign).Name+"').inV.next();"+
			"_V1.inE('"+typeof(MemberHasMemberTypeAssign).Name+"')"+
				".remove();"+
			"g.addEdge(_V0,_V1,_TP);"+
			"_V2=g.addVertex(["+
				typeof(MemberTypeAssign).Name+"Id:_TP,"+
				"Performed:_TP,"+
				"FabType:_TP"+
			"]);"+
			"_V3=g.V('"+typeof(Member).Name+"Id',_TP)[0].next();"+
			"g.addEdge(_V3,_V2,_TP);"+
			"g.addEdge(_V0,_V2,_TP);"+
			"_V4=g.V('"+typeof(MemberType).Name+"Id',_TP)[0].next();"+
			"g.addEdge(_V2,_V4,_TP);"+
			"_V2;";

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

			string expect = TestUtil.InsertParamIndexes(Query, "_TP");
			Assert.AreEqual(expect, pTx.Script, "Incorrect Query.Script.");

			TestUtil.CheckParams(pTx.Params, "_TP", new object[] {
				vMemberId,
				typeof(MemberHasHistoricMemberTypeAssign).Name,
				vNewMtaId,
				vUtcNow.Ticks,
				(int)NodeFabType.MemberTypeAssign,
				vAssigningMemberId,
				typeof(MemberCreatesMemberTypeAssign).Name,
				typeof(MemberHasMemberTypeAssign).Name,
				vMemberTypeId,
				typeof(MemberTypeAssignUsesMemberType).Name
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