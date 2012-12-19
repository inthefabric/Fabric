using Fabric.Api.Paths.Steps;
using Fabric.Api.Paths.Steps.Functions;
using Fabric.Api.Paths.Steps.Nodes;

namespace Fabric.Api.Paths {

	/*================================================================================================*/
	public static class PathRouter {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IFinalStep GetPath(IStep pRoot, string pUri) {
			string[] parts = (pUri.Length > 0 ? pUri.Split('/') : new string[0]);
			int n = parts.Length;
			IStep step = pRoot;

			for ( int i = 0 ; i < n ; ++i ) {
				string p = parts[i];
				
				if ( p == "" && i == n-1 ) { //allows URI to end with '/'
					continue;
				}

				step = step.GetNextStep(p);
			}

			return FinalizePath(step);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static RootStep NewRootStep() {
			var rs = new RootStep(true, new Path());
			rs.SetDataAndUpdatePath(new StepData("api"));
			return rs;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IFinalStep FinalizePath(IStep pLastStep) {
			var ddStep = (pLastStep as IFinalStep);

			if ( ddStep != null ) {
				return ddStep;
			}

			return (IFinalStep)pLastStep.GetNextStep(FuncLimitStep.DefaultStepText);
		}

	}

}