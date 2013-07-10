// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 7/10/2013 4:12:18 PM

using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Domain;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public abstract partial class FuncExactIndexStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal static void RegisterAllFunctions() {
			FuncRegistry.Register<FuncApNKExactIndexStep>(
				(p => new FuncApNKExactIndexStep(p)), AllowedForStep);
			FuncRegistry.Register<FuncClNKExactIndexStep>(
				(p => new FuncClNKExactIndexStep(p)), AllowedForStep);
			FuncRegistry.Register<FuncUrAbExactIndexStep>(
				(p => new FuncUrAbExactIndexStep(p)), AllowedForStep);
			FuncRegistry.Register<FuncUNKExactIndexStep>(
				(p => new FuncUNKExactIndexStep(p)), AllowedForStep);
			FuncRegistry.Register<FuncFIdVExactIndexStep>(
				(p => new FuncFIdVExactIndexStep(p)), AllowedForStep);
		}

	}


	/*================================================================================================*/
	[Func("App_NameKey")]
	public class FuncApNKExactIndexStep : FuncExactIndexStep<string> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncApNKExactIndexStep(IPath pPath) : base(pPath) {
			ProxyStep = new AppStep(pPath);
			FabType = (byte)VertexFabType.App;
		}

	}


	/*================================================================================================*/
	[Func("Class_NameKey")]
	public class FuncClNKExactIndexStep : FuncExactIndexStep<string> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncClNKExactIndexStep(IPath pPath) : base(pPath) {
			ProxyStep = new ClassStep(pPath);
			FabType = (byte)VertexFabType.Class;
		}

	}


	/*================================================================================================*/
	[Func("Url_AbsoluteUrl")]
	public class FuncUrAbExactIndexStep : FuncExactIndexStep<string> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncUrAbExactIndexStep(IPath pPath) : base(pPath) {
			ProxyStep = new UrlStep(pPath);
			FabType = (byte)VertexFabType.Url;
		}

	}


	/*================================================================================================*/
	[Func("User_NameKey")]
	public class FuncUNKExactIndexStep : FuncExactIndexStep<string> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncUNKExactIndexStep(IPath pPath) : base(pPath) {
			ProxyStep = new UserStep(pPath);
			FabType = (byte)VertexFabType.User;
		}

	}


	/*================================================================================================*/
	[Func("Factor_Identor_Value")]
	public class FuncFIdVExactIndexStep : FuncExactIndexStep<string> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncFIdVExactIndexStep(IPath pPath) : base(pPath) {
			ProxyStep = new FactorStep(pPath);
			FabType = (byte)VertexFabType.Factor;
		}

	}

}