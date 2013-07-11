using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal;
using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Fabric.Test.Util;
using Moq;
using NUnit.Framework;
using Weaver.Core.Query;

namespace Fabric.Test.FabApiTraversal.Steps.Functions {

	/*================================================================================================*/
	public abstract class TToTypeFunc<T> where T : FabVertex, new() {

		protected abstract VertexFabType VertFabType { get; }

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected abstract ToTypeFunc<T> NewFunc(IPath pPath);

		/*--------------------------------------------------------------------------------------------*/
		protected abstract bool AllowedForStep(Type pDtoType);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void New() {
			var p = new Mock<IPath>();
			var s = NewFunc(p.Object);

			Assert.AreEqual(p.Object, s.Path, "Incorrect Path.");
			Assert.Null(s.DtoType, "Incorrect DtoType.");
			Assert.Null(s.Data, "Data should be null.");

			p.Verify(x => x.AddSegment(s, "has"), Times.Once());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void SetDataAndUpdatePath() {
			var p = new Mock<IPath>();
			p.Setup(x => x
				.AddParam(It.Is((IWeaverQueryVal qv) => qv.RawText == PropDbName.Vertex_FabType)))
				.Returns("_P0");
			p.Setup(x => x
				.AddParam(It.Is((IWeaverQueryVal qv) => qv.RawText == (byte)VertFabType+"")))
				.Returns("_P1");

			const string script = "(_P0,Tokens.T.eq,_P1)";

			var wi = NewFunc(p.Object);
			var sd = new StepData("To"+VertFabType+"()");

			////

			wi.SetDataAndUpdatePath(sd);

			////

			Assert.True(wi.ProxyStep is VertexStep<T>,
				"Incorrect ProxyStep type: "+wi.ProxyStep.GetType());

			p.Verify(x => x.AppendToCurrentSegment(script, false), Times.Once());
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[TestCase("(1)")]
		[TestCase("(1,2)")]
		public void SetDataAndUpdatePathParamCount(string pParams) {
			var p = new Mock<IPath>();
			var s = NewFunc(p.Object);
			var sd = new StepData("To"+VertFabType+pParams);
			
			FabStepFault se =
				TestUtil.CheckThrows<FabStepFault>(true, () => s.SetDataAndUpdatePath(sd));
			Assert.AreEqual(FabFault.Code.IncorrectParamCount, se.ErrCode, "Incorrect ErrCode.");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[TestCase(typeof(FabRoot), false)]
		[TestCase(typeof(FabArtifact), true)]
		public void AllowForStep(Type pDtoType, bool pExpect) {
			bool result = AllowedForStep(pDtoType);
			Assert.AreEqual(pExpect, result, "Incorrect result.");
		}

	}


	/*================================================================================================*/
	[TestFixture]
	public class TToAppFunc : TToTypeFunc<FabApp> {

		protected override VertexFabType VertFabType { get { return VertexFabType.App; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override ToTypeFunc<FabApp> NewFunc(IPath pPath) {
			return new ToAppFunc(pPath);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool AllowedForStep(Type pDtoType) {
			return ToAppFunc.AllowedForStep(pDtoType);
		}

	}


	/*================================================================================================*/
	[TestFixture]
	public class TToClassFunc : TToTypeFunc<FabClass> {

		protected override VertexFabType VertFabType { get { return VertexFabType.Class; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override ToTypeFunc<FabClass> NewFunc(IPath pPath) {
			return new ToClassFunc(pPath);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool AllowedForStep(Type pDtoType) {
			return ToClassFunc.AllowedForStep(pDtoType);
		}

	}


	/*================================================================================================*/
	[TestFixture]
	public class TToInstanceFunc : TToTypeFunc<FabInstance> {

		protected override VertexFabType VertFabType { get { return VertexFabType.Instance; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override ToTypeFunc<FabInstance> NewFunc(IPath pPath) {
			return new ToInstanceFunc(pPath);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool AllowedForStep(Type pDtoType) {
			return ToInstanceFunc.AllowedForStep(pDtoType);
		}

	}


	/*================================================================================================*/
	[TestFixture]
	public class TToUrlFunc : TToTypeFunc<FabUrl> {

		protected override VertexFabType VertFabType { get { return VertexFabType.Url; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override ToTypeFunc<FabUrl> NewFunc(IPath pPath) {
			return new ToUrlFunc(pPath);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool AllowedForStep(Type pDtoType) {
			return ToUrlFunc.AllowedForStep(pDtoType);
		}

	}


	/*================================================================================================*/
	[TestFixture]
	public class TToUserFunc : TToTypeFunc<FabUser> {

		protected override VertexFabType VertFabType { get { return VertexFabType.User; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override ToTypeFunc<FabUser> NewFunc(IPath pPath) {
			return new ToUserFunc(pPath);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override bool AllowedForStep(Type pDtoType) {
			return ToUserFunc.AllowedForStep(pDtoType);
		}

	}

}