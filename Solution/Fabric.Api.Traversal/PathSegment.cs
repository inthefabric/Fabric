using System;
using Fabric.Api.Traversal.Steps;

namespace Fabric.Api.Traversal {

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
		public void Append(string pScript, bool pAddDot=true) {
			if ( string.IsNullOrWhiteSpace(pScript) ) {
				throw new Exception("No script provided.");
			}

			Script += (pAddDot ? "." : "")+pScript;
		}

		/*--------------------------------------------------------------------------------------------*/
		public int SubstepCount {
			get {
				string s = Script.Replace("..", "-");
				int c0 = s.Split('.').Length;
				int c1 = s.Split('[').Length-1;
				return c0+c1;
			}
		}

	}

}