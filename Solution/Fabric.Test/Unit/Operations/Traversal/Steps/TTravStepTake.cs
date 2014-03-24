using System;
using Fabric.Api.Objects;
using Fabric.Infrastructure.Faults;
using Fabric.Operations.Traversal.Routing;
using Fabric.Operations.Traversal.Steps;
using Fabric.Test.Unit.Operations.Traversal.Routing;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.Unit.Operations.Traversal.Steps {

	/*================================================================================================*/
	[TestFixture]
	public class TTravStepTake : TTravStep {

		private int vCount;
		private string vScript;
		private Type vToType;
		private TravStepTake<FabFactor, FabArtifact> vStep;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public override void SetUp() {
			base.SetUp();

			vCount = 92;
			vScript = "[0..91].inV";
			vToType = typeof(FabArtifact);
			vStep = new TravStepTake<FabFactor, FabArtifact>("cmd", true);

			MockItem.Setup(x => x.VerifyParamCount(1, -1));
			MockItem.Setup(x => x.GetParamAt<int>(0)).Returns(vCount);

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
			MockItem.Verify(x => x.VerifyParamCount(1, -1), Times.Once);
			MockPath.Verify(x => x.AddScript(vScript), t);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SuccessNotInVertex() {
			vScript = "[0..91]";
			MockPath.Setup(x => x.AddScript(vScript));

			vStep = new TravStepTake<FabFactor, FabArtifact>("cmd", false);

			vStep.ConsumePath(MockPath.Object, vToType);

			MockItem.Verify(x => x.VerifyParamCount(1, -1), Times.Once);
			MockPath.Verify(x => x.AddScript(vScript), Times.Once);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0, true)]
		[TestCase(101, false)]
		public void ErrorCountParamRange(int pCount, bool pLow) {
			MockItem.Setup(x => x.GetParamAt<int>(0)).Returns(pCount);
			var f = new FabStepFault(FabFault.Code.IncorrectParamValue, 0, "", "", 0);
			SetupFault(f, (pLow ? "less" : "greater")+" than");
			CheckConsumePathThrows(f);
		}

	}

}