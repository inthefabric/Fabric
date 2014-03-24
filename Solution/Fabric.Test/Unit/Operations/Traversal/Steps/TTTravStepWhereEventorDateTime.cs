using System;
using Fabric.Api.Objects;
using Fabric.Domain.Names;
using Fabric.Infrastructure.Faults;
using Fabric.Infrastructure.Util;
using Fabric.Operations.Traversal.Routing;
using Fabric.Operations.Traversal.Steps;
using Fabric.Test.Unit.Operations.Traversal.Routing;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.Unit.Operations.Traversal.Steps {

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

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(-100000000001, true)]
		[TestCase(100000000001, false)]
		public void ErrorYearParamRange(long pYear, bool pLow) {
			MockItem.Setup(x => x.GetParamAt<long>(1)).Returns(pYear);
			var f = new FabStepFault(FabFault.Code.IncorrectParamValue, 0, "", "", 1);
			SetupFault(f, (pLow ? "less" : "greater")+" than");
			CheckConsumePathThrows(f);
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(2, 0, true)]
		[TestCase(2, 13, false)]
		[TestCase(3, 0, true)]
		[TestCase(3, 32, false)]
		[TestCase(4, 25, false)]
		[TestCase(5, 60, false)]
		[TestCase(6, 60, false)]
		public void ErrorDateParamRange(int pIndex, byte pValue, bool pLow) {
			MockItem.Setup(x => x.GetParamAt<byte>(pIndex)).Returns(pValue);
			var f = new FabStepFault(FabFault.Code.IncorrectParamValue, 0, "", "", pIndex);
			SetupFault(f, (pLow ? "less" : "greater")+" than");
			CheckConsumePathThrows(f);
		}

	}

}