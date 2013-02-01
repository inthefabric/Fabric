using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetValidMemberByContext : TModifyTasks {

		private readonly static string Query =
			"g.V('"+typeof(User).Name+"Id',{{UserId}}L)[0]"+
				".outE('"+typeof(UserDefinesMember).Name+"').inV"+
					".as('step3')"+
				".inE('"+typeof(AppDefinesMember).Name+"').outV"+
					".has('"+typeof(App).Name+"Id',Tokens.T.eq,{{AppId}}L)"+
				".back('step3')"+
				".outE('"+typeof(MemberHasMemberTypeAssign).Name+"').inV"+
				".outE('"+typeof(MemberTypeAssignUsesMemberType).Name+"').inV"+
					".has('"+typeof(MemberType).Name+"Id',Tokens.T.neq,"+(long)MemberTypeId.None+"L)"+
					".has('"+typeof(MemberType).Name+"Id',Tokens.T.neq,"+(long)MemberTypeId.Invite+"L)"+
					".has('"+typeof(MemberType).Name+"Id',Tokens.T.neq,"+(long)MemberTypeId.Request+"L)"+
				".back('step3');";

		private long vUserId;
		private long vAppId;
		private Member vMemberResult;
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vUserId = 123;
			vAppId = 93485;
			vMemberResult = new Member();

			MockApiCtx.SetupGet(x => x.UserId).Returns(vUserId);
			MockApiCtx.SetupGet(x => x.AppId).Returns(vAppId);

			MockApiCtx
				.Setup(x => x.DbSingle<Member>("GetValidMemberByContext", It.IsAny<IWeaverQuery>()))
				.Returns((string s, IWeaverQuery q) => GetMember(q));
		}

		/*--------------------------------------------------------------------------------------------*/
		private Member GetMember(IWeaverQuery pQuery) {
			TestUtil.LogWeaverScript(pQuery);
			UsageMap.Increment("GetValidMemberByContext");

			string expect = Query
				.Replace("{{UserId}}", vUserId+"")
				.Replace("{{AppId}}", vAppId+"");

			Assert.AreEqual(expect, pQuery.Script, "Incorrect Query.Script.");
			return vMemberResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Member result = Tasks.GetValidMemberByContext(MockApiCtx.Object);

			UsageMap.AssertUses("GetValidMemberByContext", 1);
			Assert.AreEqual(vMemberResult, result, "Incorrect Result.");
		}

	}

}