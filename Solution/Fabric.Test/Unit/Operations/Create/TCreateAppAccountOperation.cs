using System;
using System.Collections.Generic;
using Fabric.Api.Objects;
using Fabric.Domain;
using Fabric.Infrastructure.Faults;
using Fabric.Operations.Create;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.Unit.Operations.Create {

	/*================================================================================================*/
	[TestFixture]
	public class TCreateAppAccountOperation : TCreateCustomOperation {

		private long vNewAppId;
		private long vNewMemId;
		private string vAppCmd;
		private string vMemCmd;
		private Queue<long> vSharpflakeQueue;
		private Queue<string> vCmdIdQueue;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetUp() {
			base.SetUp();

			vNewAppId = 685239856293;
			vNewMemId = 123235332;
			vAppCmd = "appCmd";
			vMemCmd = "memCmd";
			vSharpflakeQueue = new Queue<long>(new[] { vNewAppId, vNewMemId });

			MockOpCtx.Setup(x => x.GetSharpflakeId<Vertex>()).Returns(vSharpflakeQueue.Dequeue);
			MockOpCtx.SetupGet(x => x.UtcNow).Returns(new DateTime(9999999999));
			MockOpCtx.SetupGet(x => x.Code32).Returns("123456789012345678901234567890ab");

			vCmdIdQueue = new Queue<string>(new[] { vAppCmd, vMemCmd });
			MockAcc.Setup(x => x.GetLatestCommandId()).Returns(vCmdIdQueue.Dequeue);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Execute() {
			const string name = "Test App";
			const long creatorMemId = 123523532;
			const long userId = 12316232336666;

			ICreateOperationBuilder build = MockBuild.Object;
			CreateOperationTasks tasks = MockTasks.Object;

			var expectApp = new App();
			var expectMem = new Member();

			IWeaverVarAlias<App> appAlias = new WeaverVarAlias<App>("appAlias");
			IWeaverVarAlias<Member> memAlias = new WeaverVarAlias<Member>("memAlias");

			MockBuild
				.Setup(x => x.StartSession())
				.Callback(CheckCallIndex("StartSession"));

			//// Add App

			MockTasks
				.Setup(x => x.FindDuplicateAppNameKey(build, ItIsVert<App>(vNewAppId)))
				.Callback(CheckCallIndex("FindDuplicateAppNameKey"));

			int addAppIndex = CallsAdded;

			MockTasks
				.Setup(x => x.AddApp(build, ItIsVert<App>(vNewAppId), out appAlias))
				.Callback(CheckCallIndex("AddApp"));

			//// Add Member


			MockTasks
				.Setup(x => x.FindDuplicateMember(build, userId, vNewAppId))
				.Callback(CheckCallIndex("FindDuplicateMember"));

			int addMemIndex = CallsAdded;

			MockTasks
				.Setup(x => x.AddMember(build, ItIsVert<Member>(vNewMemId), out memAlias))
				.Callback(CheckCallIndex("AddMember"));

			//// Add App edges

			MockTasks
				.Setup(x => x.AddArtifactCreatedByMember(
					build,
					ItIsVert<App>(vNewAppId),
					It.Is<CreateFabApp>(c => c.CreatedByMemberId == creatorMemId),
					It.Is<IWeaverVarAlias<Artifact>>(a => a.Name == appAlias.Name)
				))
				.Callback(CheckCallIndex("AddArtifactCreatedByMember"));

			//// Add Member edges

			MockTasks
				.Setup(x => x.AddMemberDefinedByApp(
					build,
					ItIsVert<Member>(vNewMemId),
					It.Is<CreateFabMember>(c => c.DefinedByAppId == vNewAppId),
					It.Is<IWeaverVarAlias<Member>>(a => a.Name == memAlias.Name)
				))
				.Callback(CheckCallIndex("AddMemberDefinedByApp"));

			MockTasks
				.Setup(x => x.AddMemberDefinedByUser(
					build,
					ItIsVert<Member>(vNewMemId),
					It.Is<CreateFabMember>(c => c.DefinedByUserId == userId),
					It.Is<IWeaverVarAlias<Member>>(a => a.Name == memAlias.Name)
				))
				.Callback(CheckCallIndex("AddMemberDefinedByUser"));
			
			//// Finish setup
			
			MockBuild
				.Setup(x => x.CommitAndCloseSession())
				.Callback(CheckCallIndex("CommitAndCloseSession"));

			MockAcc.Setup(x => x.Execute(typeof(CreateAppAccountOperation).Name))
				.Returns(MockRes.Object);

			MockRes.Setup(x => x.GetCommandIndexByCmdId(vAppCmd)).Returns(addAppIndex);
			MockRes.Setup(x => x.GetCommandIndexByCmdId(vMemCmd)).Returns(addMemIndex);

			MockRes.Setup(x => x.ToElementAt<App>(addAppIndex, 0)).Returns(expectApp);
			MockRes.Setup(x => x.ToElementAt<Member>(addMemIndex, 0)).Returns(expectMem);

			//// Execute

			var op = new CreateAppAccountOperation();
			CreateAppAccountOperation.Result result = op.Execute(MockOpCtx.Object, build, tasks, 
				name, creatorMemId, userId);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(CreateAppAccountOperation.ResultStatus.Success, result.Status,
				"Incorrect Status");
			Assert.AreEqual(expectApp, result.NewApp, "Incorrect NewApp.");
			Assert.AreEqual(expectMem, result.NewMember, "Incorrect NewMember.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrDuplicateUser() {
			//Note: the fault would actually come from a "Create" task
			MockOpCtx.Setup(x => x.GetSharpflakeId<Vertex>()).Throws(new FabDuplicateFault("x"));

			var op = new CreateAppAccountOperation();
			CreateAppAccountOperation.Result result = op.Execute(MockOpCtx.Object, MockBuild.Object,
				MockTasks.Object, "name", 1234, 3245);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(CreateAppAccountOperation.ResultStatus.DuplicateAppName, result.Status,
				"Incorrect Status");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrUnexpected() {
			MockOpCtx.Setup(x => x.GetSharpflakeId<Vertex>()).Throws(new Exception("x"));

			var op = new CreateAppAccountOperation();
			CreateAppAccountOperation.Result result = op.Execute(MockOpCtx.Object, MockBuild.Object,
				MockTasks.Object, "name", 1234, 3245);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(CreateAppAccountOperation.ResultStatus.UnexpectedError, result.Status,
				"Incorrect Status");
		}

	}

}