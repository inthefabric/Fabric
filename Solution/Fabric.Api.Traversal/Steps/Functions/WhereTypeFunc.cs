using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Domain;
using Fabric.Infrastructure.Traversal;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Query;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public interface IWhereAppFunc : IFunc {}
	public interface IWhereClassFunc : IFunc {}
	public interface IWhereInstanceFunc : IFunc {}
	public interface IWhereUrlFunc : IFunc {}
	public interface IWhereUserFunc : IFunc {}


	/*================================================================================================*/
	public abstract class WhereTypeFunc<T> : Func where T : FabVertex, new() { //TEST: WhereTypeFunc


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected WhereTypeFunc(IPath pPath) : base(pPath) {
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
	[Func("WhereApp")]
	public class WhereAppFunc : WhereTypeFunc<FabApp>, IWhereAppFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public WhereAppFunc(IPath pPath) : base(pPath) { }

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
	[Func("WhereClass")]
	public class WhereClassFunc : WhereTypeFunc<FabClass>, IWhereClassFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public WhereClassFunc(IPath pPath) : base(pPath) { }

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
	[Func("WhereInstance")]
	public class WhereInstanceFunc : WhereTypeFunc<FabInstance>, IWhereInstanceFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public WhereInstanceFunc(IPath pPath) : base(pPath) { }

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
	[Func("WhereUrl")]
	public class WhereUrlFunc : WhereTypeFunc<FabUrl>, IWhereUrlFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public WhereUrlFunc(IPath pPath) : base(pPath) { }

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
	[Func("WhereUser")]
	public class WhereUserFunc : WhereTypeFunc<FabUser>, IWhereUserFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public WhereUserFunc(IPath pPath) : base(pPath) { }

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