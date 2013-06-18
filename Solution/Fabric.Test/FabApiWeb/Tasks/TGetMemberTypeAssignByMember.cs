using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiWeb.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetMemberTypeAssignByMember : TWebTasks {

		private const string Query =
			"g.V('"+PropDbName.Member_MemberId+"',_P0)"+
			".outE('"+EdgeDbName.MemberHasMemberTypeAssign+"').inV;";

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