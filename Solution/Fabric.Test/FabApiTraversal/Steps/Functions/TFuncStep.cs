using System;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Nodes;
using Fabric.Test.Common;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiTraversal.Steps.Functions {

	/*================================================================================================*/
	[TestFixture]
	public class TFuncStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Mock<IPath>();
			var func = new TestFuncStep(p.Object);

			Assert.AreEqual(p.Object, func.Path, "Incorrect Path.");
			Assert.Null(func.DtoType, "Incorrect DtoType.");
			Assert.Null(func.Data, "Data should be null.");

			p.Verify(x => x.AddSegment(func, TestFuncStep.SegmentText), Times.Once());
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void DtoType() {
			RootStep root;
			TestFuncStep func = GetFuncAfterRoot(out root);
			Assert.AreEqual(root.DtoType, func.DtoType, "Incorrect DtoType.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AvailableLinks() {
			RootStep root;
			TestFuncStep func = GetFuncAfterRoot(out root);
			Assert.AreEqual(root.AvailableLinks, func.AvailableLinks, "Incorrect AvailableLinks.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AvailableFuncs() {
			RootStep root;
			TestFuncStep func = GetFuncAfterRoot(out root);
			Assert.AreEqual(root.AvailableFuncs, func.AvailableFuncs, "Incorrect AvailableFuncs.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void GetNextStep(bool pSetData) {
			string stepText = StepUtil.NodeStepMap["Root"][0].Substring(1);

			var next = new Mock<IStep>();
			var proxy = new Mock<IStep>();
			var proxySeg = new Mock<IPathSegment>();
			proxySeg.SetupGet(x => x.Step).Returns(proxy.Object);

			var p = new Mock<IPath>();
			p.Setup(x => x.GetSegmentCount()).Returns(2);
			p.Setup(x => x.GetSegmentBeforeLast(1)).Returns(proxySeg.Object);

			var func = new TestFuncStep(p.Object);
			proxy.Setup(x => x.GetNextStep(stepText, false, func)).Returns(next.Object);

			var sd = new StepData("x");
			func.SetDataAndUpdatePath(sd);

			////

			IStep nextResult = func.GetNextStep(stepText, pSetData);

			////

			Assert.AreEqual(next.Object, nextResult, "Incorrect Result.");

			Times t = Times.Exactly(pSetData ? 1 : 0);
			next.Verify(x => x.SetDataAndUpdatePath(It.Is<StepData>(d => d.RawString == stepText)), t);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetNextStepNullProxy() {
			var p = new Mock<IPath>().Object;
			var func = new TestFuncStep(p);
			TestUtil.CheckThrows<Exception>(true, () => func.GetNextStep(null));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private TestFuncStep GetFuncAfterRoot(out RootStep pRoot) {
			var p = new Mock<IPath>();
			pRoot = new RootStep(p.Object);

			var proxySeg = new Mock<IPathSegment>();
			proxySeg.SetupGet(x => x.Step).Returns(pRoot);

			p.Setup(x => x.GetSegmentCount()).Returns(2);
			p.Setup(x => x.GetSegmentBeforeLast(1)).Returns(proxySeg.Object);

			var func = new TestFuncStep(p.Object);
			func.SetDataAndUpdatePath(new StepData("x"));
			return func;
		}

	}

}