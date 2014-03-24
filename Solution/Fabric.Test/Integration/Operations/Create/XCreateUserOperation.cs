using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Query;
using Fabric.New.Infrastructure.Util;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.New.Test.Integration.Operations.Create {

	/*================================================================================================*/
	public class XCreateUserOperation : XCreateOperation<User> {

		private CreateFabUser vCreateUser;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vMockAuth.Setup(x => x.SetNewUserMember(It.IsAny<long>()));

			vCreateUser = new CreateFabUser();
			vCreateUser.Name = "myUsername";
			vCreateUser.Password = "myPassword";
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override User ExecuteOperation() {
			var op = new CreateUserOperation();
			return op.Execute(OpCtx, Build, Tasks, vCreateUser);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			User result = ExecuteOperation();

			CheckNewVertex(result, VertexType.Id.User);
			Assert.AreEqual(vCreateUser.Name, result.Name, "Incorrect Name.");
			Assert.AreEqual(DataUtil.HashPassword(vCreateUser.Password), result.Password,
				"Incorrect Password.");

			vMockAuth.Verify(x => x.SetNewUserMember(result.VertexId), Times.Once);

			IWeaverQuery verify = Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.VertexId, result.VertexId)
				.CreatedByMember.ToMember
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, CreatorId)
				.CreatesArtifacts
					.Has(x => x.VertexType, WeaverStepHasOp.EqualTo, result.VertexType)
					.Has(x => x.Timestamp, WeaverStepHasOp.EqualTo, result.Timestamp)
				.ToArtifact
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, result.VertexId)
				.ToQuery();

			NewVertexCount = 1;
			NewEdgeCount = 2;
			SetNewElementQuery(verify);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrDuplicate() {
			IsReadOnlyTest = true;
			vCreateUser.Name = "zachKINSTNER";
			TestUtil.Throws<FabDuplicateFault>(() => ExecuteOperation());
		}

	}

}