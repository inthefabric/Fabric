// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 6/18/2013 3:43:35 PM

using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Domain;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public abstract partial class FuncIdIndexStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal static void RegisterAllFunctions() {
			FuncRegistry.Register<FuncArtifactIdIndexStep>(
				(p => new FuncArtifactIdIndexStep(p)), AllowedForStep);
			FuncRegistry.Register<FuncAppIdIndexStep>(
				(p => new FuncAppIdIndexStep(p)), AllowedForStep);
			FuncRegistry.Register<FuncClassIdIndexStep>(
				(p => new FuncClassIdIndexStep(p)), AllowedForStep);
			FuncRegistry.Register<FuncInstanceIdIndexStep>(
				(p => new FuncInstanceIdIndexStep(p)), AllowedForStep);
			FuncRegistry.Register<FuncMemberIdIndexStep>(
				(p => new FuncMemberIdIndexStep(p)), AllowedForStep);
			FuncRegistry.Register<FuncMemberTypeAssignIdIndexStep>(
				(p => new FuncMemberTypeAssignIdIndexStep(p)), AllowedForStep);
			FuncRegistry.Register<FuncUrlIdIndexStep>(
				(p => new FuncUrlIdIndexStep(p)), AllowedForStep);
			FuncRegistry.Register<FuncUserIdIndexStep>(
				(p => new FuncUserIdIndexStep(p)), AllowedForStep);
			FuncRegistry.Register<FuncFactorIdIndexStep>(
				(p => new FuncFactorIdIndexStep(p)), AllowedForStep);
		}

	}


	/*================================================================================================*/
	[Func("Artifact")]
	public class FuncArtifactIdIndexStep : FuncIdIndexStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncArtifactIdIndexStep(IPath pPath) : base(pPath) {
			ProxyStep = new ArtifactStep(pPath);
		}

	}


	/*================================================================================================*/
	[Func("App")]
	public class FuncAppIdIndexStep : FuncIdIndexStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncAppIdIndexStep(IPath pPath) : base(pPath) {
			ProxyStep = new AppStep(pPath);
			FabType = (byte)VertexFabType.App;
		}

	}


	/*================================================================================================*/
	[Func("Class")]
	public class FuncClassIdIndexStep : FuncIdIndexStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncClassIdIndexStep(IPath pPath) : base(pPath) {
			ProxyStep = new ClassStep(pPath);
			FabType = (byte)VertexFabType.Class;
		}

	}


	/*================================================================================================*/
	[Func("Instance")]
	public class FuncInstanceIdIndexStep : FuncIdIndexStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncInstanceIdIndexStep(IPath pPath) : base(pPath) {
			ProxyStep = new InstanceStep(pPath);
			FabType = (byte)VertexFabType.Instance;
		}

	}


	/*================================================================================================*/
	[Func("Member")]
	public class FuncMemberIdIndexStep : FuncIdIndexStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncMemberIdIndexStep(IPath pPath) : base(pPath) {
			ProxyStep = new MemberStep(pPath);
			FabType = (byte)VertexFabType.Member;
		}

	}


	/*================================================================================================*/
	[Func("MemberTypeAssign")]
	public class FuncMemberTypeAssignIdIndexStep : FuncIdIndexStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncMemberTypeAssignIdIndexStep(IPath pPath) : base(pPath) {
			ProxyStep = new MemberTypeAssignStep(pPath);
			FabType = (byte)VertexFabType.MemberTypeAssign;
		}

	}


	/*================================================================================================*/
	[Func("Url")]
	public class FuncUrlIdIndexStep : FuncIdIndexStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncUrlIdIndexStep(IPath pPath) : base(pPath) {
			ProxyStep = new UrlStep(pPath);
			FabType = (byte)VertexFabType.Url;
		}

	}


	/*================================================================================================*/
	[Func("User")]
	public class FuncUserIdIndexStep : FuncIdIndexStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncUserIdIndexStep(IPath pPath) : base(pPath) {
			ProxyStep = new UserStep(pPath);
			FabType = (byte)VertexFabType.User;
		}

	}


	/*================================================================================================*/
	[Func("Factor")]
	public class FuncFactorIdIndexStep : FuncIdIndexStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncFactorIdIndexStep(IPath pPath) : base(pPath) {
			ProxyStep = new FactorStep(pPath);
			FabType = (byte)VertexFabType.Factor;
		}

	}

}