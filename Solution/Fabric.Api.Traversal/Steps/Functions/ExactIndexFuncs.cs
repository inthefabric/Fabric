// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 7/11/2013 5:20:53 PM

using Fabric.Api.Traversal.Steps.Vertices;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public abstract partial class ExactIndexFunc {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal static void RegisterAllFunctions() {
			FuncRegistry.Register<ApNKExactIndexFunc>(p => new ApNKExactIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<ClNKExactIndexFunc>(p => new ClNKExactIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<UrPaExactIndexFunc>(p => new UrPaExactIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<UNKExactIndexFunc>(p => new UNKExactIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<FIdVExactIndexFunc>(p => new FIdVExactIndexFunc(p), AllowedForStep);
		}

	}


	/*================================================================================================*/
	[Func("AppName")]
	public class ApNKExactIndexFunc : ExactIndexFunc<string> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApNKExactIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new AppStep(pPath);
			PropName = "Ap_NK";
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void GetValue() {
			base.GetValue();
			Value = Value.ToLower();
		}

	}


	/*================================================================================================*/
	[Func("ClassName")]
	public class ClNKExactIndexFunc : ExactIndexFunc<string> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ClNKExactIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new ClassStep(pPath);
			PropName = "Cl_NK";
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void GetValue() {
			base.GetValue();
			Value = Value.ToLower();
		}

	}


	/*================================================================================================*/
	[Func("UrlPath")]
	public class UrPaExactIndexFunc : ExactIndexFunc<string> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UrPaExactIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new UrlStep(pPath);
			PropName = "Ur_Pa";
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void GetValue() {
			base.GetValue();
			Value = Value.ToLower();
			Value = Value.Replace("~~~", "://");
		}

	}


	/*================================================================================================*/
	[Func("UserName")]
	public class UNKExactIndexFunc : ExactIndexFunc<string> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UNKExactIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new UserStep(pPath);
			PropName = "U_NK";
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void GetValue() {
			base.GetValue();
			Value = Value.ToLower();
		}

	}


	/*================================================================================================*/
	[Func("FactorIdentorValue")]
	public class FIdVExactIndexFunc : ExactIndexFunc<string> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FIdVExactIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new FactorStep(pPath);
			PropName = "F_IdV";
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void GetValue() {
			base.GetValue();
		}

	}

}