using Fabric.Api.Oauth.Tasks;
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
			
			Member newMem = GetVertex<Member>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newMem, "New Member was not created.");

			MemberTypeAssign newMta = GetVertex<MemberTypeAssign>(ApiCtx.SharpflakeIds[1]);
			Assert.NotNull(newMta, "New MemberTypeAssign was not created.");

			VertexConnections conn = GetVertexConnections(newMem);
			conn.AssertEdgeCount(2, 1);
			conn.AssertEdge<AppDefinesMember, App>(false, vAppId);
			conn.AssertEdge<UserDefinesMember, User>(false, vUserId);
			conn.AssertEdge<MemberHasMemberTypeAssign, MemberTypeAssign>(
				true, newMta.MemberTypeAssignId);

			conn = GetVertexConnections(newMta);
			conn.AssertEdgeCount(2, 0);
			conn.AssertEdge<MemberHasMemberTypeAssign, Member>(false, newMem.MemberId);
			conn.AssertEdge<MemberCreatesMemberTypeAssign, Member>(
				false, (long)SetupUsers.MemberId.FabFabData);

			NewVertexCount = 2;
			NewEdgeCount = 4;
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(AppGal, UserBook, SetupUsers.MemberId.GalBookDataNone, 
										SetupUsers.MemberTypeAssignId.GalBookDataNoneByBookBookData)]
		public void GoUpdate(SetupUsers.AppId pAppId, SetupUsers.UserId pUserId,
					SetupUsers.MemberId pUpdateMemberId, SetupUsers.MemberTypeAssignId pUpdateMtaId) {
			vAppId = (long)pAppId;
			vUserId = (long)pUserId;

			Member origMem = GetVertex<Member>((long)pUpdateMemberId);
			Assert.NotNull(origMem, "Member is missing.");

			VertexConnections conn = GetVertexConnections(origMem);
			conn.AssertEdgeCount<MemberHasMemberTypeAssign>(true, 1);
			conn.AssertEdgeCount<MemberHasHistoricMemberTypeAssign>(true, 0);

			////

			bool result = TestGo();
			Assert.True(result, "Incorrect result.");

			////
			
			Member updateMem = GetVertex<Member>((long)pUpdateMemberId);
			Assert.NotNull(updateMem, "The Member was deleted.");

			MemberTypeAssign newMta = GetVertex<MemberTypeAssign>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newMta, "New MemberTypeAssign was not created.");

			conn = GetVertexConnections(updateMem);
			conn.AssertEdgeCount(2, 2);
			conn.AssertEdge<AppDefinesMember, App>(false, vAppId);
			conn.AssertEdge<UserDefinesMember, User>(false, vUserId);
			conn.AssertEdge<MemberHasMemberTypeAssign, MemberTypeAssign>(
				true, newMta.MemberTypeAssignId);
			conn.AssertEdge<MemberHasHistoricMemberTypeAssign, MemberTypeAssign>(
				true, (long)pUpdateMtaId);

			conn = GetVertexConnections(newMta);
			conn.AssertEdgeCount(2, 0);
			conn.AssertEdge<MemberHasMemberTypeAssign, Member>(false, updateMem.MemberId);
			conn.AssertEdge<MemberCreatesMemberTypeAssign, Member>(
				false, (long)SetupUsers.MemberId.FabFabData);

			NewVertexCount = 1;
			NewEdgeCount = 2;
		}

	}

}