using System;
using Fabric.New.Api.Objects;
using Fabric.New.Operations.Traversal.Routing;
using Fabric.New.Operations.Traversal.Steps;
using Fabric.New.Test.Unit.Operations.Traversal.Routing;
using Moq;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Traversal.Steps {

	/*================================================================================================*/
	[TestFixture]
	public class TTravStepLink : TTravStep {

		private string vEdgeDbName;
		private string vEdgeDbNameParam;
		private string vScript;
		private Type vToType;
		private TravStepLink<FabFactor, FabArtifact> vStep;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public override void SetUp() {
			base.SetUp();

			vEdgeDbName = "edge-name";
			vEdgeDbNameParam = "_P0";
			vScript = ".outE("+vEdgeDbNameParam+").inV";
			vToType = typeof(FabArtifact);
			vStep = new TravStepLink<FabFactor, FabArtifact>("cmd", vEdgeDbName, true);

			MockItem.Setup(x => x.VerifyParamCount(0, -1));

			MockPath.Setup(x => x.AddParam(vEdgeDbName)).Returns(vEdgeDbNameParam);
			MockPath.Setup(x => x.AddScript(vScript));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override ITravStep GetStep() {
			return vStep;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Type GetToType() {
			return vToType;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void CheckSuccess(bool pSuccess) {
			Times t = (pSuccess ? Times.Once() : Times.Never());

			MockItem.Verify(x => x.VerifyParamCount(0, -1), Times.Once);

			MockPath.Verify(x => x.AddParam(vEdgeDbName), t);
			MockPath.Verify(x => x.AddScript(vScript), t);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SuccessNotInVertex() {
			vScript = ".outE("+vEdgeDbNameParam+")";
			MockPath.Setup(x => x.AddScript(vScript));

			vStep = new TravStepLink<FabFactor, FabArtifact>("cmd", vEdgeDbName, false);

			vStep.ConsumePath(MockPath.Object, vToType);

			MockItem.Verify(x => x.VerifyParamCount(0, -1), Times.Once);

			MockPath.Verify(x => x.AddParam(vEdgeDbName), Times.Once);
			MockPath.Verify(x => x.AddScript(vScript), Times.Once);
		}

	}

}