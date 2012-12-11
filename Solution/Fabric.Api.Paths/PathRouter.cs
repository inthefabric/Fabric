
namespace Fabric.Api.Paths {

	/*================================================================================================*/
	public static class PathRouter {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IPathStep GetPath(string pUri) {
			string[] parts = (pUri.Length > 0 ? pUri.Split('/') : new string[0]);
			var path = new Path();
			int n = parts.Length;
			IPathStep step = new RootStep(true, path);

			for ( int i = 0 ; i < n ; ++i ) {
				step = step.ExecuteUriPart(parts[i]);
			}

			return step;
		}

	}

}