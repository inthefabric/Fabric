// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 7/10/2013 4:37:29 PM

using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Domain;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public abstract partial class ExactIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal static void RegisterAllFunctions() {
			FuncRegistry.Register<ApNKExactIndexFunc>(p => new ApNKExactIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<ClNKExactIndexFunc>(p => new ClNKExactIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<UrAbExactIndexFunc>(p => new UrAbExactIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<UNKExactIndexFunc>(p => new UNKExactIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<FIdVExactIndexFunc>(p => new FIdVExactIndexFunc(p), AllowedForStep);
		}

	}


	/*================================================================================================*/
	[Func("App_NameKey")]
	public class ApNKExactIndexFunc : ExactIndexFunc<string> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApNKExactIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new AppStep(pPath);
			FabType = (byte)VertexFabType.App;
		}

	}


	/*================================================================================================*/
	[Func("Class_NameKey")]
	public class ClNKExactIndexFunc : ExactIndexFunc<string> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ClNKExactIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new ClassStep(pPath);
			FabType = (byte)VertexFabType.Class;
		}

	}


	/*================================================================================================*/
	[Func("Url_AbsoluteUrl")]
	public class UrAbExactIndexFunc : ExactIndexFunc<string> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UrAbExactIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new UrlStep(pPath);
			FabType = (byte)VertexFabType.Url;
		}

	}


	/*================================================================================================*/
	[Func("User_NameKey")]
	public class UNKExactIndexFunc : ExactIndexFunc<string> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UNKExactIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new UserStep(pPath);
			FabType = (byte)VertexFabType.User;
		}

	}


	/*================================================================================================*/
	[Func("Factor_Identor_Value")]
	public class FIdVExactIndexFunc : ExactIndexFunc<string> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FIdVExactIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new FactorStep(pPath);
			FabType = (byte)VertexFabType.Factor;
		}

	}

}