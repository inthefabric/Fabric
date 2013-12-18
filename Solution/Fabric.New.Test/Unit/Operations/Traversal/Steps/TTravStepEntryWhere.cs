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
	public class TTravStepEntryWhere : TTravStep {

		private string vPropDbName;
		private string vOperation;
		private long vValue;
		private string vPropDbNameParam;
		private string vValueParam;
		private string vScript;
		private Type vToType;
		private TravStepEntryWhere<FabTravArtifactRoot, long, FabArtifact> vStep;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public override void SetUp() {
			base.SetUp();

			vPropDbName = "my-db-name";
			vOperation = "lte";
			vValue = 987654;
			vPropDbNameParam = "_P0";
			vValueParam = "_P1";
			vScript = ".has("+vPropDbNameParam+", LESS_THAN_EQUAL, "+vValueParam+")";
			vToType = typeof(FabArtifact);
			vStep = new TravStepEntryWhere<FabTravArtifactRoot, long, FabArtifact>("cmd", vPropDbName);

			MockItem.Setup(x => x.VerifyParamCount(2, -1));
			MockItem.Setup(x => x.GetParamAt<string>(0)).Returns(vOperation);
			MockItem.Setup(x => x.GetParamAt<long>(1)).Returns(vValue);

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

			MockItem.Verify(x => x.VerifyParamCount(2, -1), Times.Once);

			MockPath.Verify(x => x.AddParam(vPropDbName), t);
			MockPath.Verify(x => x.AddParam(vValue), t);
			MockPath.Verify(x => x.AddScript(vScript), t);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("eq", "EQUAL")]
		[TestCase("gt", "GREATER_THAN")]
		public void SucessOperations(string pOperation, string pGremlin) {
			vOperation = pOperation;
			vScript = ".has("+vPropDbNameParam+", "+pGremlin+", "+vValueParam+")";

			MockItem.Setup(x => x.GetParamAt<string>(0)).Returns(vOperation);
			MockPath.Setup(x => x.AddScript(vScript));

			vStep.ConsumePath(MockPath.Object, GetToType());
			CheckSuccess(true);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrorOperationParamEmpty() {
			MockItem.Setup(x => x.GetParamAt<string>(0)).Returns("");
			var f = new FabStepFault(FabFault.Code.IncorrectParamValue, 0, "", "", 0);
			SetupFault(f, "empty");
			CheckConsumePathThrows(f);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrorOperationParamAccepted() {
			MockItem.Setup(x => x.GetParamAt<string>(0)).Returns("fake");
			var f = new FabStepFault(FabFault.Code.IncorrectParamValue, 0, "", "", 0);
			SetupFault(f, "Accepted values");
			CheckConsumePathThrows(f);
		}

	}

}