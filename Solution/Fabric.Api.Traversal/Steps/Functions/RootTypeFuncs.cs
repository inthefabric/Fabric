// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 7/10/2013 8:52:11 PM

using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public abstract partial class RootTypeFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal static void RegisterAllFunctions() {
			FuncRegistry.Register<ArtifactsFunc>(p => new ArtifactsFunc(p), AllowedForStep);
			FuncRegistry.Register<AppsFunc>(p => new AppsFunc(p), AllowedForStep);
			FuncRegistry.Register<ClassesFunc>(p => new ClassesFunc(p), AllowedForStep);
			FuncRegistry.Register<InstancesFunc>(p => new InstancesFunc(p), AllowedForStep);
			FuncRegistry.Register<MembersFunc>(p => new MembersFunc(p), AllowedForStep);
			FuncRegistry.Register<MemberTypeAssignsFunc>(p => new MemberTypeAssignsFunc(p), AllowedForStep);
			FuncRegistry.Register<UrlsFunc>(p => new UrlsFunc(p), AllowedForStep);
			FuncRegistry.Register<UsersFunc>(p => new UsersFunc(p), AllowedForStep);
			FuncRegistry.Register<FactorsFunc>(p => new FactorsFunc(p), AllowedForStep);
		}

	}


	/*================================================================================================*/
	[Func("Artifacts")]
	public class ArtifactsFunc : RootTypeFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactsFunc(IPath pPath) : base(pPath) {
			ProxyStep = new RootTypeStep<FabRootType<FabArtifact>>(pPath);
		}

	}


	/*================================================================================================*/
	[Func("Apps")]
	public class AppsFunc : RootTypeFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AppsFunc(IPath pPath) : base(pPath) {
			ProxyStep = new RootTypeStep<FabRootType<FabApp>>(pPath);
		}

	}


	/*================================================================================================*/
	[Func("Classes")]
	public class ClassesFunc : RootTypeFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ClassesFunc(IPath pPath) : base(pPath) {
			ProxyStep = new RootTypeStep<FabRootType<FabClass>>(pPath);
		}

	}


	/*================================================================================================*/
	[Func("Instances")]
	public class InstancesFunc : RootTypeFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public InstancesFunc(IPath pPath) : base(pPath) {
			ProxyStep = new RootTypeStep<FabRootType<FabInstance>>(pPath);
		}

	}


	/*================================================================================================*/
	[Func("Members")]
	public class MembersFunc : RootTypeFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MembersFunc(IPath pPath) : base(pPath) {
			ProxyStep = new RootTypeStep<FabRootType<FabMember>>(pPath);
		}

	}


	/*================================================================================================*/
	[Func("MemberTypeAssigns")]
	public class MemberTypeAssignsFunc : RootTypeFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignsFunc(IPath pPath) : base(pPath) {
			ProxyStep = new RootTypeStep<FabRootType<FabMemberTypeAssign>>(pPath);
		}

	}


	/*================================================================================================*/
	[Func("Urls")]
	public class UrlsFunc : RootTypeFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UrlsFunc(IPath pPath) : base(pPath) {
			ProxyStep = new RootTypeStep<FabRootType<FabUrl>>(pPath);
		}

	}


	/*================================================================================================*/
	[Func("Users")]
	public class UsersFunc : RootTypeFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UsersFunc(IPath pPath) : base(pPath) {
			ProxyStep = new RootTypeStep<FabRootType<FabUser>>(pPath);
		}

	}


	/*================================================================================================*/
	[Func("Factors")]
	public class FactorsFunc : RootTypeFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorsFunc(IPath pPath) : base(pPath) {
			ProxyStep = new RootTypeStep<FabRootType<FabFactor>>(pPath);
		}

	}

}