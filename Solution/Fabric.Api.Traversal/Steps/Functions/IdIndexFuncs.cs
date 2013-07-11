// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 7/10/2013 9:12:48 PM

using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Domain;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public abstract partial class IdIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal static new void RegisterAllFunctions() {
			FuncRegistry.Register<ArtifactIdIndexFunc>(p => new ArtifactIdIndexFunc(p), ArtifactIdIndexFunc.AllowedForStep);
			FuncRegistry.Register<AppIdIndexFunc>(p => new AppIdIndexFunc(p), AppIdIndexFunc.AllowedForStep);
			FuncRegistry.Register<ClassIdIndexFunc>(p => new ClassIdIndexFunc(p), ClassIdIndexFunc.AllowedForStep);
			FuncRegistry.Register<InstanceIdIndexFunc>(p => new InstanceIdIndexFunc(p), InstanceIdIndexFunc.AllowedForStep);
			FuncRegistry.Register<MemberIdIndexFunc>(p => new MemberIdIndexFunc(p), MemberIdIndexFunc.AllowedForStep);
			FuncRegistry.Register<MemberTypeAssignIdIndexFunc>(p => new MemberTypeAssignIdIndexFunc(p), MemberTypeAssignIdIndexFunc.AllowedForStep);
			FuncRegistry.Register<UrlIdIndexFunc>(p => new UrlIdIndexFunc(p), UrlIdIndexFunc.AllowedForStep);
			FuncRegistry.Register<UserIdIndexFunc>(p => new UserIdIndexFunc(p), UserIdIndexFunc.AllowedForStep);
			FuncRegistry.Register<FactorIdIndexFunc>(p => new FactorIdIndexFunc(p), FactorIdIndexFunc.AllowedForStep);
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
		
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabRoot));
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
		
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabRoot));
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
		
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabRoot));
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
		
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabRoot));
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
		
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabRoot));
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
		
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabRoot));
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
		
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabRoot));
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
		
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabRoot));
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
		
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabRoot));
		}

	}

}