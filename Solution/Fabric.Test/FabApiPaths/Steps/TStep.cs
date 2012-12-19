﻿using System;
using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Api.Paths.Steps.Functions;
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
		[TestCase(true)]
		[TestCase(false)]
		public void GetNextStep(bool pSetData) {
			var s = new TestStep(new Path());
			const string comm = "teST1";

			IStep result = s.GetNextStep(comm+"(1,2)", pSetData);

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
			string stepText = "abcd(1,2)";

			StepException se = 
				TestUtil.CheckThrows<StepException>(true, () => s.GetNextStep(stepText));
			Assert.AreEqual(StepException.Code.InvalidStep, se.ErrCode, "Incorrect ErrCode.");
			Assert.Less(-1, se.Message.IndexOf(stepText), "Message did not include the step text.");
		}

	}

}