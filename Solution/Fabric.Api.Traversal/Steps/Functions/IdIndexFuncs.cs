// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 7/10/2013 4:39:00 PM

using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Domain;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public abstract partial class IdIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal static new void RegisterAllFunctions() {
			FuncRegistry.Register<ArtifactIdIndexFunc>(p => new ArtifactIdIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<AppIdIndexFunc>(p => new AppIdIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<ClassIdIndexFunc>(p => new ClassIdIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<InstanceIdIndexFunc>(p => new InstanceIdIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<MemberIdIndexFunc>(p => new MemberIdIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<MemberTypeAssignIdIndexFunc>(p => new MemberTypeAssignIdIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<UrlIdIndexFunc>(p => new UrlIdIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<UserIdIndexFunc>(p => new UserIdIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<FactorIdIndexFunc>(p => new FactorIdIndexFunc(p), AllowedForStep);
		}

	}


	/*================================================================================================*/
	[Func("Artifact")]
	public class ArtifactIdIndexFunc : IdIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactIdIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new ArtifactStep(pPath);
		}

	}


	/*================================================================================================*/
	[Func("App")]
	public class AppIdIndexFunc : IdIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AppIdIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new AppStep(pPath);
			FabType = (byte)VertexFabType.App;
		}

	}


	/*================================================================================================*/
	[Func("Class")]
	public class ClassIdIndexFunc : IdIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ClassIdIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new ClassStep(pPath);
			FabType = (byte)VertexFabType.Class;
		}

	}


	/*================================================================================================*/
	[Func("Instance")]
	public class InstanceIdIndexFunc : IdIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public InstanceIdIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new InstanceStep(pPath);
			FabType = (byte)VertexFabType.Instance;
		}

	}


	/*================================================================================================*/
	[Func("Member")]
	public class MemberIdIndexFunc : IdIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberIdIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new MemberStep(pPath);
			FabType = (byte)VertexFabType.Member;
		}

	}


	/*================================================================================================*/
	[Func("MemberTypeAssign")]
	public class MemberTypeAssignIdIndexFunc : IdIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignIdIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new MemberTypeAssignStep(pPath);
			FabType = (byte)VertexFabType.MemberTypeAssign;
		}

	}


	/*================================================================================================*/
	[Func("Url")]
	public class UrlIdIndexFunc : IdIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UrlIdIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new UrlStep(pPath);
			FabType = (byte)VertexFabType.Url;
		}

	}


	/*================================================================================================*/
	[Func("User")]
	public class UserIdIndexFunc : IdIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UserIdIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new UserStep(pPath);
			FabType = (byte)VertexFabType.User;
		}

	}


	/*================================================================================================*/
	[Func("Factor")]
	public class FactorIdIndexFunc : IdIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorIdIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new FactorStep(pPath);
			FabType = (byte)VertexFabType.Factor;
		}

	}

}