﻿using Fabric.Api.Web;
using Fabric.Api.Web.Results;
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
			
			Email newEmail = GetVertex<Email>(ApiCtx.SharpflakeIds[0]);
			Assert.NotNull(newEmail, "New Email was not created.");
			Assert.AreEqual(newEmail.EmailId, vResult.NewEmail.EmailId,
				"Incorrect Result.NewEmail.EmailId.");
			
			User newUser = GetVertex<User>(ApiCtx.SharpflakeIds[1]);
			Assert.NotNull(newUser, "New User was not created.");
			Assert.AreEqual(newUser.ArtifactId, vResult.NewUser.ArtifactId,
				"Incorrect Result.NewUser.ArtifactId.");
			                
			Member newMember = GetVertex<Member>(ApiCtx.SharpflakeIds[2]);
			Assert.NotNull(newMember, "New Member was not created.");
			
			MemberTypeAssign newMta = GetVertex<MemberTypeAssign>(ApiCtx.SharpflakeIds[3]);
			Assert.NotNull(newMta, "New MemberTypeAssign was not created.");
			
			NewVertexCount = 4;
			NewEdgeCount = 0;
			
			VertexConnections conn = GetVertexConnections(newEmail);
			conn.AssertEdgeCount(1, 0);
			conn.AssertEdge<UserUsesEmail, User>(false, newUser.ArtifactId);
			NewEdgeCount += 1;
			
			conn = GetVertexConnections(newUser);
			conn.AssertEdgeCount(1, 2);
			conn.AssertEdge<UserUsesEmail, Email>(true, newEmail.EmailId);
			conn.AssertEdge<UserDefinesMember, Member>(true, newMember.MemberId);
			conn.AssertEdge<MemberCreatesArtifact, Member>(false, newMember.MemberId);
			NewEdgeCount += 3-1;
			
			conn = GetVertexConnections(newMember);
			conn.AssertEdgeCount(2, 2);
			conn.AssertEdge<UserDefinesMember, User>(false, newUser.ArtifactId);
			conn.AssertEdge<AppDefinesMember, App>(false, (long)AppId.FabricSystem);
			conn.AssertEdge<MemberHasMemberTypeAssign, MemberTypeAssign>(true,
				newMta.MemberTypeAssignId);
			conn.AssertEdge<MemberCreatesArtifact, Artifact>(true,
				newUser.ArtifactId, PropDbName.Artifact_ArtifactId);
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
		[TestCase(0)]
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