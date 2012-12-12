using Fabric.Api.Paths.Steps;

namespace Fabric.Api.Paths {

	/*================================================================================================*/
	public class PathSegment {

		public IStep Step { get; private set; }
		public string Script { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public PathSegment(IStep pStep, string pScript) {
			Step = pStep;
			Script = pScript;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Append(string pScript) {
			Script += (Script.Length == 0 ? "" : ".")+pScript;
		}

	}

}