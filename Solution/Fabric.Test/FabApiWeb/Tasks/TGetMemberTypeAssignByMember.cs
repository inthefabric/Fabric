﻿using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetMemberTypeAssignByMember : TWebTasks {

		private static readonly string Query =
			"g.V('"+typeof(Member).Name+"Id',_P0)"+
			".outE('"+typeof(MemberHasMemberTypeAssign).Name+"').inV;";

		private long vMemberId;
		private MemberTypeAssign vMtaResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vMemberId = 43864313;
			vMtaResult = new MemberTypeAssign();

			MockApiCtx
				.Setup(x => x.DbSingle<MemberTypeAssign>("GetMemberTypeAssignByMember",
					It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetMemberTypeAssignByMember(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private MemberTypeAssign GetMemberTypeAssignByMember(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetMemberTypeAssignByMember");

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", vMemberId);

			return vMtaResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			MemberTypeAssign result = Tasks.GetMemberTypeAssignByMember(MockApiCtx.Object, vMemberId);

			UsageMap.AssertUses("GetMemberTypeAssignByMember", 1);
			Assert.AreEqual(vMtaResult, result, "Incorrect Result.");
		}

	}

}