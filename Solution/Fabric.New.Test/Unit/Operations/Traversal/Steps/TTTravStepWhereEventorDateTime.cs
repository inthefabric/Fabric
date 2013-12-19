using System;
using Fabric.New.Api.Objects;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Infrastructure.Util;
using Fabric.New.Operations.Traversal.Routing;
using Fabric.New.Operations.Traversal.Steps;
using Fabric.New.Test.Unit.Operations.Traversal.Routing;
using Moq;
using NUnit.Framework;

namespace Fabric.New.Test.Unit.Operations.Traversal.Steps {

	/*================================================================================================*/
	[TestFixture]
	public class TTravStepWhereEventorDateTime : TTravStep {

		private string vPropDbName;
		private string vOperation;
		private long vYear;
		private byte vMonth;
		private byte vDay;
		private byte vHour;
		private byte vMinute;
		private byte vSecond;
		private long vValue;
		private string vPropDbNameParam;
		private string vValueParam;
		private string vScript;
		private Type vToType;
		private TravStepWhereEventorDateTime vStep;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public override void SetUp() {
			base.SetUp();

			vPropDbName = DbName.Vert.Factor.EventorDateTime;
			vOperation = "lte";
			vYear = 2000;
			vMonth = 1;
			vDay = 17;
			vHour = 13;
			vMinute = 52;
			vSecond = 3;
			vValue = DataUtil.EventorTimesToLong(vYear, vMonth, vDay, vHour, vMinute, vSecond);
			vPropDbNameParam = "_P0";
			vValueParam = "_P1";
			vScript = ".has("+vPropDbNameParam+", Tokens.T.lte, "+vValueParam+")";
			vToType = typeof(FabArtifact);
			vStep = new TravStepWhereEventorDateTime();

			MockItem.Setup(x => x.VerifyParamCount(7, -1));
			MockItem.Setup(x => x.GetParamAt<string>(0)).Returns(vOperation);
			MockItem.Setup(x => x.GetParamAt<long>(1)).Returns(vYear);
			MockItem.Setup(x => x.GetParamAt<byte>(2)).Returns(vMonth);
			MockItem.Setup(x => x.GetParamAt<byte>(3)).Returns(vDay);
			MockItem.Setup(x => x.GetParamAt<byte>(4)).Returns(vHour);
			MockItem.Setup(x => x.GetParamAt<byte>(5)).Returns(vMinute);
			MockItem.Setup(x => x.GetParamAt<byte>(6)).Returns(vSecond);

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

			MockItem.Verify(x => x.VerifyParamCount(7, -1), Times.Once);

			MockPath.Verify(x => x.AddParam(vPropDbName), t);
			MockPath.Verify(x => x.AddParam(vValue), t);
			MockPath.Verify(x => x.AddScript(vScript), t);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("eq")]
		[TestCase("gt")]
		public void SucessOperations(string pOperation) {
			vOperation = pOperation;
			vScript = ".has("+vPropDbNameParam+", Tokens.T."+pOperation+", "+vValueParam+")";

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

		//TODO: add tests for all TravStepWhereEventorDateTime params

	}

}