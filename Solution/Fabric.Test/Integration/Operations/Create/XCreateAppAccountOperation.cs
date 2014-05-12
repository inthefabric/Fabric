using System;
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
	public class XCreateAppAccountOperation : IntegrationTest {

		private CreateOperationBuilder vBuild;
		private CreateOperationTasks vTasks;

		private string vName;
		private long vCreatorMemberId;
		private long vUserId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vBuild = new CreateOperationBuilder();
			vTasks = new CreateOperationTasks();

			vName = "Test App";
			vCreatorMemberId = (long)SetupMemberId.FabZach;
			vUserId = (long)SetupUserId.Zach;
		}

		/*--------------------------------------------------------------------------------------------*/
		private CreateAppAccountOperation.Result ExecuteOperation() {
			var op = new CreateAppAccountOperation();
			return op.Execute(OpCtx, vBuild, vTasks, vName, vCreatorMemberId, vUserId);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			CreateAppAccountOperation.Result result = ExecuteOperation();

			Assert.AreEqual(CreateAppAccountOperation.ResultStatus.Success, result.Status, 
				"Incorrect Status.");

			XCreateOperation.CheckNewVertex(result.NewApp, VertexType.Id.App);
			XCreateOperation.CheckNewVertex(result.NewMember, VertexType.Id.Member);

			Assert.AreEqual(vName, result.NewApp.Name, "Incorrect NewApp.Name.");
			Assert.AreEqual((byte)MemberType.Id.DataProv, result.NewMember.MemberType, 
				"Incorrect NewMember.MemberType.");

			NewVertexCount = 2;
			NewEdgeCount = 6;

			const WeaverStepHasOp eq = WeaverStepHasOp.EqualTo;
			IWeaverStepAs<App> appAlias;
			IWeaverStepAs<Member> memAlias;
			IWeaverStepAs<Member> creMemAlias;
			IWeaverStepAs<User> userAlias;

			//Confirm new App and two edges
			IWeaverQuery verifyApp = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.VertexId, result.NewApp.VertexId)
				.As(out appAlias)
				.DefinesMembers
					.Has(x => x.UserId, eq, vUserId)
					.Has(x => x.MemberType, eq, (byte)MemberType.Id.DataProv)
					.Has(x => x.Timestamp, eq, result.NewMember.Timestamp)
				.ToMember
					.Has(x => x.VertexId, eq, result.NewMember.VertexId)
				.Back(appAlias)
				.CreatedByMember.ToMember
					.Has(x => x.VertexId, eq, vCreatorMemberId)
				.Back(appAlias)
				.ToQuery();

			//Confirm new Member and two edges
			IWeaverQuery verifyMem = Weave.Inst.Graph
				.V.ExactIndex<Member>(x => x.VertexId, result.NewMember.VertexId)
				.As(out memAlias)
				.DefinedByApp.ToApp
					.Has(x => x.VertexId, eq, result.NewApp.VertexId)
				.Back(memAlias)
				.DefinedByUser.ToUser
					.Has(x => x.VertexId, eq, vUserId)
				.Back(memAlias)
				.ToQuery();

			//Confirm creator Member and one new edge
			IWeaverQuery verifyCreatorMem = Weave.Inst.Graph
				.V.ExactIndex<Member>(x => x.VertexId, vCreatorMemberId)
				.As(out creMemAlias)
				.CreatesArtifacts
					.Has(x => x.VertexType, eq, (byte)VertexType.Id.App)
					.Has(x => x.Timestamp, eq, result.NewApp.Timestamp)
				.ToArtifact
					.Has(x => x.VertexId, eq, result.NewApp.VertexId)
				.Back(creMemAlias)
				.ToQuery();

			//Confirm new Member's User and one new edge
			IWeaverQuery verifyDataProvUser = Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.VertexId, vUserId)
				.As(out userAlias)
				.DefinesMembers
					.Has(x => x.AppId, eq, result.NewApp.VertexId)
					.Has(x => x.MemberType, eq, (byte)MemberType.Id.DataProv)
					.Has(x => x.Timestamp, eq, result.NewMember.Timestamp)
				.ToMember
					.Has(x => x.VertexId, eq, result.NewMember.VertexId)
				.Back(userAlias)
				.ToQuery();

			VerificationQueryFunc = () => {
				IDataResult dr = OpCtx.ExecuteForTest(verifyApp, "CreateAppAccountOperation-VerifyA");
				Assert.AreEqual(1, dr.GetCommandResultCount(), "New App not verified.");

				dr = OpCtx.ExecuteForTest(verifyMem, "CreateAppAccountOperation-VerifyM");
				Assert.AreEqual(1, dr.GetCommandResultCount(), "New Member not verified.");

				dr = OpCtx.ExecuteForTest(verifyCreatorMem, "CreateAppAccountOperation-VerifyCM");
				Assert.AreEqual(1, dr.GetCommandResultCount(), "Creator Member not verified.");

				dr = OpCtx.ExecuteForTest(verifyDataProvUser, "CreateAppAccountOperation-VerifyDPU");
				Assert.AreEqual(1, dr.GetCommandResultCount(), "DataProv User not verified.");
			};
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrDuplicate() {
			IsReadOnlyTest = true;
			vName = "Fabric SYSTEM";
			
			CreateAppAccountOperation.Result result = ExecuteOperation();

			Assert.AreEqual(CreateAppAccountOperation.ResultStatus.DuplicateAppName, result.Status, 
				"Incorrect Status.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(1)]
		[TestCase(2)]
		public void ErrNotFound(int pType) {
			IsReadOnlyTest = true;

			if ( pType == 1 ) {
				vCreatorMemberId = 999;
			}
			else {
				vUserId = 999;
			}

			CreateAppAccountOperation.Result result = ExecuteOperation();

			Assert.AreEqual(CreateAppAccountOperation.ResultStatus.NotFoundMemberOrUser, result.Status,
				"Incorrect Status.");
		}

	}

}