using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Domain;
using Fabric.Infrastructure.Traversal;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Query;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public interface IToAppFunc : IFunc {}
	public interface IToClassFunc : IFunc {}
	public interface IToInstanceFunc : IFunc {}
	public interface IToUrlFunc : IFunc {}
	public interface IToUserFunc : IFunc {}


	/*================================================================================================*/
	public abstract class ToTypeFunc<T> : Func where T : FabVertex, new() {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected ToTypeFunc(IPath pPath) : base(pPath) {
			Path.AddSegment(this, "has");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);
			ExpectParamCount(0);
			ProxyStep = GetVertexStep(Path);

			string propParam = Path.AddParam(new WeaverQueryVal(PropDbName.Vertex_FabType));
			string ftParam = Path.AddParam(new WeaverQueryVal((byte)GetFabType()));
			Path.AppendToCurrentSegment("("+propParam+",Tokens.T.eq,"+ftParam+")", false);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected abstract VertexFabType GetFabType();
		protected abstract VertexStep<T> GetVertexStep(IPath pPath);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected static bool AllowForArtifactStep(Type pDtoType) {
			return (pDtoType == typeof(FabArtifact));
		}

	}


	/*================================================================================================*/
	[Func("ToApp")]
	public class ToAppFunc : ToTypeFunc<FabApp>, IToAppFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ToAppFunc(IPath pPath) : base(pPath) { }

		/*--------------------------------------------------------------------------------------------*/
		protected override VertexFabType GetFabType() {
			return VertexFabType.App;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override VertexStep<FabApp> GetVertexStep(IPath pPath) {
			return new AppStep(pPath);
		}

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return AllowForArtifactStep(pDtoType);
		}

	}


	/*================================================================================================*/
	[Func("ToClass")]
	public class ToClassFunc : ToTypeFunc<FabClass>, IToClassFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ToClassFunc(IPath pPath) : base(pPath) { }

		/*--------------------------------------------------------------------------------------------*/
		protected override VertexFabType GetFabType() {
			return VertexFabType.Class;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override VertexStep<FabClass> GetVertexStep(IPath pPath) {
			return new ClassStep(pPath);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return AllowForArtifactStep(pDtoType);
		}

	}


	/*================================================================================================*/
	[Func("ToInstance")]
	public class ToInstanceFunc : ToTypeFunc<FabInstance>, IToInstanceFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ToInstanceFunc(IPath pPath) : base(pPath) { }

		/*--------------------------------------------------------------------------------------------*/
		protected override VertexFabType GetFabType() {
			return VertexFabType.Instance;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override VertexStep<FabInstance> GetVertexStep(IPath pPath) {
			return new InstanceStep(pPath);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return AllowForArtifactStep(pDtoType);
		}

	}


	/*================================================================================================*/
	[Func("ToUrl")]
	public class ToUrlFunc : ToTypeFunc<FabUrl>, IToUrlFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ToUrlFunc(IPath pPath) : base(pPath) { }

		/*--------------------------------------------------------------------------------------------*/
		protected override VertexFabType GetFabType() {
			return VertexFabType.Url;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override VertexStep<FabUrl> GetVertexStep(IPath pPath) {
			return new UrlStep(pPath);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return AllowForArtifactStep(pDtoType);
		}

	}


	/*================================================================================================*/
	[Func("ToUser")]
	public class ToUserFunc : ToTypeFunc<FabUser>, IToUserFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ToUserFunc(IPath pPath) : base(pPath) { }

		/*--------------------------------------------------------------------------------------------*/
		protected override VertexFabType GetFabType() {
			return VertexFabType.User;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override VertexStep<FabUser> GetVertexStep(IPath pPath) {
			return new UserStep(pPath);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return AllowForArtifactStep(pDtoType);
		}

	}

}