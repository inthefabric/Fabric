using Fabric.Api.Objects;
using Fabric.Database.Init.Setups;
using Fabric.Domain;
using Fabric.Domain.Enums;
using Fabric.Infrastructure.Query;
using Fabric.Operations.Create;
using NUnit.Framework;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.Test.Integration.Operations.Create {

	/*================================================================================================*/
	public class XCreateEmailOperation : XCreateOperation<Email> {

		private CreateFabEmail vCreateEmail;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vCreateEmail = new CreateFabEmail();
			vCreateEmail.Address = "my@email.com";
			vCreateEmail.Code = "12345678901234567890123456789012";
			vCreateEmail.UsedByArtifactId = (long)SetupUserId.Zach;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Email ExecuteOperation() {
			var op = new CreateEmailOperation();
			return op.Execute(OpCtx, Build, Tasks, vCreateEmail);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Email result = ExecuteOperation();

			CheckNewVertex(result, VertexType.Id.Email);
			Assert.AreEqual(vCreateEmail.Address, result.Address, "Incorrect Address.");
			Assert.AreEqual(vCreateEmail.Code, result.Code, "Incorrect Code.");

			IWeaverQuery verify = Weave.Inst.Graph
				.V.ExactIndex<Email>(x => x.VertexId, result.VertexId)
				.UsedByArtifact.ToArtifact
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, vCreateEmail.UsedByArtifactId)
				.UsesEmails.ToEmail
					.Has(x => x.VertexId, WeaverStepHasOp.EqualTo, result.VertexId)
				.ToQuery();

			NewVertexCount = 1;
			NewEdgeCount = 2;
			SetNewElementQuery(verify);
		}

	}

}