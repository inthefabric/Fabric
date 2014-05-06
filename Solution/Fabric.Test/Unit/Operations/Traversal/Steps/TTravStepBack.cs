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
	public class TTravStepBack : TTravStep {

		private string vAlias;
		private string vAliasParam;
		private string vScript;
		private Type vToType;
		private TravStepBack vStep;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public override void SetUp() {
			base.SetUp();

			vAlias = "test";
			vAliasParam = "_P0";
			vScript = ".back("+vAliasParam+")";
			vToType = typeof(FabFactor);
			vStep = new TravStepBack();

			string confAlias;

			MockItem.Setup(x => x.VerifyParamCount(1, -1));
			MockItem.Setup(x => x.GetParamAt<string>(0)).Returns(vAlias);

			MockPath.Setup(x => x.ConsumeSteps(1, typeof(FabElement))).Returns(Items);
			MockPath.Setup(x => x.HasAlias(vAlias)).Returns(true);
			MockPath.Setup(x => x.DoesBackTouchAs(vAlias)).Returns(false);
			MockPath.Setup(x => x.AllowBackToAlias(vAlias, out confAlias)).Returns(true);
			MockPath.Setup(x => x.AddBackToAlias(vAlias));
			MockPath.Setup(x => x.AddParam(vAlias)).Returns(vAliasParam);
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

			MockPath.Verify(x => x.AddBackToAlias(vAlias), t);
			MockPath.Verify(x => x.AddParam(vAlias), t);
			MockPath.Verify(x => x.AddScript(vScript), t);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrorAliasParamEmpty() {
			MockItem.Setup(x => x.GetParamAt<string>(0)).Returns("");
			var f = new FabStepFault(FabFault.Code.IncorrectParamValue, 0, "", "", 0);
			SetupFault(f, "empty");
			CheckConsumePathThrows(f);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrorAliasParamLength() {
			MockItem.Setup(x => x.GetParamAt<string>(0)).Returns("abcdefghi");
			var f = new FabStepFault(FabFault.Code.IncorrectParamValue, 0, "", "", 0);
			SetupFault(f, "cannot exceed");
			CheckConsumePathThrows(f);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrorAliasParamFormat() {
			MockItem.Setup(x => x.GetParamAt<string>(0)).Returns("badAL!A$");
			var f = new FabStepFault(FabFault.Code.IncorrectParamValue, 0, "", "", 0);
			SetupFault(f, "format");
			CheckConsumePathThrows(f);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrorAliasNotFound() {
			MockPath.Setup(x => x.HasAlias(vAlias)).Returns(false);
			var f = new FabStepFault(FabFault.Code.IncorrectParamValue, 0, "", "", 0);
			SetupFault(f, "not be found");
			CheckConsumePathThrows(f);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrorDirectlyAfterAs() {
			MockPath.Setup(x => x.DoesBackTouchAs(vAlias)).Returns(true);
			var f = new FabStepFault(FabFault.Code.InvalidStep, 0, "", "", 0);
			SetupFault(f, "directly after");
			CheckConsumePathThrows(f);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrorNotAllowed() {
			string confAlias;

			MockPath.Setup(x => x.AllowBackToAlias(vAlias, out confAlias)).Returns(false);
			var f = new FabStepFault(FabFault.Code.InvalidStep, 0, "", "", 0);
			SetupFault(f, "Cannot traverse");
			CheckConsumePathThrows(f);
		}

	}

}