using Fabric.Api.Paths.Steps;
using Fabric.Api.Paths.Steps.Nodes;

namespace Fabric.Api.Paths {

	/*================================================================================================*/
	public static class PathRouter {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IStep GetPath(IStep pRoot, string pUri) {
			string[] parts = (pUri.Length > 0 ? pUri.Split('/') : new string[0]);
			int n = parts.Length;
			IStep step = pRoot;

			for ( int i = 0 ; i < n ; ++i ) {
				step = step.GetNextStep(parts[i]);
			}

			return step;
		}

		/*--------------------------------------------------------------------------------------------*/
		public static RootStep NewRootStep() {
			return new RootStep(true, new Path());
		}

	}

}