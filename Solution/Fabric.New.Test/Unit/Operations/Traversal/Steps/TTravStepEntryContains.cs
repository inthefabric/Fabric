using System;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Traversal.Routing;
using Fabric.New.Operations.Traversal.Steps;
using Fabric.New.Test.Unit.Operations.Traversal.Routing;
using Moq;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Traversal.Steps {

	/*================================================================================================*/
	[TestFixture]
	public class TTravStepEntryContains : TTravStep {

		private string vPropDbName;
		private string vValue;
		private string vPropDbNameParam;
		private string vValueParam;
		private string vScript;
		private Type vToType;
		private TravStepEntryContains<FabTravArtifactRoot, FabArtifact> vStep;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public override void SetUp() {
			base.SetUp();

			vPropDbName = "my-db-name";
			vValue = "contains test";
			vPropDbNameParam = "_P0";
			vValueParam = "_P1";
			vScript = ".has("+vPropDbNameParam+", CONTAINS, "+vValueParam+")";
			vToType = typeof(FabArtifact);
			vStep = new TravStepEntryContains<FabTravArtifactRoot, FabArtifact>("cmd", vPropDbName);

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
		public void ErrorValueParamEmpty() {
			MockItem.Setup(x => x.GetParamAt<string>(0)).Returns("");
			var f = new FabStepFault(FabFault.Code.IncorrectParamValue, 0, "", "", 0);
			SetupFault(f, "empty");
			CheckConsumePathThrows(f);
		}

	}

}