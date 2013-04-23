using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal.Steps.Nodes;
using Fabric.Domain;
using Fabric.Infrastructure.Traversal;
using Fabric.Infrastructure.Weaver;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public interface IFuncWhereAppStep : IFuncStep {}
	public interface IFuncWhereClassStep : IFuncStep {}
	public interface IFuncWhereInstanceStep : IFuncStep {}
	public interface IFuncWhereUrlStep : IFuncStep {}
	public interface IFuncWhereUserStep : IFuncStep {}


	/*================================================================================================*/
	public abstract class FuncWhereTypeStep<T> : FuncStep where T : FabNode, new() {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected FuncWhereTypeStep(IPath pPath) : base(pPath) {
			Path.AddSegment(this, "has");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);
			ExpectParamCount(0);
			ProxyStep = GetNodeStep(Path);
			Path.AppendToCurrentSegment(
				"('"+PropDbName.Node_FabType+"',Tokens.T.eq,"+(int)GetFabType()+")", false);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected abstract NodeFabType GetFabType();
		protected abstract NodeStep<T> GetNodeStep(IPath pPath);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected static bool AllowForArtifactStep(Type pDtoType) {
			return (pDtoType == typeof(FabArtifact));
		}

	}


	/*================================================================================================*/
	[Func("WhereApp")]
	public class FuncWhereAppStep : FuncWhereTypeStep<FabApp>, IFuncWhereAppStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncWhereAppStep(IPath pPath) : base(pPath) { }

		/*--------------------------------------------------------------------------------------------*/
		protected override NodeFabType GetFabType() {
			return NodeFabType.App;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override NodeStep<FabApp> GetNodeStep(IPath pPath) {
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
	public class FuncWhereClassStep : FuncWhereTypeStep<FabClass>, IFuncWhereClassStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncWhereClassStep(IPath pPath) : base(pPath) { }

		/*--------------------------------------------------------------------------------------------*/
		protected override NodeFabType GetFabType() {
			return NodeFabType.Class;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override NodeStep<FabClass> GetNodeStep(IPath pPath) {
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
	public class FuncWhereInstanceStep : FuncWhereTypeStep<FabInstance>, IFuncWhereInstanceStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncWhereInstanceStep(IPath pPath) : base(pPath) { }

		/*--------------------------------------------------------------------------------------------*/
		protected override NodeFabType GetFabType() {
			return NodeFabType.Instance;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override NodeStep<FabInstance> GetNodeStep(IPath pPath) {
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
	public class FuncWhereUrlStep : FuncWhereTypeStep<FabUrl>, IFuncWhereUrlStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncWhereUrlStep(IPath pPath) : base(pPath) { }

		/*--------------------------------------------------------------------------------------------*/
		protected override NodeFabType GetFabType() {
			return NodeFabType.Url;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override NodeStep<FabUrl> GetNodeStep(IPath pPath) {
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
	public class FuncWhereUserStep : FuncWhereTypeStep<FabUser>, IFuncWhereUserStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncWhereUserStep(IPath pPath) : base(pPath) {}

		/*--------------------------------------------------------------------------------------------*/
		protected override NodeFabType GetFabType() {
			return NodeFabType.User;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override NodeStep<FabUser> GetNodeStep(IPath pPath) {
			return new UserStep(pPath);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return AllowForArtifactStep(pDtoType);
		}

	}

}