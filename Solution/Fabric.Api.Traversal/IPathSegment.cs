using Fabric.Api.Traversal.Steps;

namespace Fabric.Api.Traversal {

	/*================================================================================================*/
	public interface IPathSegment {

		IStep Step { get; }
		string Script { get; }
		int SubstepCount { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Append(string pScript, bool pAddDot=true);

	}

}