using Fabric.New.Api.Objects;
using Fabric.New.Database.Init.Setups;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Query;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Unit.Shared;
using NUnit.Framework;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.New.Test.Integration.Operations.Create {

	/*================================================================================================*/
	public class XCreateMemberOperation : XCreateOperation<Member> {

		private CreateFabMember vCreateMember;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vCreateMember = new CreateFabMember();
			vCreateMember.DefinedByAppId = (long)SetupAppId.Bookmarker;
			vCreateMember.DefinedByUserId = (long)SetupUserId.FabData;
			vCreateMember.Type = (byte)MemberType.Id.Invite;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Member ExecuteOperation() {
			var op = new CreateMemberOperation();
			return op.Execute(OpCtx, Build, Tasks, vCreateMember);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Member result = ExecuteOperation();

			Assert.AreNotEqual(0, result.Id, "Incorrect Id.");
			Assert.AreNotEqual(0, result.VertexType, "Incorrect VertexType.");
			Assert.AreNotEqual(0, result.Timestamp, "Incorrect Timestamp.");
			Assert.AreEqual(vCreateMember.Type, result.MemberType, "Incorrect MemberType.");
			Assert.AreEqual(null, result.OauthGrantCode, "Incorrect OauthGrantCode.");
			Assert.AreEqual(null, result.OauthGrantExpires, "Incorrect OauthGrantExpires.");
			Assert.AreEqual(null, result.OauthGrantRedirectUri, "Incorrect OauthGrantRedirectUri.");
			Assert.AreEqual(null, result.OauthScopeAllow, "Incorrect OauthScopeAllow.");

			IWeaverQuery verify = Weave.Inst.Graph
				.V.ExactIndex<Member>(x => x.VertexId, result.VertexId)
				.DefinedByApp.ToApp
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, vCreateMember.DefinedByAppId)
				.DefinesMembers.ToMember
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, result.VertexId)
				.DefinedByUser.ToUser
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, vCreateMember.DefinedByUserId)
				.DefinesMembers.ToMember
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, result.VertexId)
				.ToQuery();

			NewVertexCount = 1;
			NewEdgeCount = 4;
			SetNewElementQuery(verify);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrDuplicate() {
			vCreateMember.DefinedByAppId = (long)SetupAppId.KinPhoGal;
			vCreateMember.DefinedByUserId = (long)SetupUserId.Zach;
			TestUtil.Throws<FabDuplicateFault>(() => ExecuteOperation());
		}

	}

}