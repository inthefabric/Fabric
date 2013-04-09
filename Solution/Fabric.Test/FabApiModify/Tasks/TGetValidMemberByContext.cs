using Fabric.Domain;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Domain.Types;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetValidMemberByContext : TModifyTasks {

		private readonly static string Query =
			"g.V('"+typeof(User).Name+"Id',_P0)"+
				".outE('"+typeof(UserDefinesMember).Name+"').inV"+
					".as('step3')"+
				".inE('"+typeof(AppDefinesMember).Name+"').outV"+
					".has('"+typeof(App).Name+"Id',Tokens.T.eq,_P1)"+
				".back('step3')"+
				".outE('"+typeof(MemberHasMemberTypeAssign).Name+"').inV"+
					".has('"+typeof(MemberType).Name+"Id',Tokens.T.neq,_P2)"+
					".has('"+typeof(MemberType).Name+"Id',Tokens.T.neq,_P3)"+
					".has('"+typeof(MemberType).Name+"Id',Tokens.T.neq,_P4)"+
				".back('step3');";

		private long vUserId;
		private long vAppId;
		private Member vMemberResult;
		private Member vCacheMember;
		
		
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

			Assert.AreEqual(Query, pQuery.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(pQuery.Params, "_P0", vUserId);
			TestUtil.CheckParam(pQuery.Params, "_P1", vAppId);
			TestUtil.CheckParam(pQuery.Params, "_P2", (long)MemberTypeId.None);
			TestUtil.CheckParam(pQuery.Params, "_P3", (long)MemberTypeId.Invite);
			TestUtil.CheckParam(pQuery.Params, "_P4", (long)MemberTypeId.Request);

			return vMemberResult;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Member result = Tasks.GetValidMemberByContext(MockApiCtx.Object);

			UsageMap.AssertUses("GetValidMemberByContext", 1);
			Assert.AreEqual(vMemberResult, result, "Incorrect Result.");

			MockMemCache.Verify(x => x.AddMember(vAppId, vUserId, vMemberResult, null), Times.Once());
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SuccessCache() {
			vCacheMember = new Member();
			MockMemCache.Setup(x => x.FindMember(vAppId, vUserId)).Returns(vCacheMember);
			
			Member result = Tasks.GetValidMemberByContext(MockApiCtx.Object);

			UsageMap.AssertUses("GetValidMemberByContext", 0);
			Assert.AreEqual(vCacheMember, result, "Incorrect Result.");
		}

	}

}