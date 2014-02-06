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
	public class XCreateAppOperation : XCreateOperation<App> {

		private CreateFabApp vCreateApp;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();

			vCreateApp = new CreateFabApp();
			vCreateApp.Name = "new app";
			vCreateApp.Secret = "12345678901234567890123456789012";
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override App ExecuteOperation() {
			var op = new CreateAppOperation();
			return op.Execute(OpCtx, Build, Tasks, vCreateApp);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			App result = ExecuteOperation();

			Assert.AreNotEqual(0, result.Id, "Incorrect Id.");
			Assert.AreNotEqual(0, result.VertexType, "Incorrect VertexType.");
			Assert.AreNotEqual(0, result.Timestamp, "Incorrect Timestamp.");
			Assert.AreEqual(vCreateApp.Name, result.Name, "Incorrect Name.");

			IWeaverQuery verify = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.VertexId, result.VertexId)
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
			vCreateApp.Name = "Fabric SYSTEM";
			TestUtil.Throws<FabDuplicateFault>(() => ExecuteOperation());
		}

	}

}