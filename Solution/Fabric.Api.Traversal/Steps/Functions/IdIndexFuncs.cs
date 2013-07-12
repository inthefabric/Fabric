// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 7/11/2013 9:07:33 PM

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
	[Func("ArtifactId")]
	public class ArtifactIdIndexFunc : IdIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactIdIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new ArtifactStep(pPath);
			PropName = (ProxyStep as IVertexStep).TypeIdName;
		}

	}


	/*================================================================================================*/
	[Func("AppId")]
	public class AppIdIndexFunc : IdIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AppIdIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new AppStep(pPath);
			PropName = (ProxyStep as IVertexStep).TypeIdName;
			FabType = (byte)VertexFabType.App;
		}

	}


	/*================================================================================================*/
	[Func("ClassId")]
	public class ClassIdIndexFunc : IdIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ClassIdIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new ClassStep(pPath);
			PropName = (ProxyStep as IVertexStep).TypeIdName;
			FabType = (byte)VertexFabType.Class;
		}

	}


	/*================================================================================================*/
	[Func("InstanceId")]
	public class InstanceIdIndexFunc : IdIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public InstanceIdIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new InstanceStep(pPath);
			PropName = (ProxyStep as IVertexStep).TypeIdName;
			FabType = (byte)VertexFabType.Instance;
		}

	}


	/*================================================================================================*/
	[Func("MemberId")]
	public class MemberIdIndexFunc : IdIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberIdIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new MemberStep(pPath);
			PropName = (ProxyStep as IVertexStep).TypeIdName;
			FabType = (byte)VertexFabType.Member;
		}

	}


	/*================================================================================================*/
	[Func("MemberTypeAssignId")]
	public class MemberTypeAssignIdIndexFunc : IdIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignIdIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new MemberTypeAssignStep(pPath);
			PropName = (ProxyStep as IVertexStep).TypeIdName;
			FabType = (byte)VertexFabType.MemberTypeAssign;
		}

	}


	/*================================================================================================*/
	[Func("UrlId")]
	public class UrlIdIndexFunc : IdIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UrlIdIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new UrlStep(pPath);
			PropName = (ProxyStep as IVertexStep).TypeIdName;
			FabType = (byte)VertexFabType.Url;
		}

	}


	/*================================================================================================*/
	[Func("UserId")]
	public class UserIdIndexFunc : IdIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UserIdIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new UserStep(pPath);
			PropName = (ProxyStep as IVertexStep).TypeIdName;
			FabType = (byte)VertexFabType.User;
		}

	}


	/*================================================================================================*/
	[Func("FactorId")]
	public class FactorIdIndexFunc : IdIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorIdIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new FactorStep(pPath);
			PropName = (ProxyStep as IVertexStep).TypeIdName;
			FabType = (byte)VertexFabType.Factor;
		}

	}

}