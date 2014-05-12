using Fabric.Database.Init.Setups;
using Fabric.Domain;
using Fabric.Domain.Enums;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Query;
using Fabric.Operations.Create;
using Fabric.Test.Integration.Shared;
using NUnit.Framework;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.Test.Integration.Operations.Create {

	/*================================================================================================*/
	public class XCreateUserAccountOperation : IntegrationTest {

		private CreateOperationBuilder vBuild;
		private CreateOperationTasks vTasks;

		private string vEmail;
		private string vUsername;
		private string vPassword;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vBuild = new CreateOperationBuilder();
			vTasks = new CreateOperationTasks();

			vEmail = "new@user.com";
			vUsername = "MyNewName";
			vPassword = "MyPassword";
		}

		/*--------------------------------------------------------------------------------------------*/
		private CreateUserAccountOperation.Result ExecuteOperation() {
			var op = new CreateUserAccountOperation();
			return op.Execute(OpCtx, vBuild, vTasks, vEmail, vUsername, vPassword);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			CreateUserAccountOperation.Result result = ExecuteOperation();

			Assert.AreEqual(CreateUserAccountOperation.ResultStatus.Success, result.Status, 
				"Incorrect Status.");

			XCreateOperation.CheckNewVertex(result.NewUser, VertexType.Id.User);
			XCreateOperation.CheckNewVertex(result.NewMember, VertexType.Id.Member);
			XCreateOperation.CheckNewVertex(result.NewEmail, VertexType.Id.Email);

			Assert.AreEqual(vUsername, result.NewUser.Name, "Incorrect NewUser.Name.");
			Assert.AreEqual((byte)MemberType.Id.Member, result.NewMember.MemberType, 
				"Incorrect NewMember.MemberType.");
			Assert.AreEqual(vEmail, result.NewEmail.Address, "Incorrect NewEmail.Address.");

			NewVertexCount = 3;
			NewEdgeCount = 8;

			const WeaverStepHasOp eq = WeaverStepHasOp.EqualTo;
			IWeaverStepAs<User> userAlias;
			IWeaverStepAs<Member> memAlias;
			IWeaverStepAs<Member> creMemAlias;
			IWeaverStepAs<App> appAlias;
			IWeaverStepAs<Email> emailAlias;

			//Confirm new User and three edges
			IWeaverQuery verifyUser = Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.VertexId, result.NewUser.VertexId)
				.As(out userAlias)
				.DefinesMembers
					.Has(x => x.AppId, eq, (long)SetupAppId.FabSys)
					.Has(x => x.MemberType, eq, (byte)MemberType.Id.Member)
					.Has(x => x.Timestamp, eq, result.NewMember.Timestamp)
				.ToMember
					.Has(x => x.VertexId, eq, result.NewMember.VertexId)
				.Back(userAlias)
				.CreatedByMember.ToMember
					.Has(x => x.VertexId, eq, result.NewMember.VertexId)
				.Back(userAlias)
				.UsesEmails.ToEmail
					.Has(x => x.Address, eq, vEmail)
				.Back(userAlias)
				.ToQuery();

			//Confirm new Member and two edges
			IWeaverQuery verifyMem = Weave.Inst.Graph
				.V.ExactIndex<Member>(x => x.VertexId, result.NewMember.VertexId)
				.As(out memAlias)
				.DefinedByApp.ToApp
					.Has(x => x.VertexId, eq, (long)SetupAppId.FabSys)
				.Back(memAlias)
				.DefinedByUser.ToUser
					.Has(x => x.VertexId, eq, result.NewUser.VertexId)
				.Back(memAlias)
				.ToQuery();

			//Confirm creator Member and one new edge
			IWeaverQuery verifyCreatorMem = Weave.Inst.Graph
				.V.ExactIndex<Member>(x => x.VertexId, result.NewMember.VertexId)
				.As(out creMemAlias)
				.CreatesArtifacts
					.Has(x => x.VertexType, eq, (byte)VertexType.Id.User)
					.Has(x => x.Timestamp, eq, result.NewUser.Timestamp)
				.ToArtifact
					.Has(x => x.VertexId, eq, result.NewUser.VertexId)
				.Back(creMemAlias)
				.ToQuery();

			//Confirm new Member's App and one new edge
			IWeaverQuery verifyCreatorUser = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.VertexId, (long)SetupAppId.FabSys)
				.As(out appAlias)
				.DefinesMembers
					.Has(x => x.UserId, eq, result.NewUser.VertexId)
					.Has(x => x.MemberType, eq, (byte)MemberType.Id.Member)
					.Has(x => x.Timestamp, eq, result.NewMember.Timestamp)
				.ToMember
					.Has(x => x.VertexId, eq, result.NewMember.VertexId)
				.Back(appAlias)
				.ToQuery();

			//Confirm new Email and one edge
			IWeaverQuery verifyEmail = Weave.Inst.Graph
				.V.ExactIndex<Email>(x => x.VertexId, result.NewEmail.VertexId)
				.As(out emailAlias)
				.UsedByArtifact.ToArtifact
					.Has(x => x.VertexId, eq, result.NewUser.VertexId)
				.Back(emailAlias)
				.ToQuery();

			VerificationQueryFunc = () => {
				IDataResult dr = OpCtx.ExecuteForTest(verifyUser, "CreateUserAccountOperation-VerifyU");
				Assert.AreEqual(1, dr.GetCommandResultCount(), "New User not verified.");

				dr = OpCtx.ExecuteForTest(verifyMem, "CreateUserAccountOperation-VerifyM");
				Assert.AreEqual(1, dr.GetCommandResultCount(), "New Member not verified.");

				dr = OpCtx.ExecuteForTest(verifyCreatorMem, "CreateUserAccountOperation-VerifyCM");
				Assert.AreEqual(1, dr.GetCommandResultCount(), "Creator Member not verified.");

				dr = OpCtx.ExecuteForTest(verifyCreatorUser, "CreateUserAccountOperation-VerifyCU");
				Assert.AreEqual(1, dr.GetCommandResultCount(), "Creator User not verified.");

				dr = OpCtx.ExecuteForTest(verifyEmail, "CreateUserAccountOperation-VerifyE");
				Assert.AreEqual(1, dr.GetCommandResultCount(), "New Email not verified.");
			};
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrDuplicateUsername() {
			IsReadOnlyTest = true;
			vUsername = "zachkinstner";

			CreateUserAccountOperation.Result result = ExecuteOperation();

			Assert.AreEqual(CreateUserAccountOperation.ResultStatus.DuplicateUsername, result.Status,
				"Incorrect Status.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrDuplicateEmail() {
			IsReadOnlyTest = true;
			vEmail = "zach@aestheticinteractive.com";
			
			CreateUserAccountOperation.Result result = ExecuteOperation();

			Assert.AreEqual(CreateUserAccountOperation.ResultStatus.DuplicateEmail, result.Status, 
				"Incorrect Status.");
		}

	}

}