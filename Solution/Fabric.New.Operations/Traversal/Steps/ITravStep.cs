using System;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public interface ITravStep {

		string Command { get; }
		int Params { get; }
		Type FromType { get; }
		Type ToType { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		bool AcceptsPath(ITravPath pPath);

		/*--------------------------------------------------------------------------------------------*/
		void ConsumePath(ITravPath pPath);

	}

}