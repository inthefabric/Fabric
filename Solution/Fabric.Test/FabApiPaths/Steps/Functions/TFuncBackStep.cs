using System;
using Fabric.Api.Dto;
using Fabric.Api.Paths;
using Fabric.Api.Paths.Steps;
using Fabric.Api.Paths.Steps.Functions;
using Fabric.Api.Paths.Steps.Nodes;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiPaths.Steps.Functions {

	/*================================================================================================*/
	[TestFixture]
	public class TFuncBackStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Path();
			var s = new FuncBackStep(p);

			Assert.AreEqual(p, s.Path, "Incorrect Path.");
			Assert.Null(s.TypeId, "TypeId should be null.");
			Assert.Null(s.DtoType, "Incorrect DtoType.");
			Assert.Null(s.Data, "Data should be null.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(1, 2, "FabFactor")]
		[TestCase(2, 3, "FabArtifact")]
		[TestCase(3, 6, "FabRoot")]
		public void SetDataAndUpdatePath(int pUriCount, int pExpectCount, string pExpectDtoType) {
			var p = new Path();

			var mockStep = new Mock<IStep>();
			mockStep.SetupGet(x => x.DtoType).Returns(typeof(FabRoot));
			p.AddSegment(mockStep.Object, "g.first"); //2 steps

			mockStep = new Mock<IStep>();
			mockStep.SetupGet(x => x.DtoType).Returns(typeof(FabArtifact));
			p.AddSegment(mockStep.Object, "second(x).has(this).and(that)"); //3 steps

			mockStep = new Mock<IStep>();
			mockStep.SetupGet(x => x.DtoType).Returns(typeof(FabFactor));
			p.AddSegment(mockStep.Object, "third(1,2)"); //1 step

			mockStep = new Mock<IStep>();
			mockStep.SetupGet(x => x.DtoType).Returns(typeof(FabDescriptor));
			p.AddSegment(mockStep.Object, "fourth.where(x,y).then(99)"); //3 steps

			var back = new FuncBackStep(p);
			var sd = new StepData("Back("+pUriCount+")");
			back.SetDataAndUpdatePath(sd);

			PathSegment seg = back.Path.Segments[back.Path.Segments.Count-1];
			Assert.AreEqual(pExpectCount, back.Count, "Incorrect Count.");
			Assert.AreEqual("back("+pExpectCount+")", seg.Script, "Incorrect segment Script.");
			Assert.AreEqual(pExpectDtoType, back.DtoType.Name, "Incorrect DtoType.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("")]
		[TestCase("(1,2)")]
		public void SetDataAndUpdatePathNoParams(string pParams) {
			var p = new Path();
			var s = new FuncBackStep(p);
			var sd = new StepData("back"+pParams);
			
			StepException se =
				TestUtil.CheckThrows<StepException>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(StepException.Code.IncorrectParamCount, se.ErrCode, "Incorrect ErrCode.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePathCannotConvert() {
			var p = new Path();
			var s = new FuncBackStep(p);
			var sd = new StepData("back(i)");

			StepException se =
				TestUtil.CheckThrows<StepException>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(StepException.Code.IncorrectParamType, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(0, se.ParamIndex, "Incorrect ParamIndex.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		[TestCase(-1)]
		public void SetDataAndUpdatePathLessThanOne(int pCount) {
			var p = new Path();
			var s = new FuncBackStep(p);
			var sd = new StepData("back("+pCount+")");

			StepException se =
				TestUtil.CheckThrows<StepException>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(StepException.Code.IncorrectParamValue, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(0, se.ParamIndex, "Incorrect ParamIndex.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePathBackTooFar() {
			var p = new Path();
			p.AddSegment(null, "first");
			p.AddSegment(null, "second(x).has(x,y,z).and(1,2,3)");
			p.AddSegment(null, "third(1,2)");

			var s = new FuncBackStep(p);
			var sd = new StepData("back(3)");

			StepException se =
				TestUtil.CheckThrows<StepException>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(StepException.Code.IncorrectParamValue, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(0, se.ParamIndex, "Incorrect ParamIndex.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void AvailableLinks() {
			var p = new Path();
			var step = new RootStep(false, p).ContainsArtifactList;

			var back = new FuncBackStep(p);
			var sd = new StepData("Back(1)");
			back.SetDataAndUpdatePath(sd);

			var rs = new RootStep(false, new Path());
			Assert.AreEqual(rs.AvailableLinks, back.AvailableLinks, "Incorrect AvailableLinks.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(true)]
		[TestCase(false)]
		public void GetNextStep(bool pSetData) {
			var p = new Path();
			var step = new RootStep(false, p).ContainsArtifactList;

			var back = new FuncBackStep(p);
			var sd = new StepData("Back(1)");
			back.SetDataAndUpdatePath(sd);

			string stepText = StepUtil.NodeStepMap["Root"][4].Substring(1);
			IStep next = back.GetNextStep(stepText, pSetData);

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
		public void GetNextStepNoBackTo() {
			var back = new FuncBackStep(new Path());
			TestUtil.CheckThrows<Exception>(true, () => back.GetNextStep(null));
		}

	}

}