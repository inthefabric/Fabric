﻿using Fabric.Api.Modify;
using Fabric.Api.Modify.Results;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Integration.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XCreateUser : XBaseModifyFunc {
		
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
			vResult = func.Go(Context);
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
			
			Email newEmail = GetNode<Email>(Context.SharpflakeIds[0]);
			Assert.NotNull(newEmail, "New Email was not created.");
			Assert.AreEqual(newEmail.EmailId, vResult.NewEmail.EmailId,
				"Incorrect Result.NewEmail.EmailId.");
			
			User newUser = GetNode<User>(Context.SharpflakeIds[1]);
			Assert.NotNull(newUser, "New User was not created.");
			Assert.AreEqual(newUser.UserId, vResult.NewUser.UserId,
				"Incorrect Result.NewUser.UserId.");
			                
			Member newMember = GetNode<Member>(Context.SharpflakeIds[2]);
			Assert.NotNull(newMember, "New Member was not created.");
			
			MemberTypeAssign newMta = GetNode<MemberTypeAssign>(Context.SharpflakeIds[3]);
			Assert.NotNull(newMta, "New MemberTypeAssign was not created.");
			
			Artifact newArtifact = GetNode<Artifact>(Context.SharpflakeIds[4]);
			Assert.NotNull(newArtifact, "New Artifact was not created.");
			
			NewNodeCount = 5;
			NewRelCount = 0;
			
			NodeConnections conn = GetNodeConnections(newEmail);
			conn.AssertRelCount(2, 0);
			conn.AssertRel<RootContainsEmail, Root>(false, 0);
			conn.AssertRel<UserUsesEmail, User>(false, newUser.UserId);
			NewRelCount += 2;
			
			conn = GetNodeConnections(newUser);
			conn.AssertRelCount(1, 3);
			conn.AssertRel<RootContainsUser, Root>(false, 0);
			conn.AssertRel<UserUsesEmail, Email>(true, newEmail.EmailId);
			conn.AssertRel<UserDefinesMember, Member>(true, newMember.MemberId);
			conn.AssertRel<UserHasArtifact, Artifact>(true, newArtifact.ArtifactId);
			NewRelCount += 4-1;
			
			conn = GetNodeConnections(newMember);
			conn.AssertRelCount(3, 2);
			conn.AssertRel<RootContainsMember, Root>(false, 0);
			conn.AssertRel<UserDefinesMember, User>(false, newUser.UserId);
			conn.AssertRel<AppDefinesMember, App>(false, (long)AppId.FabricSystem);
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
				(long)MemberTypeId.Member);
			NewRelCount += 4-1;
			
			conn = GetNodeConnections(newArtifact);
			conn.AssertRelCount(3, 1);
			conn.AssertRel<RootContainsArtifact, Root>(false, 0);
			conn.AssertRel<UserHasArtifact, User>(false, newUser.UserId);
			conn.AssertRel<MemberCreatesArtifact, Member>(false, newMember.MemberId);
			conn.AssertRel<ArtifactUsesArtifactType, ArtifactType>(true, (long)ArtifactTypeId.User);
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
			TestUtil.CheckThrows<FabArgumentFault>(true, TestGo);
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
			TestUtil.CheckThrows<FabArgumentFault>(true, TestGo);
		}

	}

}