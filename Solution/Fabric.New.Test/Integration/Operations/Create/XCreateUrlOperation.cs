using Fabric.New.Api.Objects;
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
	public class XCreateUrlOperation : XCreateOperation<Url> {

		private CreateFabUrl vCreateUrl;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vCreateUrl = new CreateFabUrl();
			vCreateUrl.Name = "integration test";
			vCreateUrl.FullPath = "http://www.test.com";
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Url ExecuteOperation() {
			var op = new CreateUrlOperation();
			return op.Execute(OpCtx, Build, Tasks, vCreateUrl);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			Url result = ExecuteOperation();

			CheckNewVertex(result, VertexType.Id.Url);
			Assert.AreEqual(vCreateUrl.Name, result.Name, "Incorrect Name.");
			Assert.AreEqual(vCreateUrl.FullPath, result.FullPath, "Incorrect FullPath.");

			IWeaverQuery verify = Weave.Inst.Graph
				.V.ExactIndex<Url>(x => x.VertexId, result.VertexId)
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
			vCreateUrl.FullPath = "http://zachKINSTNER.com";
			TestUtil.Throws<FabDuplicateFault>(() => ExecuteOperation());
		}

	}

}