using Fabric.Api.Web;
using Fabric.Api.Web.Results;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Fabric.Test.Integration.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiWeb {

	/*================================================================================================*/
	[TestFixture]
	public class XCreateUser : XBaseWebFunc {
		
		private string vEmail;
		private string vName;
		private string vPassword;
		
		private CreateUserResult vResult;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			IsReadOnlyTest = true;
			
			vEmail = "new@user.com";
			vName = "NewUser";
			vPassword = "NewPassword";
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new CreateUser(Tasks, vName, vPassword, vEmail);
			vResult = func.Go(ApiCtx);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			IsReadOnlyTest = false;
			
			TestGo();
			
			Assert.NotNull(vResult, "Result should not be null.");
			Assert.NotNull(vResult.NewUser, "Result.NewUser should not be null.");
			Assert.NotNull(vResult.NewEmail, "Result.NewEmail should not be null.");
			
			////
			
			Email newEmail = GetNode<Email>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newEmail, "New Email was not created.");
			Assert.AreEqual(newEmail.EmailId, vResult.NewEmail.EmailId,
				"Incorrect Result.NewEmail.EmailId.");
			
			User newUser = GetNode<User>(ApiCtx.SharpflakeIds[1]);
			Assert.NotNull(newUser, "New User was not created.");
			Assert.AreEqual(newUser.UserId, vResult.NewUser.UserId,
				"Incorrect Result.NewUser.UserId.");

			Assert.AreEqual(ApiCtx.SharpflakeIds[2], newUser.ArtifactId, "Incorrect User.ArtifactId.");
			                
			Member newMember = GetNode<Member>(ApiCtx.SharpflakeIds[3]);
			Assert.NotNull(newMember, "New Member was not created.");
			
			MemberTypeAssign newMta = GetNode<MemberTypeAssign>(ApiCtx.SharpflakeIds[4]);
			Assert.NotNull(newMta, "New MemberTypeAssign was not created.");
			
			NewNodeCount = 4;
			NewRelCount = 0;
			
			NodeConnections conn = GetNodeConnections(newEmail);
			conn.AssertRelCount(1, 0);
			conn.AssertRel<UserUsesEmail, User>(false, newUser.UserId);
			NewRelCount += 1;
			
			conn = GetNodeConnections(newUser);
			conn.AssertRelCount(1, 2);
			conn.AssertRel<UserUsesEmail, Email>(true, newEmail.EmailId);
			conn.AssertRel<UserDefinesMember, Member>(true, newMember.MemberId);
			conn.AssertRel<MemberCreatesArtifact, Member>(false, newMember.MemberId);
			NewRelCount += 3-1;
			
			conn = GetNodeConnections(newMember);
			conn.AssertRelCount(2, 2);
			conn.AssertRel<UserDefinesMember, User>(false, newUser.UserId);
			conn.AssertRel<AppDefinesMember, App>(false, (long)AppId.FabricSystem);
			conn.AssertRel<MemberHasMemberTypeAssign, MemberTypeAssign>(true,
				newMta.MemberTypeAssignId);
			conn.AssertRel<MemberCreatesArtifact, Artifact>(true, 
				newUser.ArtifactId, typeof(Artifact).Name+"Id");
			NewRelCount += 4-2;
			
			conn = GetNodeConnections(newMta);
			conn.AssertRelCount(2, 1);
			conn.AssertRel<MemberHasMemberTypeAssign, Member>(false, newMember.MemberId);
			conn.AssertRel<MemberCreatesMemberTypeAssign, Member>(false, (long)MemberId.FabFabData);
			conn.AssertRel<MemberTypeAssignUsesMemberType, MemberType>(true,
				(long)MemberTypeId.Member);
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
		[TestCase(3)]
		[TestCase(17)]
		public void ErrNameLength(int pLength) {
			vName = new string('a', pLength);
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNameInvalid() {
			vName = "zach@test";
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrNameDuplicate() {
			vName = "ZachKinstner";
			TestUtil.CheckThrows<FabDuplicateFault>(true, TestGo);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrPasswordNull() {
			vPassword = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(7)]
		[TestCase(33)]
		public void ErrPasswordLength(int pLength) {
			vPassword = new string('a', pLength);
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, TestGo);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrEmailNull() {
			vEmail = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(257)]
		public void ErrEmailLength(int pLength) {
			vEmail = new string('a', pLength);
			TestUtil.CheckThrows<FabArgumentLengthFault>(true, TestGo);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrEmailInvalid() {
			vEmail = "zach@test";
			TestUtil.CheckThrows<FabArgumentValueFault>(true, TestGo);
		}

	}

}