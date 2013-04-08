using Fabric.Api.Web;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Domain.Types;
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
			
			App newApp = GetNode<App>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newApp, "New App was not created.");
			Assert.AreEqual(newApp.AppId, vResult.AppId, "Incorrect Result.AppId.");

			Assert.AreEqual(ApiCtx.SharpflakeIds[1], newApp.ArtifactId, "Incorrect App.ArtifactId.");

			Member newMember = GetNode<Member>(ApiCtx.SharpflakeIds[2]);
			Assert.NotNull(newMember, "New Member was not created.");
			
			MemberTypeAssign newMta = GetNode<MemberTypeAssign>(ApiCtx.SharpflakeIds[3]);
			Assert.NotNull(newMta, "New MemberTypeAssign was not created.");
			
			NewNodeCount = 3;
			NewRelCount = 0;
			
			NodeConnections conn = GetNodeConnections(newApp);
			conn.AssertRelCount(1, 2);
			conn.AssertRel<AppUsesEmail, Email>(true, (long)vExpectEmailId);
			conn.AssertRel<AppDefinesMember, Member>(true, newMember.MemberId);
			conn.AssertRel<MemberCreatesArtifact, Member>(false, newMember.MemberId);
			NewRelCount += 3;
			
			conn = GetNodeConnections(newMember);
			conn.AssertRelCount(2, 2);
			conn.AssertRel<UserDefinesMember, User>(false, vUserId);
			conn.AssertRel<AppDefinesMember, App>(false, newApp.AppId);
			conn.AssertRel<MemberHasMemberTypeAssign, MemberTypeAssign>(true,
				newMta.MemberTypeAssignId);
			conn.AssertRel<MemberCreatesArtifact, Artifact>(true, 
				newApp.ArtifactId, typeof(Artifact).Name+"Id");
			NewRelCount += 4-2;
			
			conn = GetNodeConnections(newMta);
			conn.AssertRelCount(2, 1);
			conn.AssertRel<MemberHasMemberTypeAssign, Member>(false, newMember.MemberId);
			conn.AssertRel<MemberCreatesMemberTypeAssign, Member>(false, (long)MemberId.FabFabData);
			conn.AssertRel<MemberTypeAssignUsesMemberType, MemberType>(true,
				(long)MemberTypeId.DataProvider);
			NewRelCount += 3-1;
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