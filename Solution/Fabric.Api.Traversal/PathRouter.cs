using Fabric.Api.Traversal.Steps;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Api.Traversal.Steps.Nodes;

namespace Fabric.Api.Traversal {

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
		public static RootStep NewRootStep(long pAppId, long pUserId) {
			var p = new Path(pAppId, pUserId);
			var rs = new RootStep(p);
			rs.SetDataAndUpdatePath(new StepData("Root"));
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