using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Query;
using Fabric.New.Infrastructure.Util;
using Fabric.New.Operations.Create;
using Fabric.New.Test.Unit.Shared;
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

			Assert.AreNotEqual(0, result.Id, "Incorrect Id.");
			Assert.AreNotEqual(0, result.VertexType, "Incorrect VertexType.");
			Assert.AreNotEqual(0, result.Timestamp, "Incorrect Timestamp.");
			Assert.AreEqual(vCreateUser.Name, result.Name, "Incorrect Name.");
			Assert.AreEqual(DataUtil.HashPassword(vCreateUser.Password), result.Password,
				"Incorrect Password.");

			IWeaverQuery verify = Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.VertexId, result.VertexId)
				.CreatedByMember.ToMember
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, CreatorId)
				.CreatesArtifacts.ToArtifact
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, result.VertexId)
				.ToQuery();

			NewVertexCount = 1;
			NewEdgeCount = 2;
			SetNewElementQuery(verify);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrDuplicate() {
			vCreateUser.Name = "zachKINSTNER";
			TestUtil.Throws<FabDuplicateFault>(() => ExecuteOperation());
		}

	}

}