using Fabric.Api.Oauth.Tasks;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Test.Integration.Common;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiOauth.Tasks {

	/*================================================================================================*/
	[TestFixture]
	public class XAddMemberEnsure : IntegTestBase {

		private long vAppId;
		private long vUserId;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			vAppId = -1;
			vUserId = -1;
		}

		/*--------------------------------------------------------------------------------------------*/
		private bool TestGo() {
			return new AddMemberEnsure(vAppId, vUserId).Go(ApiCtx);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppGal, UserZach)]
		[TestCase(AppBook, UserMel)]
		public void GoMemberExists(SetupUsers.AppId pAppId, SetupUsers.UserId pUserId) {
			vAppId = (long)pAppId;
			vUserId = (long)pUserId;

			bool result = TestGo();
			Assert.False(result, "Incorrect result.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppBook, UserPenny)]
		[TestCase(AppBook, UserGal)]
		public void GoAdd(SetupUsers.AppId pAppId, SetupUsers.UserId pUserId) {
			vAppId = (long)pAppId;
			vUserId = (long)pUserId;

			bool result = TestGo();
			Assert.True(result, "Incorrect result.");

			////
			
			Member newMem = GetNode<Member>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newMem, "New Member was not created.");

			MemberTypeAssign newMta = GetNode<MemberTypeAssign>(ApiCtx.SharpflakeIds[1]);
			Assert.NotNull(newMta, "New MemberTypeAssign was not created.");

			NodeConnections conn = GetNodeConnections(newMem);
			conn.AssertRelCount(3, 1);
			conn.AssertRel<RootContainsMember, Root>(false, 0);
			conn.AssertRel<AppDefinesMember, App>(false, vAppId);
			conn.AssertRel<UserDefinesMember, User>(false, vUserId);
			conn.AssertRel<MemberHasMemberTypeAssign, MemberTypeAssign>(
				true, newMta.MemberTypeAssignId);

			conn = GetNodeConnections(newMta);
			conn.AssertRelCount(3, 1);
			conn.AssertRel<RootContainsMemberTypeAssign, Root>(false, 0);
			conn.AssertRel<MemberHasMemberTypeAssign, Member>(false, newMem.MemberId);
			conn.AssertRel<MemberCreatesMemberTypeAssign, Member>(
				false, (long)SetupUsers.MemberId.FabFabData);
			conn.AssertRel<MemberTypeAssignUsesMemberType, MemberType>(true, (long)MemberTypeId.Member);

			NewNodeCount = 2;
			NewRelCount = 7;
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppGal, UserBook, SetupUsers.MemberId.GalBookDataNone, 
										SetupUsers.MemberTypeAssignId.GalBookDataNoneByBookBookData)]
		public void GoUpdate(SetupUsers.AppId pAppId, SetupUsers.UserId pUserId,
					SetupUsers.MemberId pUpdateMemberId, SetupUsers.MemberTypeAssignId pUpdateMtaId) {
			vAppId = (long)pAppId;
			vUserId = (long)pUserId;

			Member origMem = GetNode<Member>((long)pUpdateMemberId);
			Assert.NotNull(origMem, "Member is missing.");

			NodeConnections conn = GetNodeConnections(origMem);
			conn.AssertRelCount<MemberHasMemberTypeAssign>(true, 1);
			conn.AssertRelCount<MemberHasHistoricMemberTypeAssign>(true, 0);

			////

			bool result = TestGo();
			Assert.True(result, "Incorrect result.");

			////
			
			Member updateMem = GetNode<Member>((long)pUpdateMemberId);
			Assert.NotNull(updateMem, "The Member was deleted.");

			MemberTypeAssign newMta = GetNode<MemberTypeAssign>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newMta, "New MemberTypeAssign was not created.");

			conn = GetNodeConnections(updateMem);
			conn.AssertRelCount(3, 2);
			conn.AssertRel<RootContainsMember, Root>(false, 0);
			conn.AssertRel<AppDefinesMember, App>(false, vAppId);
			conn.AssertRel<UserDefinesMember, User>(false, vUserId);
			conn.AssertRel<MemberHasMemberTypeAssign, MemberTypeAssign>(
				true, newMta.MemberTypeAssignId);
			conn.AssertRel<MemberHasHistoricMemberTypeAssign, MemberTypeAssign>(
				true, (long)pUpdateMtaId);

			conn = GetNodeConnections(newMta);
			conn.AssertRelCount(3, 1);
			conn.AssertRel<RootContainsMemberTypeAssign, Root>(false, 0);
			conn.AssertRel<MemberHasMemberTypeAssign, Member>(false, updateMem.MemberId);
			conn.AssertRel<MemberCreatesMemberTypeAssign, Member>(
				false, (long)SetupUsers.MemberId.FabFabData);
			conn.AssertRel<MemberTypeAssignUsesMemberType, MemberType>(true, (long)MemberTypeId.Member);

			NewNodeCount = 1;
			NewRelCount = 5-1; //original Member-Has-MemberTypeAssign relationship is removed
		}

	}

}