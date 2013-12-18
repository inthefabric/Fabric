using System;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Operations.Traversal.Routing;
using Fabric.New.Operations.Traversal.Steps;
using Fabric.New.Test.Unit.Operations.Traversal.Routing;
using Moq;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Traversal.Steps {

	/*================================================================================================*/
	[TestFixture]
	public class TTravStepEntryWith : TTravStep {

		private string vPropDbName;
		private string vValue;
		private string vPropDbNameParam;
		private string vValueParam;
		private string vScript;
		private Type vToType;
		private TravStepEntryWith<FabTravArtifactRoot, string, FabArtifact> vStep;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public override void SetUp() {
			base.SetUp();

			vPropDbName = "my-db-name";
			vValue = "My Test Value";
			vPropDbNameParam = "_P0";
			vValueParam = "_P1";
			vScript = ".has("+vPropDbNameParam+", EQUAL, "+vValueParam+")";
			vToType = typeof(FabArtifact);
			vStep = new TravStepEntryWith<FabTravArtifactRoot, string, FabArtifact>(
				"cmd", vPropDbName, false);

			MockItem.Setup(x => x.VerifyParamCount(1, -1));
			MockItem.Setup(x => x.GetParamAt<string>(0)).Returns(vValue);

			MockPath.Setup(x => x.AddParam(vPropDbName)).Returns(vPropDbNameParam);
			MockPath.Setup(x => x.AddParam(vValue)).Returns(vValueParam);
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

			MockPath.Verify(x => x.AddParam(vPropDbName), t);
			MockPath.Verify(x => x.AddParam(vValue), t);
			MockPath.Verify(x => x.AddScript(vScript), t);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SuccessToLower() {
			vStep = new TravStepEntryWith<FabTravArtifactRoot, string, FabArtifact>(
				"cmd", vPropDbName, true);

			MockPath.Setup(x => x.AddParam(vValue.ToLower())).Returns(vValueParam);

			vStep.ConsumePath(MockPath.Object, GetToType());

			MockPath.Verify(x => x.AddParam(vValue), Times.Never());
			MockPath.Verify(x => x.AddParam(vValue.ToLower()), Times.Once());
		}

	}

}