using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Infrastructure.Query;
using Fabric.New.Operations.Create;
using NUnit.Framework;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;

namespace Fabric.New.Test.Integration.Operations.Create {

	/*================================================================================================*/
	public class XCreateInstanceOperation : XCreateOperation<Instance> {

		private CreateFabInstance vCreateInstance;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vCreateInstance = new CreateFabInstance();
			vCreateInstance.Name = "integration test";
			vCreateInstance.Disamb = "a new class";
			vCreateInstance.Note = "creating a class";
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Instance ExecuteOperation() {
			var op = new CreateInstanceOperation();
			return op.Execute(OpCtx, Build, Tasks, vCreateInstance);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Instance result = ExecuteOperation();

			CheckNewVertex(result, VertexType.Id.Instance);
			Assert.AreEqual(vCreateInstance.Name, result.Name, "Incorrect Name.");
			Assert.AreEqual(vCreateInstance.Disamb, result.Disamb, "Incorrect Disamb.");
			Assert.AreEqual(vCreateInstance.Note, result.Note, "Incorrect Note.");

			IWeaverQuery verify = Weave.Inst.Graph
				.V.ExactIndex<Instance>(x => x.VertexId, result.VertexId)
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

	}

}