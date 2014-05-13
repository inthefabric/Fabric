using System;
using System.Collections.Generic;
using Fabric.Api.Objects;
using Fabric.Database.Init.Setups;
using Fabric.Domain;
using Fabric.Infrastructure.Faults;
using Fabric.Operations.Create;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateUserAccountOperation : TCreateCustomOperation {

		private long vNewUserId;
		private long vNewMemId;
		private long vNewEmailId;
		private string vUserCmd;
		private string vMemCmd;
		private string vEmailCmd;
		private Queue<long> vSharpflakeQueue;
		private Queue<string> vCmdIdQueue;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetUp() {
			base.SetUp();

			vNewUserId = 685239856293;
			vNewMemId = 123235332;
			vNewEmailId = 123235332;
			vUserCmd = "appCmd";
			vMemCmd = "memCmd";
			vEmailCmd = "emailCmd";
			vSharpflakeQueue = new Queue<long>(new[] { vNewUserId, vNewMemId, vNewEmailId });

			MockOpCtx.Setup(x => x.GetSharpflakeId<Vertex>()).Returns(vSharpflakeQueue.Dequeue);
			MockOpCtx.SetupGet(x => x.UtcNow).Returns(new DateTime(9999999999));
			MockOpCtx.SetupGet(x => x.Code32).Returns("123456789012345678901234567890ab");

			vCmdIdQueue = new Queue<string>(new[] { vUserCmd, vMemCmd, vEmailCmd });
			MockAcc.Setup(x => x.GetLatestCommandId()).Returns(vCmdIdQueue.Dequeue);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Execute() {
			const string email = "dont@fail.com";
			const string username = "newUser";
			const string password = "myPassword";
			const long fabAppId = (long)SetupAppId.FabSys;

			ICreateOperationBuilder build = MockBuild.Object;
			CreateOperationTasks tasks = MockTasks.Object;

			var expectUser = new User();
			var expectMem = new Member();
			var expectEmail = new Email();

			IWeaverVarAlias<User> userAlias = new WeaverVarAlias<User>("userAlias");
			IWeaverVarAlias<Member> memAlias = new WeaverVarAlias<Member>("memAlias");
			IWeaverVarAlias<Email> emailAlias = new WeaverVarAlias<Email>("emailAlias");

			MockData.Setup(x => x.Get<Email>(It.IsAny<IWeaverQuery>(),
					typeof(CreateUserAccountOperation).Name+"-FindDuplicateEmail"))
				.Returns((Email)null);

			MockBuild
				.Setup(x => x.StartSession())
				.Callback(CheckCallIndex("StartSession"));

			//// Add App

			MockTasks
				.Setup(x => x.FindDuplicateUserNameKey(build, ItIsVert<User>(vNewUserId)))
				.Callback(CheckCallIndex("FindDuplicateUserNameKey"));

			int addAppIndex = CallsAdded;

			MockTasks
				.Setup(x => x.AddUser(build, ItIsVert<User>(vNewUserId), out userAlias))
				.Callback(CheckCallIndex("AddUser"));

			//// Add Member

			MockTasks
				.Setup(x => x.FindDuplicateMember(build, vNewUserId, fabAppId))
				.Callback(CheckCallIndex("FindDuplicateMember"));

			int addMemIndex = CallsAdded;

			MockTasks
				.Setup(x => x.AddMember(build, ItIsVert<Member>(vNewMemId), out memAlias))
				.Callback(CheckCallIndex("AddMember"));

			//// Add Email

			int addEmailIndex = CallsAdded;

			MockTasks
				.Setup(x => x.AddEmail(build, ItIsVert<Email>(vNewEmailId), out emailAlias))
				.Callback(CheckCallIndex("AddEmail"));

			//// Add App edges

			MockTasks
				.Setup(x => x.AddArtifactCreatedByMember(
					build,
					ItIsVert<User>(vNewUserId),
					It.Is<CreateFabUser>(c => c.CreatedByMemberId == vNewMemId),
					It.Is<IWeaverVarAlias<Artifact>>(a => a.Name == userAlias.Name)
				))
				.Callback(CheckCallIndex("AddArtifactCreatedByMember"));

			//// Add Member edges

			MockTasks
				.Setup(x => x.AddMemberDefinedByApp(
					build,
					ItIsVert<Member>(vNewMemId),
					It.Is<CreateFabMember>(c => c.DefinedByAppId == fabAppId),
					It.Is<IWeaverVarAlias<Member>>(a => a.Name == memAlias.Name)
				))
				.Callback(CheckCallIndex("AddMemberDefinedByApp"));

			MockTasks
				.Setup(x => x.AddMemberDefinedByUser(
					build,
					ItIsVert<Member>(vNewMemId),
					It.Is<CreateFabMember>(c => c.DefinedByUserId == vNewUserId),
					It.Is<IWeaverVarAlias<Member>>(a => a.Name == memAlias.Name)
				))
				.Callback(CheckCallIndex("AddMemberDefinedByUser"));

			//// Add Email edges

			MockTasks
				.Setup(x => x.AddEmailUsedByArtifact(
					build,
					ItIsVert<Email>(vNewEmailId),
					It.Is<CreateFabEmail>(c => c.UsedByArtifactId == vNewUserId),
					It.Is<IWeaverVarAlias<Email>>(a => a.Name == emailAlias.Name)
				))
				.Callback(CheckCallIndex("AddEmailUsedByArtifact"));

			//// Finish setup
			
			MockBuild
				.Setup(x => x.CommitAndCloseSession())
				.Callback(CheckCallIndex("CommitAndCloseSession"));

			MockAcc.Setup(x => x.Execute(typeof(CreateUserAccountOperation).Name))
				.Returns(MockRes.Object);

			MockRes.Setup(x => x.GetCommandIndexByCmdId(vUserCmd)).Returns(addAppIndex);
			MockRes.Setup(x => x.GetCommandIndexByCmdId(vMemCmd)).Returns(addMemIndex);
			MockRes.Setup(x => x.GetCommandIndexByCmdId(vEmailCmd)).Returns(addEmailIndex);

			MockRes.Setup(x => x.ToElementAt<User>(addAppIndex, 0)).Returns(expectUser);
			MockRes.Setup(x => x.ToElementAt<Member>(addMemIndex, 0)).Returns(expectMem);
			MockRes.Setup(x => x.ToElementAt<Email>(addEmailIndex, 0)).Returns(expectEmail);

			//// Execute

			var op = new CreateUserAccountOperation();
			CreateUserAccountOperation.Result result = op.Execute(MockOpCtx.Object, build, tasks, 
				email, username, password);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(CreateUserAccountOperation.ResultStatus.Success, result.Status,
				"Incorrect Status");
			Assert.AreEqual(expectUser, result.NewUser, "Incorrect NewApp.");
			Assert.AreEqual(expectMem, result.NewMember, "Incorrect NewMember.");
			Assert.AreEqual(expectEmail, result.NewEmail, "Incorrect NewEmail.");
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrDuplicateEmail() {
			const string email = "dont@fail.com";

			MockData
				.Setup(x => x.Get<Email>(It.IsAny<IWeaverQuery>(), It.IsAny<string>()))
				.Returns(new Email());

			var op = new CreateUserAccountOperation();
			CreateUserAccountOperation.Result result = op.Execute(MockOpCtx.Object, MockBuild.Object, 
				MockTasks.Object, "a@b.c", "user", "pass");

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(CreateUserAccountOperation.ResultStatus.DuplicateEmail, result.Status,
				"Incorrect Status");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrDuplicateUser() {
			//Note: the fault would actually come from a "Create" task

			MockData
				.Setup(x => x.Get<Email>(It.IsAny<IWeaverQuery>(), It.IsAny<string>()))
				.Throws(new FabDuplicateFault("x"));

			var op = new CreateUserAccountOperation();
			CreateUserAccountOperation.Result result = op.Execute(MockOpCtx.Object, MockBuild.Object,
				MockTasks.Object, "a@b.c", "user", "pass");

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(CreateUserAccountOperation.ResultStatus.DuplicateUsername, result.Status,
				"Incorrect Status");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrUnexpected() {
			MockData
				.Setup(x => x.Get<Email>(It.IsAny<IWeaverQuery>(), It.IsAny<string>()))
				.Throws(new Exception("x"));

			var op = new CreateUserAccountOperation();
			CreateUserAccountOperation.Result result = op.Execute(MockOpCtx.Object, MockBuild.Object,
				MockTasks.Object, "a@b.c", "user", "pass");

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(CreateUserAccountOperation.ResultStatus.UnexpectedError, result.Status,
				"Incorrect Status");
		}

	}

}