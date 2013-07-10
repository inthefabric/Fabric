// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 7/10/2013 4:48:25 PM

using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public abstract partial class RootTypeFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal static void RegisterAllFunctions() {
			FuncRegistry.Register<ArtifactsFunc>(x => new ArtifactsFunc(x), AllowedForStep);
			FuncRegistry.Register<AppsFunc>(x => new AppsFunc(x), AllowedForStep);
			FuncRegistry.Register<ClassesFunc>(x => new ClassesFunc(x), AllowedForStep);
			FuncRegistry.Register<InstancesFunc>(x => new InstancesFunc(x), AllowedForStep);
			FuncRegistry.Register<MembersFunc>(x => new MembersFunc(x), AllowedForStep);
			FuncRegistry.Register<MemberTypeAssignsFunc>(x => new MemberTypeAssignsFunc(x), AllowedForStep);
			FuncRegistry.Register<UrlsFunc>(x => new UrlsFunc(x), AllowedForStep);
			FuncRegistry.Register<UsersFunc>(x => new UsersFunc(x), AllowedForStep);
			FuncRegistry.Register<FactorsFunc>(x => new FactorsFunc(x), AllowedForStep);
		}

	}


	/*================================================================================================*/
	[Func("Artifacts")]
	public class ArtifactsFunc : RootTypeFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactsFunc(IPath pPath) : base(pPath) {}

	}


	/*================================================================================================*/
	[Func("Apps")]
	public class AppsFunc : RootTypeFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AppsFunc(IPath pPath) : base(pPath) {}

	}


	/*================================================================================================*/
	[Func("Classes")]
	public class ClassesFunc : RootTypeFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ClassesFunc(IPath pPath) : base(pPath) {}

	}


	/*================================================================================================*/
	[Func("Instances")]
	public class InstancesFunc : RootTypeFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public InstancesFunc(IPath pPath) : base(pPath) {}

	}


	/*================================================================================================*/
	[Func("Members")]
	public class MembersFunc : RootTypeFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MembersFunc(IPath pPath) : base(pPath) {}

	}


	/*================================================================================================*/
	[Func("MemberTypeAssigns")]
	public class MemberTypeAssignsFunc : RootTypeFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssignsFunc(IPath pPath) : base(pPath) {}

	}


	/*================================================================================================*/
	[Func("Urls")]
	public class UrlsFunc : RootTypeFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UrlsFunc(IPath pPath) : base(pPath) {}

	}


	/*================================================================================================*/
	[Func("Users")]
	public class UsersFunc : RootTypeFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UsersFunc(IPath pPath) : base(pPath) {}

	}


	/*================================================================================================*/
	[Func("Factors")]
	public class FactorsFunc : RootTypeFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorsFunc(IPath pPath) : base(pPath) {}

	}

}