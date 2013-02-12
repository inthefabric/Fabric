using System;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Api.Traversal.Steps.Nodes;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Common;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiTraversal.Steps {

	/*================================================================================================*/
	[TestFixture]
	public class TStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Path();
			var s = new TestStep(p);
			var expectAvail = new[] { "Test", "TEST2" };

			Assert.AreEqual(p, s.Path, "Incorrect Path.");
			Assert.AreEqual(typeof(TestFabNode), s.DtoType, "Incorrect DtoType.");
			Assert.NotNull(s.AvailableLinks, "AvailableLinks should not be null.");
			Assert.AreEqual(2, s.AvailableLinks.Count, "Incorrect AvailableLinks length.");
			Assert.AreEqual(expectAvail[0], s.AvailableLinks[0].RelType,"Incorrect AvailableLinks[0].");
			Assert.AreEqual(expectAvail[1], s.AvailableLinks[1].RelType,"Incorrect AvailableLinks[1].");
			Assert.Null(s.Data, "Data should be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePath() {
			var s = new TestStep(new Path());
			var d = new StepData("Testing(1,2,3)");
			s.SetDataAndUpdatePath(d);

			Assert.AreEqual(d, s.Data, "Incorrect Data.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePathAlreadySet() {
			var s = new TestStep(new Path());
			var d = new StepData("Testing(1,2,3)");
			s.SetDataAndUpdatePath(d);
			TestUtil.CheckThrows<Exception>(true, () => s.SetDataAndUpdatePath(d));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void GetNextStep(bool pSetData) {
			var s = new TestStep(new Path());
			const string comm = "teST1";

			IStep result = s.GetNextStep(comm, pSetData);

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(typeof(ArtifactStep), result.GetType(), "Incorrect Result Type.");

			if ( pSetData ) {
				Assert.NotNull(result.Data, "Result.Data should be filled.");
				Assert.AreEqual(comm.ToLower(), result.Data.Command, "Result.Data should be filled.");
			}
			else {
				Assert.Null(result.Data, "Result.Data should be null.");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetNextStepBack() {
			var p = new Path();
			p.AddSegment(null, "g.v(0).outE");
			p.AddSegment(null, "inV");
			var s = new TestStep(p);

			IStep result = s.GetNextStep("Back(1)");

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(typeof(FuncBackStep), result.GetType(), "Incorrect Result type.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetNextStepLimit() {
			var p = new Path();
			p.AddSegment(null, "g.V");
			var s = new TestStep(p);

			IStep result = s.GetNextStep("Limit(0,10)");

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(typeof(FuncLimitStep), result.GetType(), "Incorrect Result type.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetNextStepInvalid() {
			var s = new TestStep(new Path());
			s.SetDataAndUpdatePath(new StepData("start"));
			const string stepText = "abcd(1,2)";

			FabStepFault se = 
				TestUtil.CheckThrows<FabStepFault>(true, () => s.GetNextStep(stepText));
			Assert.AreEqual(FabFault.Code.InvalidStep, se.ErrCode, "Incorrect ErrCode.");
			Assert.Less(-1, se.Message.IndexOf(stepText), "Message did not include the step text.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetNextStepInvalidProxyForFunc() {
			var p = new Path();
			var s = new TestStep(p);
			const string funcText = "TestFunc";
			const string stepText = "unknownLink(1)";
			const int funcStepI = 1;

			var mockData = new Mock<IStepData>();
			mockData.SetupGet(x => x.RawString).Returns(funcText);
			mockData.SetupGet(x => x.Params).Returns((string[])null);

			var funcMock = new Mock<IFuncStep>();
			funcMock.SetupGet(x => x.Path).Returns(p);
			funcMock.Setup(x => x.GetPathIndex()).Returns(funcStepI);
			funcMock.SetupGet(x => x.Data).Returns(mockData.Object);

			p.AddSegment(funcMock.Object, funcText);

			FabStepFault se = TestUtil.CheckThrows<FabStepFault>(true,
				() => s.GetNextStep(stepText, true, funcMock.Object));
			Assert.AreEqual(FabFault.Code.InvalidStep, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(funcStepI, se.StepIndex, "Incorrect StepIndex.");
		}

	}

}