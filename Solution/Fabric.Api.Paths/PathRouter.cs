
namespace Fabric.Api.Paths {

	/*================================================================================================*/
	public static class PathRouter {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IPathBase GetPath(string pUri) {
			string[] parts = (pUri.Length > 0 ? pUri.Split('/') : new string[0]);
			var path = new Path();
			int n = parts.Length;
			IPathBase pb = new RootPaths(true, path);

			for ( int i = 0 ; i < n ; ++i ) {
				pb = pb.ExecuteUriPart(parts[i]);
			}

			return pb;
		}

	}

}