using System;
using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Api.Paths.Steps.Nodes;
using Fabric.Test.Common;
using Fabric.Test.Util;
using NUnit.Framework;

namespace Fabric.Test.FabApiPaths.Steps {

	/*================================================================================================*/
	[TestFixture]
	public class TStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Path();
			var s = new TestStep(p);
			var expectAvail = new[] { "Test1", "TEST2" };

			Assert.AreEqual(p, s.Path, "Incorrect Path.");
			Assert.Null(s.TypeId, "TypeId should be null.");
			Assert.AreEqual(typeof(TestFabNode), s.DtoType, "Incorrect DtoType.");
			Assert.AreEqual(expectAvail, s.AvailableSteps, "Incorrect AvailableSteps.");
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
		[Test]
		public void GetNextStep() {
			var s = new TestStep(new Path());
			const string comm = "teST1";

			IStep result = s.GetNextStep(comm+"(1,2)");

			Assert.NotNull(result, "Result should be filled.");
			Assert.AreEqual(typeof(ArtifactStep), result.GetType(), "Incorrect Result Type.");

			Assert.NotNull(result.Data, "Result.Data should be filled.");
			Assert.AreEqual(comm.ToLower(), result.Data.Command, "Result.Data should be filled.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void GetNextStepInvalid() {
			var s = new TestStep(new Path());
			TestUtil.CheckThrows<Exception>(true, () => s.GetNextStep("abcd(1,2)"));
		}

	}

}