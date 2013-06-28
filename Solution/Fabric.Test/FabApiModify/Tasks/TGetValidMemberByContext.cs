using Fabric.Domain;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Common;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiModify.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class TGetValidMemberByContext : TModifyTasks {

		private const string Query =
			"g.V('"+PropDbName.Artifact_ArtifactId+"',_P0)"+
				".outE('"+EdgeDbName.UserDefinesMember+"').inV"+
					".as('step5')"+
				".inE('"+EdgeDbName.AppDefinesMember+"').outV"+
					".has('"+PropDbName.Artifact_ArtifactId+"',Tokens.T.eq,_P1)"+
				".back('step5')"+
				".outE('"+EdgeDbName.MemberHasMemberTypeAssign+"').inV"+
					".has('"+PropDbName.MemberTypeAssign_MemberTypeId+"',Tokens.T.neq,_P2)"+
					".has('"+PropDbName.MemberTypeAssign_MemberTypeId+"',Tokens.T.neq,_P3)"+
					".has('"+PropDbName.MemberTypeAssign_MemberTypeId+"',Tokens.T.neq,_P4)"+
				".back('step5');";

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

			SetUpMember(vAppId, vUserId);

			var mda = MockDataAccess.Create(OnExecute);
			mda.MockResult.SetupToElement(vMemberResult);
			MockDataList.Add(mda);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void OnExecute(MockDataAccess pData) {
			MockDataAccessCmd cmd = pData.GetCommand(0);
			Assert.AreEqual(Query, cmd.Script, "Incorrect Query.Script.");
			TestUtil.CheckParam(cmd.Params, "_P0", vUserId);
			TestUtil.CheckParam(cmd.Params, "_P1", vAppId);
			TestUtil.CheckParam(cmd.Params, "_P2", (long)MemberTypeId.None);
			TestUtil.CheckParam(cmd.Params, "_P3", (long)MemberTypeId.Invite);
			TestUtil.CheckParam(cmd.Params, "_P4", (long)MemberTypeId.Request);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Member result = Tasks.GetValidMemberByContext(MockApiCtx.Object);

			AssertDataExecution(true);
			Assert.AreEqual(vMemberResult, result, "Incorrect Result.");

			MockMemCache.Verify(x => x.AddMember(vAppId, vUserId, vMemberResult, null), Times.Once());
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SuccessCache() {
			vCacheMember = new Member();
			MockMemCache.Setup(x => x.FindMember(vAppId, vUserId)).Returns(vCacheMember);
			
			Member result = Tasks.GetValidMemberByContext(MockApiCtx.Object);

			AssertDataExecution(false);
			Assert.AreEqual(vCacheMember, result, "Incorrect Result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NotFound() {
			MockDataList[0].MockResult.SetupToElement<Member>(null);
			MockMemCache.Setup(x => x.FindMember(vAppId, vUserId)).Returns((Member)null);

			Member result = Tasks.GetValidMemberByContext(MockApiCtx.Object);

			AssertDataExecution(true);
			Assert.Null(result, "Incorrect Result.");

			MockMemCache.Verify(x => x.AddMember(vAppId, vUserId, null, null), Times.Never());
		}

	}

}