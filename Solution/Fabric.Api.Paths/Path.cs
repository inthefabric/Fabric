using System;
using System.Collections.Generic;
using Fabric.Api.Paths.Steps;

namespace Fabric.Api.Paths {

	/*================================================================================================*/
	public class Path {

		public List<PathSegment> Segments { get; private set; }
		public string Script { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Path() {
			Segments = new List<PathSegment>();
			Script = "";
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddSegment(IStep pStep, string pScript) {
			Segments.Add(new PathSegment(pStep, pScript));
			Script += (Script.Length == 0 ? "" : ".")+pScript;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AppendToCurrentSegment(string pScript) {
			if ( Segments.Count == 0 ) {
				throw new Exception("Path has no segments.");
			}

			Segments[Segments.Count-1].Append(pScript);
			Script += (Script.Length == 0 ? "" : ".")+pScript;
		}

	}

}