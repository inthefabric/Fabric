﻿using Fabric.Api.Paths.Steps;
using Fabric.Api.Paths.Steps.Nodes;

namespace Fabric.Api.Paths {

	/*================================================================================================*/
	public static class PathRouter {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IStep GetPath(string pUri) {
			string[] parts = (pUri.Length > 0 ? pUri.Split('/') : new string[0]);
			var path = new Path();
			int n = parts.Length;
			IStep step = new RootStep(true, path);

			for ( int i = 0 ; i < n ; ++i ) {
				step = step.GetNextStep(parts[i]);
			}

			return step;
		}

	}

}