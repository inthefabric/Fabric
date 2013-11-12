using System;
using System.Collections.Generic;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public interface ITravStep {

		string Command { get; }
		IList<TravStepParam> Params { get; }
		Type FromType { get; }
		Type ToType { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		bool AcceptsPath(ITravPath pPath);

		/*--------------------------------------------------------------------------------------------*/
		void ConsumePath(ITravPath pPath);

	}

}