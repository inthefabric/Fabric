﻿using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiTraversal.Steps.Functions {

	/*================================================================================================*/
	[TestFixture]
	public class THasIdFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Mock<IPath>();
			var s = new HasIdFunc(p.Object);

			Assert.AreEqual(p.Object, s.Path, "Incorrect Path.");
			Assert.AreEqual(0, s.Index, "Incorrect Index.");
			Assert.AreEqual(1, s.Count, "Incorrect Count.");
			Assert.Null(s.DtoType, "Incorrect DtoType.");
			Assert.Null(s.Data, "Data should be null.");
			Assert.False(s.UseLocalData, "Incorrect UseLocalData.");

			p.Verify(x => x.AddSegment(s, "has"), Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(-1)]
		[TestCase(1)]
		[TestCase(998764)]
		public void SetDataAndUpdatePath(long pId) {
			const string typeIdName = "ArtifactId";

			var proxy = new Mock<IVertexStep>();
			proxy.SetupGet(x => x.TypeIdName).Returns(typeIdName);

			var proxySeg = new Mock<IPathSegment>();
			proxySeg.SetupGet(x => x.Step).Returns(proxy.Object);

			var p = new Mock<IPath>();
			p.Setup(x => x.GetSegmentBeforeLast(1)).Returns(proxySeg.Object);
			p.Setup(x => x
				.AddParam(It.Is((IWeaverQueryVal qv) => qv.RawText == typeIdName)))
				.Returns("_P0");
			p.Setup(x => x
				.AddParam(It.Is((IWeaverQueryVal qv) => qv.RawText == pId+"")))
				.Returns("_P1");

			const string script = "(_P0,Tokens.T.eq,_P1)";

			var wi = new HasIdFunc(p.Object);
			var sd = new StepData("HasId("+pId+")");

			////

			wi.SetDataAndUpdatePath(sd);

			////

			Assert.AreEqual(pId, wi.Id, "Incorrect Id.");
			Assert.AreEqual(0, wi.Index, "Incorrect Index.");
			Assert.AreEqual(1, wi.Count, "Incorrect Count.");
			Assert.AreEqual(proxy.Object, wi.ProxyStep, "Incorrect ProxyStep.");

			p.Verify(x => x.AppendToCurrentSegment(script, false), Times.Once());
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("")]
		[TestCase("(1,2)")]
		public void SetDataAndUpdatePathParamCount(string pParams) {
			var p = new Mock<IPath>();
			var s = new HasIdFunc(p.Object);
			var sd = new StepData("HasId"+pParams);
			
			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamCount, se.ErrCode, "Incorrect ErrCode.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase("a", 0)]
		public void SetDataAndUpdatePathCannotConvert(string pParams, int pParamI) {
			var p = new Mock<IPath>();
			var s = new HasIdFunc(p.Object);
			var sd = new StepData("HasId("+pParams+")");

			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamType, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(pParamI, se.ParamIndex, "Incorrect StepFault.ParamIndex.");
		}

		/*--------------------------------------------------------------------------------------------*/
		[TestCase(0)]
		public void SetDataAndUpdatePathOutOfRange(long pId) {
			var p = new Mock<IPath>();
			var s = new HasIdFunc(p.Object);
			var sd = new StepData("HasId("+pId+")");

			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamValue, se.ErrCode, "Incorrect ErrCode.");
			Assert.AreEqual(0, se.ParamIndex, "Incorrect StepFault.ParamIndex.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabRoot), false)]
		[TestCase(typeof(FabArtifact), true)]
		public void AllowForStep(Type pDtoType, bool pExpect) {
			bool result = HasIdFunc.AllowedForStep(pDtoType);
			Assert.AreEqual(pExpect, result, "Incorrect result.");
		}

	}

}