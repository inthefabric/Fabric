using System;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Api.Traversal.Steps.Vertices;
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
			var p = new Mock<IPath>();
			var s = new TestStep(p.Object);
			var expectAvail = new[] { "Test", "TEST2" };

			Assert.AreEqual(p.Object, s.Path, "Incorrect Path.");
			Assert.AreEqual(typeof(TestFabVertex), s.DtoType, "Incorrect DtoType.");
			Assert.NotNull(s.AvailableLinks, "AvailableLinks should not be null.");
			Assert.AreEqual(2, s.AvailableLinks.Count, "Incorrect AvailableLinks length.");
			Assert.AreEqual(expectAvail[0], s.AvailableLinks[0].EdgeType, "Incorrect AvailableLinks.");
			Assert.AreEqual(expectAvail[1], s.AvailableLinks[1].EdgeType,"Incorrect AvailableLinks[1].");
			Assert.Null(s.Data, "Data should be null.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePath() {
			var p = new Mock<IPath>();
			var s = new TestStep(p.Object);
			var d = new StepData("Testing(1,2,3)");
			s.SetDataAndUpdatePath(d);

			Assert.AreEqual(d, s.Data, "Incorrect Data.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePathAlreadySet() {
			var p = new Mock<IPath>();
			var s = new TestStep(p.Object);
			var d = new StepData("Testing(1,2,3)");
			s.SetDataAndUpdatePath(d);
			TestUtil.CheckThrows<Exception>(true, () => s.SetDataAndUpdatePath(d));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void GetNextStep(bool pSetData) {
			var p = new Mock<IPath>();
			var s = new TestStep(p.Object);
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
		public void GetNextStepLimit() {
			var proxy = new Mock<IStep>();
			var proxySeg = new Mock<IPathSegment>();
			proxySeg.SetupGet(x => x.Step).Returns(proxy.Object);

			var p = new Mock<IPath>();
			p.Setup(x => x.GetSegmentBeforeLast(1)).Returns(proxySeg.Object);

			var s = new TestStep(p.Object);

			IStep result = s.GetNextStep("Limit(0,10)");

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(typeof(LimitFunc), result.GetType(), "Incorrect Result type.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetNextStepInvalid() {
			var p = new Mock<IPath>();
			var s = new TestStep(p.Object);
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
			var p = new Mock<IPath>();
			var s = new TestStep(p.Object);
			const int funcStepI = 3;

			var mockData = new Mock<IStepData>();
			mockData.SetupGet(x => x.RawString).Returns("TestFunc");
			mockData.SetupGet(x => x.Params).Returns((string[])null);

			var funcMock = new Mock<IFunc>();
			funcMock.SetupGet(x => x.Path).Returns(p.Object);
			funcMock.Setup(x => x.GetPathIndex()).Returns(funcStepI);
			funcMock.SetupGet(x => x.Data).Returns(mockData.Object);

			FabStepFault se = TestUtil.CheckThrows<FabStepFault>(true,
				() => s.GetNextStep("unknownLink(1)", true, funcMock.Object));
			Assert.AreEqual(FabFault.Code.InvalidStep, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(funcStepI, se.StepIndex, "Incorrect StepIndex.");
		}

	}

}