using System;
using Fabric.Api.Paths.Steps;

namespace Fabric.Api.Paths {

	/*================================================================================================*/
	public class PathSegment {

		public IStep Step { get; private set; }
		public string Script { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public PathSegment(IStep pStep, string pScript) {
			if ( string.IsNullOrWhiteSpace(pScript) ) {
				throw new Exception("No script provided.");
			}

			Step = pStep;
			Script = pScript;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Append(string pScript) {
			if ( string.IsNullOrWhiteSpace(pScript) ) {
				throw new Exception("No script provided.");
			}

			Script += "."+pScript;
		}

	}

}