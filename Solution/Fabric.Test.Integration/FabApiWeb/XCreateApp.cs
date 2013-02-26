using Fabric.Api.Web;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
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
			
			vName = "New Test App";
			vUserId = (long)UserZach;
			vExpectEmailId = SetupUsers.EmailId.Zach_AEI;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new CreateApp(Tasks, ModTasks, vName, vUserId);
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
			
			App newApp = GetNode<App>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newApp, "New App was not created.");
			Assert.AreEqual(newApp.AppId, vResult.AppId, "Incorrect Result.AppId.");
			                
			Member newMember = GetNode<Member>(ApiCtx.SharpflakeIds[1]);
			Assert.NotNull(newMember, "New Member was not created.");
			
			MemberTypeAssign newMta = GetNode<MemberTypeAssign>(ApiCtx.SharpflakeIds[2]);
			Assert.NotNull(newMta, "New MemberTypeAssign was not created.");
			
			Artifact newArtifact = GetNode<Artifact>(ApiCtx.SharpflakeIds[3]);
			Assert.NotNull(newArtifact, "New Artifact was not created.");
			
			NewNodeCount = 4;
			NewRelCount = 0;
			
			NodeConnections conn = GetNodeConnections(newApp);
			conn.AssertRelCount(1, 3);
			conn.AssertRel<RootContainsApp, Root>(false, 0);
			conn.AssertRel<AppUsesEmail, Email>(true, (long)vExpectEmailId);
			conn.AssertRel<AppDefinesMember, Member>(true, newMember.MemberId);
			conn.AssertRel<AppHasArtifact, Artifact>(true, newArtifact.ArtifactId);
			NewRelCount += 4;
			
			conn = GetNodeConnections(newMember);
			conn.AssertRelCount(3, 2);
			conn.AssertRel<RootContainsMember, Root>(false, 0);
			conn.AssertRel<UserDefinesMember, User>(false, vUserId);
			conn.AssertRel<AppDefinesMember, App>(false, newApp.AppId);
			conn.AssertRel<MemberHasMemberTypeAssign, MemberTypeAssign>(true,
				newMta.MemberTypeAssignId);
			conn.AssertRel<MemberCreatesArtifact, Artifact>(true, newArtifact.ArtifactId);
			NewRelCount += 5-1;
			
			conn = GetNodeConnections(newMta);
			conn.AssertRelCount(3, 1);
			conn.AssertRel<RootContainsMemberTypeAssign, Root>(false, 0);
			conn.AssertRel<MemberHasMemberTypeAssign, Member>(false, newMember.MemberId);
			conn.AssertRel<MemberCreatesMemberTypeAssign, Member>(false, (long)MemberId.FabFabData);
			conn.AssertRel<MemberTypeAssignUsesMemberType, MemberType>(true,
				(long)MemberTypeId.DataProvider);
			NewRelCount += 4-1;
			
			conn = GetNodeConnections(newArtifact);
			conn.AssertRelCount(3, 1);
			conn.AssertRel<RootContainsArtifact, Root>(false, 0);
			conn.AssertRel<AppHasArtifact, App>(false, newApp.AppId);
			conn.AssertRel<MemberCreatesArtifact, Member>(false, newMember.MemberId);
			conn.AssertRel<ArtifactUsesArtifactType, ArtifactType>(true, (long)ArtifactTypeId.App);
			NewRelCount += 4-2;
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