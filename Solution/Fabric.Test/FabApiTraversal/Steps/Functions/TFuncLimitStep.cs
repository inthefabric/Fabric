using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiTraversal.Steps.Functions {

	/*================================================================================================*/
	[TestFixture]
	public class TFuncLimitStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Mock<IPath>();
			var s = new FuncLimitStep(p.Object);

			Assert.AreEqual(p.Object, s.Path, "Incorrect Path.");
			Assert.Null(s.DtoType, "Incorrect DtoType.");
			Assert.Null(s.Data, "Data should be null.");
			Assert.False(s.UseLocalData, "Incorrect UseLocalData.");

			p.Verify(x => x.AddSegment(s, "dedup"), Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		//[0..20] actually returns 21 items, as the item at index 20 is included.
		//The last item is not included in the API response; it determines FabResponse.HasMore value
		[TestCase(0, 20, 20)]
		[TestCase(55, 5, 60)]
		[TestCase(9999, 50, 10049)]
		public void SetDataAndUpdatePath(int pIndex, int pCount, int pExpect) {
			var proxy = new Mock<IStep>();
			var proxySeg = new Mock<IPathSegment>();
			proxySeg.SetupGet(x => x.Step).Returns(proxy.Object);

			var p = new Mock<IPath>();
			p.Setup(x => x.GetSegmentBeforeLast(1)).Returns(proxySeg.Object);
			p.Setup(x => x.AddParam(It.Is<IWeaverQueryVal>(v => (long)v.Original == pIndex)))
				.Returns("_P0");
			p.Setup(x => x.AddParam(It.Is<IWeaverQueryVal>(v => (long)v.Original == pExpect)))
				.Returns("_P1");

			var limit = new FuncLimitStep(p.Object);
			var sd = new StepData("Limit("+pIndex+","+pCount+")");

			////

			limit.SetDataAndUpdatePath(sd);

			////

			Assert.AreEqual(pIndex, limit.Index, "Incorrect Index.");
			Assert.AreEqual(pCount, limit.Count, "Incorrect Count.");
			Assert.AreEqual(proxy.Object, limit.ProxyStep, "Incorrect ProxyStep.");

			p.Verify(x => x.AppendToCurrentSegment("[_P0.._P1]", false), Times.Once());
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("")]
		[TestCase("(1)")]
		[TestCase("(1,2,3)")]
		public void SetDataAndUpdatePathNoParams(string pParams) {
			var p = new Mock<IPath>();
			var s = new FuncLimitStep(p.Object);
			var sd = new StepData("Limit"+pParams);
			
			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamCount, se.ErrCode, "Incorrect ErrCode.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("a,0", 0)]
		[TestCase("0,a", 1)]
		public void SetDataAndUpdatePathCannotConvert(string pParams, int pParamI) {
			var p = new Mock<IPath>();
			var s = new FuncLimitStep(p.Object);
			var sd = new StepData("Limit("+pParams+")");

			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamType, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(pParamI, se.ParamIndex, "Incorrect StepFault.ParamIndex.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(-1, 20, 0)]
		[TestCase(0, -1, 1)]
		[TestCase(0, 0, 1)]
		[TestCase(0, 51, 1)]
		public void SetDataAndUpdatePathOutOfRange(int pIndex, int pCount, int pParamI) {
			var p = new Mock<IPath>();
			var s = new FuncLimitStep(p.Object);
			var sd = new StepData("Limit("+pIndex+","+pCount+")");

			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamValue, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(pParamI, se.ParamIndex, "Incorrect StepFault.ParamIndex.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabRoot), false)]
		[TestCase(typeof(FabArtifact), true)]
		public void AllowForStep(Type pDtoType, bool pExpect) {
			bool result = FuncLimitStep.AllowedForStep(pDtoType);
			Assert.AreEqual(pExpect, result, "Incorrect result.");
		}

	}

}