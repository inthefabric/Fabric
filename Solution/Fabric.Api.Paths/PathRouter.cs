using System;

namespace Fabric.Api.Paths {

	/*================================================================================================*/
	public static class PathRouter {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static Path GetPath(string pUri, out Type pDtoType) {
			string[] parts = pUri.Split('/');
			var path = new Path();
			int n = parts.Length;
			IPathBase pb = new RootPaths(true, path);

			for ( int i = 0 ; i < n ; ++i ) {
				pb = pb.ExecuteUriPart(parts[i]);
			}

			pDtoType = pb.DtoType;
			return path;
		}

	}

}