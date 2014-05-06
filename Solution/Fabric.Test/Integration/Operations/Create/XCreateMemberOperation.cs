using Fabric.Api.Objects;
using Fabric.Database.Init.Setups;
using Fabric.Domain;
using Fabric.Domain.Enums;
using Fabric.Infrastructure.Faults;
using Fabric.Infrastructure.Query;
using Fabric.Operations.Create;
using Fabric.Test.Unit.Shared;
using NUnit.Framework;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.Test.Integration.Operations.Create {

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

			CheckNewVertex(result, VertexType.Id.Member);
			Assert.AreEqual(vCreateMember.Type, result.MemberType, "Incorrect MemberType.");
			Assert.AreEqual(null, result.OauthGrantCode, "Incorrect OauthGrantCode.");
			Assert.AreEqual(null, result.OauthGrantExpires, "Incorrect OauthGrantExpires.");
			Assert.AreEqual(null, result.OauthGrantRedirectUri, "Incorrect OauthGrantRedirectUri.");
			Assert.AreEqual(null, result.OauthScopeAllow, "Incorrect OauthScopeAllow.");

			IWeaverQuery verify = Weave.Inst.Graph
				.V.ExactIndex<Member>(x => x.VertexId, result.VertexId)
				.DefinedByApp.ToApp
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, vCreateMember.DefinedByAppId)
				.DefinesMembers
					.Has(x => x.UserId, WeaverStepHasOp.EqualTo, vCreateMember.DefinedByUserId)
					.Has(x => x.MemberType, WeaverStepHasOp.EqualTo, result.MemberType)
					.Has(x => x.Timestamp, WeaverStepHasOp.EqualTo, result.Timestamp)
				.ToMember
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, result.VertexId)
				.DefinedByUser.ToUser
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, vCreateMember.DefinedByUserId)
				.DefinesMembers
					.Has(x => x.AppId, WeaverStepHasOp.EqualTo, vCreateMember.DefinedByAppId)
					.Has(x => x.MemberType, WeaverStepHasOp.EqualTo, result.MemberType)
					.Has(x => x.Timestamp, WeaverStepHasOp.EqualTo, result.Timestamp)
				.ToMember
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, result.VertexId)
				.ToQuery();

			NewVertexCount = 1;
			NewEdgeCount = 4;
			SetNewElementQuery(verify);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrDuplicate() {
			IsReadOnlyTest = true;
			vCreateMember.DefinedByAppId = (long)SetupAppId.KinPhoGal;
			vCreateMember.DefinedByUserId = (long)SetupUserId.Zach;
			TestUtil.Throws<FabDuplicateFault>(() => ExecuteOperation());
		}

	}

}