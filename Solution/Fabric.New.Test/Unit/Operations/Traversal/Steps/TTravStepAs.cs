﻿using System;
using Fabric.New.Api.Objects;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Traversal.Routing;
using Fabric.New.Operations.Traversal.Steps;
using Fabric.New.Test.Unit.Operations.Traversal.Routing;
using Moq;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Traversal.Steps {

	/*================================================================================================*/
	[TestFixture]
	public class TTravStepAs : TTravStep {

		private string vAlias;
		private string vAliasParam;
		private string vScript;
		private Type vToType;
		private TravStepAs vStep;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public override void SetUp() {
			base.SetUp();

			vAlias = "test";
			vAliasParam = "_P0";
			vScript = ".as("+vAliasParam+")";
			vToType = typeof(FabFactor);

			MockItem.Setup(x => x.VerifyParamCount(1, -1));
			MockItem.Setup(x => x.GetParamAt<string>(0)).Returns(vAlias);

			MockPath.Setup(x => x.HasAlias(vAlias)).Returns(false);
			MockPath.Setup(x => x.AddAlias(vAlias));
			MockPath.Setup(x => x.AddParam(vAlias)).Returns(vAliasParam);
			MockPath.Setup(x => x.AddScript(vScript));

			vStep = new TravStepAs();
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

			MockPath.Verify(x => x.AddAlias(vAlias), t);
			MockPath.Verify(x => x.AddParam(vAlias), t);
			MockPath.Verify(x => x.AddScript(vScript), t);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrorDuplicateAlias() {
			var f = new FabStepFault(FabFault.Code.IncorrectParamValue, 0, "", "", 0);
			MockPath.Setup(x => x.HasAlias(vAlias)).Returns(true);
			SetupFault(f, "in use");
			CheckConsumePathThrows(f);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrorAliasParamEmpty() {
			var f = new FabStepFault(FabFault.Code.IncorrectParamValue, 0, "", "", 0);
			MockItem.Setup(x => x.GetParamAt<string>(0)).Returns("");
			SetupFault(f, "empty");
			CheckConsumePathThrows(f);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrorAliasParamLength() {
			var f = new FabStepFault(FabFault.Code.IncorrectParamValue, 0, "", "", 0);
			MockItem.Setup(x => x.GetParamAt<string>(0)).Returns("abcdefghi");
			SetupFault(f, "cannot exceed");
			CheckConsumePathThrows(f);
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrorAliasParamFormat() {
			var f = new FabStepFault(FabFault.Code.IncorrectParamValue, 0, "", "", 0);
			MockItem.Setup(x => x.GetParamAt<string>(0)).Returns("badAL!A$");
			SetupFault(f, "format");
			CheckConsumePathThrows(f);
		}

	}

}