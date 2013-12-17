using System;
using System.Collections.Generic;

namespace Fabric.New.Operations.Traversal.Routing {

	/*================================================================================================*/
	public interface ITravStep {

		string Command { get; }
		string CommandLow { get; }
		Type FromType { get; }
		Type ToType { get; }
		Type ParamValueType { get; }
		bool ToAliasType { get; }
		bool FromExactType { get; }
		IList<ITravStepParam> Params { get; } //public only for the API spec


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		bool AcceptsPath(ITravPath pPath);

		/*--------------------------------------------------------------------------------------------*/
		void ConsumePath(ITravPath pPath, Type pToType);

	}

}