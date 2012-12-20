using System;
using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Api.Paths.Steps.Nodes;
using Fabric.Test.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiPaths.Steps.Functions {

	/*================================================================================================*/
	[TestFixture]
	public class TFuncStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Path();
			var root = new RootStep(p);
			var func = new TestFuncStep(p);

			Assert.AreEqual(p, func.Path, "Incorrect Path.");
			Assert.AreEqual(TestFuncStep.SegmentText, func.Path.Segments[1].Script,
				"Incorrect Path.Segment[1].Script.");
			Assert.Null(func.TypeId, "TypeId should be null.");
			Assert.Null(func.DtoType, "Incorrect DtoType.");
			Assert.Null(func.Data, "Data should be null.");
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
			var p = new Path();
			var root = new RootStep(p);

			var func = new TestFuncStep(p);
			var sd = new StepData("x");
			func.SetDataAndUpdatePath(sd);

			string stepText = StepUtil.NodeStepMap["Root"][0].Substring(1);
			IStep next = func.GetNextStep(stepText, pSetData);

			Assert.NotNull(next, "Result should be filled.");

			if ( pSetData ) {
				Assert.NotNull(next.Data, "Result.Data should be filled.");
			}
			else {
				Assert.Null(next.Data, "Result.Data should be null.");
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetNextStepNullProxy() {
			var func = new TestFuncStep(new Path());
			TestUtil.CheckThrows<Exception>(true, () => func.GetNextStep(null));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private TestFuncStep GetFuncAfterRoot(out RootStep pRoot) {
			var p = new Path();
			pRoot = new RootStep(p);
			
			var func = new TestFuncStep(p);
			func.SetDataAndUpdatePath(new StepData("x"));
			return func;
		}

	}

}