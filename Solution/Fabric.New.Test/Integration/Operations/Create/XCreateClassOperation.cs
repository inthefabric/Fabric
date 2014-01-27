using Fabric.New.Api.Objects;
using Fabric.New.Domain;
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
	public class XCreateClassOperation : XCreateOperation<Class> {

		private CreateFabClass vCreateClass;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vCreateClass = new CreateFabClass();
			vCreateClass.Name = "integration test";
			vCreateClass.Disamb = "a new class";
			vCreateClass.Note = "creating a class";
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Class ExecuteOperation() {
			var op = new CreateClassOperation();
			return op.Execute(OpCtx, Build, Tasks, vCreateClass);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("test", "new class")]
		[TestCase("null test", null)]
		[TestCase("Human", "NOT NULL")]
		public void Success(string pName, string pDisamb) {
			vCreateClass.Name = pName;
			vCreateClass.Disamb = pDisamb;

			Class result = ExecuteOperation();

			Assert.AreNotEqual(0, result.Id, "Incorrect Id.");
			Assert.AreNotEqual(0, result.VertexType, "Incorrect VertexType.");
			Assert.AreNotEqual(0, result.Timestamp, "Incorrect Timestamp.");
			Assert.AreEqual(vCreateClass.Name, result.Name, "Incorrect Name.");
			Assert.AreEqual(vCreateClass.Disamb, result.Disamb, "Incorrect Disamb.");
			Assert.AreEqual(vCreateClass.Note, result.Note, "Incorrect Note.");

			IWeaverQuery verify = Weave.Inst.Graph
				.V.ExactIndex<Class>(x => x.VertexId, result.VertexId)
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
			vCreateClass.Name = "Human";
			vCreateClass.Disamb = null;
			TestUtil.Throws<FabDuplicateFault>(() => ExecuteOperation());
		}

	}

}