using System;
using System.Collections.Generic;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public interface ITravStep {

		string Name { get; }
		string Command { get; }
		IList<ITravStepParam> Params { get; }
		Type FromType { get; }
		Type ToType { get; }
		bool ToAliasType { get; }
		bool FromExactType { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		bool AcceptsPath(ITravPath pPath);

		/*--------------------------------------------------------------------------------------------*/
		void ConsumePath(ITravPath pPath);

	}

}