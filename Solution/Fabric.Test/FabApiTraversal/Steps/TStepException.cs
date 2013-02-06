using System;
using System.Collections.Generic;
using Fabric.Api.Traversal.Steps;
using Fabric.Infrastructure.Api.Faults;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiTraversal.Steps {

	/*================================================================================================*/
	[TestFixture]
	public class TStepException {

		private const string Step0Raw = "Root";
		private const string Step1Raw = "First";
		private const string Step2Raw = "Second";

		private List<IStep> vSteps;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[SetUp]
		public void SetUp() {
			vSteps = new List<IStep>();

			var s = new Mock<IStep>();
			var d = new Mock<IStepData>();
			s.Setup(x => x.GetPathIndex()).Returns(0);
			s.SetupGet(x => x.Data).Returns(d.Object);
			d.SetupGet(x => x.RawString).Returns(Step0Raw);
			d.SetupGet(x => x.Params).Returns((string[])null);
			vSteps.Add(s.Object);

			s = new Mock<IStep>();
			d = new Mock<IStepData>();
			s.Setup(x => x.GetPathIndex()).Returns(1);
			s.SetupGet(x => x.Data).Returns(d.Object);
			d.SetupGet(x => x.RawString).Returns(Step1Raw);
			d.SetupGet(x => x.Params).Returns(new [] { "p0" });
			vSteps.Add(s.Object);

			s = new Mock<IStep>();
			d = new Mock<IStepData>();
			s.Setup(x => x.GetPathIndex()).Returns(2);
			s.SetupGet(x => x.Data).Returns(d.Object);
			d.SetupGet(x => x.RawString).Returns(Step2Raw);
			d.SetupGet(x => x.Params).Returns(new [] { "p0", "p1" });
			vSteps.Add(s.Object);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TearDown]
		public void TearDown() {
			vSteps = null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0, Step0Raw)]
		[TestCase(2, Step2Raw)]
		public void New(int pStepIndex, string pStepText) {
			const FabFault.Code code = FabFault.Code.IncorrectParamCount;
			IStep step = vSteps[pStepIndex];
			const string msg = "this is a test.";

			var se = new StepFault(code, step, msg);

			Assert.AreEqual(code, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(step, se.Step, "Incorrect Step.");
			Assert.AreEqual(pStepIndex, se.StepIndex, "Incorrect StepIndex.");
			Assert.AreEqual(-1, se.ParamIndex, "Incorrect ParamIndex.");
			Assert.AreEqual(pStepText, se.StepText, "Incorrect StepText.");
			Assert.AreEqual(null, se.ParamText, "Incorrect ParamText.");

			var expectMsg = "IncorrectParamCount (2001): "+msg+
				"\nStep "+pStepIndex+": '"+pStepText+"'";
			Assert.AreEqual(expectMsg, se.Message, "Incorrect Message.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(1)]
		public void NewParamIndex(int pParamIndex) {
			const FabFault.Code code = FabFault.Code.IncorrectParamValue;
			IStep step = vSteps[2];
			const string msg = "this is a test.";

			var se = new StepFault(code, step, msg, pParamIndex);

			Assert.AreEqual(code, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(step, se.Step, "Incorrect Step.");
			Assert.AreEqual(2, se.StepIndex, "Incorrect StepIndex.");
			Assert.AreEqual(pParamIndex, se.ParamIndex, "Incorrect ParamIndex.");
			Assert.AreEqual(Step2Raw, se.StepText, "Incorrect StepText.");
			Assert.AreEqual("p"+pParamIndex, se.ParamText, "Incorrect ParamText.");

			var expectMsg = "IncorrectParamValue (2002): "+msg+
				"\nStep 2: '"+Step2Raw+"'"+"\nParam "+pParamIndex+": 'p"+pParamIndex+"'";
			Assert.AreEqual(expectMsg, se.Message, "Incorrect Message.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(-2)]
		[TestCase(2)]
		public void NewParamIndexOutOfBounds(int pParamIndex) {
			const FabFault.Code code = FabFault.Code.IncorrectParamValue;
			IStep step = vSteps[2];
			const string msg = "this is a test.";

			var se = new StepFault(code, step, msg, pParamIndex);

			Assert.AreEqual(code, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(step, se.Step, "Incorrect Step.");
			Assert.AreEqual(2, se.StepIndex, "Incorrect StepIndex.");
			Assert.AreEqual(pParamIndex, se.ParamIndex, "Incorrect ParamIndex.");
			Assert.AreEqual(Step2Raw, se.StepText, "Incorrect StepText.");
			Assert.AreEqual(null, se.ParamText, "Incorrect ParamText.");

			var expectMsg = "IncorrectParamValue (2002): "+msg+
				"\nStep 2: '"+Step2Raw+"'"+"\nParam "+pParamIndex+": ''";
			Assert.AreEqual(expectMsg, se.Message, "Incorrect Message.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void NewInnerException() {
			var e = new Exception("inner");
			var se = new StepFault(FabFault.Code.IncorrectParamCount, vSteps[2], "x", -1, e);
			Assert.AreEqual(e, se.InnerException, "Incorrect InnerException.");
		}

	}

}