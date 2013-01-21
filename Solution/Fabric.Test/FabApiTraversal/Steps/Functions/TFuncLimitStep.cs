using System;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiTraversal.Steps.Functions {

	/*================================================================================================*/
	[TestFixture]
	public class TFuncLimitStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Path();
			var s = new FuncLimitStep(p);

			Assert.AreEqual(p, s.Path, "Incorrect Path.");
			Assert.AreEqual("dedup", s.Path.Script, "Incorrect Path.Script.");
			Assert.Null(s.TypeId, "TypeId should be null.");
			Assert.Null(s.DtoType, "Incorrect DtoType.");
			Assert.Null(s.Data, "Data should be null.");
			Assert.False(s.UseLocalData, "Incorrect UseLocalData.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		//[0..20] actually returns 21 items, as the item at index 20 is included.
		//The last item is not included in the API response; it determines FabResponse.HasMore value
		[TestCase(0, 20, "dedup[0..20]")]
		[TestCase(55, 5, "dedup[55..60]")]
		[TestCase(9999, 50, "dedup[9999..10049]")]
		public void SetDataAndUpdatePath(int pIndex, int pCount, string pExpectSegScript) {
			var p = new Path();

			var mockStep = new Mock<IStep>();
			mockStep.SetupGet(x => x.DtoType).Returns(typeof(FabArtifact));
			p.AddSegment(mockStep.Object, "g.artifact");

			var limit = new FuncLimitStep(p);
			var sd = new StepData("Limit("+pIndex+","+pCount+")");
			limit.SetDataAndUpdatePath(sd);

			PathSegment seg = limit.Path.Segments[limit.Path.Segments.Count-1];
			Assert.AreEqual(pIndex, limit.Index, "Incorrect Index.");
			Assert.AreEqual(pCount, limit.Count, "Incorrect Count.");
			Assert.AreEqual(pExpectSegScript, seg.Script, "Incorrect segment Script.");
			Assert.AreEqual("FabArtifact", limit.DtoType.Name, "Incorrect DtoType.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("")]
		[TestCase("(1)")]
		[TestCase("(1,2,3)")]
		public void SetDataAndUpdatePathNoParams(string pParams) {
			var p = new Path();
			var s = new FuncLimitStep(p);
			var sd = new StepData("Limit"+pParams);
			
			StepException se =
				TestUtil.CheckThrows<StepException>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(StepException.Code.IncorrectParamCount, se.ErrCode, "Incorrect ErrCode.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("a,0", 0)]
		[TestCase("0,a", 1)]
		public void SetDataAndUpdatePathCannotConvert(string pParams, int pParamI) {
			var p = new Path();
			var s = new FuncLimitStep(p);
			var sd = new StepData("Limit("+pParams+")");

			StepException se =
				TestUtil.CheckThrows<StepException>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(StepException.Code.IncorrectParamType, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(pParamI, se.ParamIndex, "Incorrect StepException.ParamIndex.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(-1, 20, 0)]
		[TestCase(0, -1, 1)]
		[TestCase(0, 0, 1)]
		[TestCase(0, 51, 1)]
		public void SetDataAndUpdatePathOutOfRange(int pIndex, int pCount, int pParamI) {
			var p = new Path();
			var s = new FuncLimitStep(p);
			var sd = new StepData("Limit("+pIndex+","+pCount+")");

			StepException se =
				TestUtil.CheckThrows<StepException>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(StepException.Code.IncorrectParamValue, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(pParamI, se.ParamIndex, "Incorrect StepException.ParamIndex.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabRoot), false)]
		[TestCase(typeof(FabOauth), false)]
		[TestCase(typeof(FabArtifact), true)]
		public void AllowForStep(Type pDtoType, bool pExpect) {
			bool result = FuncLimitStep.AllowedForStep(pDtoType);
			Assert.AreEqual(pExpect, result, "Incorrect result.");
		}

	}

}