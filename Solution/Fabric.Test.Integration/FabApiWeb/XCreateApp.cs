using Fabric.Api.Web;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Integration.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiWeb {

	/*================================================================================================*/
	[TestFixture]
	public class XCreateApp : XBaseWebFunc {
		
		private string vName;
		private long vUserId;
		private SetupUsers.EmailId vExpectEmailId;
		
		private App vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
			UsesElasticSearch = true;
			
			vName = "New Test App";
			vUserId = (long)UserZach;
			vExpectEmailId = SetupUsers.EmailId.Zach_AEI;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new CreateApp(Tasks, vName, vUserId);
			vResult = func.Go(ApiCtx);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			IsReadOnlyTest = false;
			
			TestGo();
			
			Assert.NotNull(vResult, "Result should not be null.");
			
			////
			
			App newApp = GetVertex<App>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newApp, "New App was not created.");
			Assert.AreEqual(newApp.ArtifactId, vResult.ArtifactId, "Incorrect Result.ArtifactId.");

			Member newMember = GetVertex<Member>(ApiCtx.SharpflakeIds[1]);
			Assert.NotNull(newMember, "New Member was not created.");
			
			MemberTypeAssign newMta = GetVertex<MemberTypeAssign>(ApiCtx.SharpflakeIds[2]);
			Assert.NotNull(newMta, "New MemberTypeAssign was not created.");
			
			NewVertexCount = 3;
			NewEdgeCount = 0;
			
			VertexConnections conn = GetVertexConnections(newApp);
			conn.AssertEdgeCount(1, 2);
			conn.AssertEdge<AppUsesEmail, Email>(true, (long)vExpectEmailId);
			conn.AssertEdge<AppDefinesMember, Member>(true, newMember.MemberId);
			conn.AssertEdge<MemberCreatesArtifact, Member>(false, newMember.MemberId);
			NewEdgeCount += 3;
			
			conn = GetVertexConnections(newMember);
			conn.AssertEdgeCount(2, 2);
			conn.AssertEdge<UserDefinesMember, User>(false, vUserId);
			conn.AssertEdge<AppDefinesMember, App>(false, newApp.ArtifactId);
			conn.AssertEdge<MemberHasMemberTypeAssign, MemberTypeAssign>(true,
				newMta.MemberTypeAssignId);
			conn.AssertEdge<MemberCreatesArtifact, Artifact>(true, 
				newApp.ArtifactId, PropDbName.Artifact_ArtifactId);
			NewEdgeCount += 4-2;
			
			conn = GetVertexConnections(newMta);
			conn.AssertEdgeCount(2, 0);
			conn.AssertEdge<MemberHasMemberTypeAssign, Member>(false, newMember.MemberId);
			conn.AssertEdge<MemberCreatesMemberTypeAssign, Member>(false, (long)MemberId.FabFabData);
			NewEdgeCount += 2-1;
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNameNull() {
			vName = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(2)]
		[TestCase(65)]
		public void ErrNameLength(int pLength) {
			vName = new string('a', pLength);
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNameInvalid() {
			vName = "test`";
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNameDuplicate() {
			vName = "Kinstner PHOTO Gallery";
			TestUtil.CheckThrows<FabDuplicateFault>(true, TestGo);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrUserIdValue() {
			vUserId = 0;
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrUserIdNotFound() {
			vUserId = 999;
			TestUtil.CheckThrows<FabNotFoundFault>(true, TestGo);
		}
		
	}

}