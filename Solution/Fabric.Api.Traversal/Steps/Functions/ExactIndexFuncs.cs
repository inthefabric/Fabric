// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 7/10/2013 9:55:25 PM

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
			FuncRegistry.Register<UrPaExactIndexFunc>(p => new UrPaExactIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<UNKExactIndexFunc>(p => new UNKExactIndexFunc(p), AllowedForStep);
			FuncRegistry.Register<FIdVExactIndexFunc>(p => new FIdVExactIndexFunc(p), AllowedForStep);
		}

	}


	/*================================================================================================*/
	[Func("AppName")]
	public class ApNKExactIndexFunc : ExactIndexFunc<string> {
	
		[FuncParam(0)]
		public string Name { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApNKExactIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new AppStep(pPath);
			PropName = "Ap_NK";
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void GetValue() {
			base.GetValue();
			Param0 = Param0.ToLower().Replace("~~~", "://");
		}

	}


	/*================================================================================================*/
	[Func("ClassName")]
	public class ClNKExactIndexFunc : ExactIndexFunc<string> {
	
		[FuncParam(0)]
		public string Name { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ClNKExactIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new ClassStep(pPath);
			PropName = "Cl_NK";
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void GetValue() {
			base.GetValue();
			Param0 = Param0.ToLower().Replace("~~~", "://");
		}

	}


	/*================================================================================================*/
	[Func("UrlPath")]
	public class UrPaExactIndexFunc : ExactIndexFunc<string> {
	
		[FuncParam(0)]
		public string Url { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UrPaExactIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new UrlStep(pPath);
			PropName = "Ur_Pa";
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void GetValue() {
			base.GetValue();
			Param0 = Param0.ToLower().Replace("~~~", "://");
		}

	}


	/*================================================================================================*/
	[Func("UserName")]
	public class UNKExactIndexFunc : ExactIndexFunc<string> {
	
		[FuncParam(0)]
		public string Name { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UNKExactIndexFunc(IPath pPath) : base(pPath) {
			ProxyStep = new UserStep(pPath);
			PropName = "U_NK";
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void GetValue() {
			base.GetValue();
			Param0 = Param0.ToLower().Replace("~~~", "://");
		}

	}


	/*================================================================================================*/
	[Func("FactorIdentorValue")]
	public class FIdVExactIndexFunc : ExactIndexFunc<string> {
	
		[FuncParam(0)]
		public string Identor_Value { get; private set; }


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