﻿using Fabric.Api.Objects;
using Fabric.Domain;
using Fabric.Domain.Enums;
using Fabric.Infrastructure.Faults;
using Fabric.Infrastructure.Query;
using Fabric.Infrastructure.Util;
using Fabric.Operations.Create;
using Fabric.Test.Unit.Shared;
using Moq;
using NUnit.Framework;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.Test.Integration.Operations.Create {

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

			CheckNewVertex(result, VertexType.Id.User);
			Assert.AreEqual(vCreateUser.Name, result.Name, "Incorrect Name.");
			Assert.AreEqual(DataUtil.HashPassword(vCreateUser.Password), result.Password,
				"Incorrect Password.");

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