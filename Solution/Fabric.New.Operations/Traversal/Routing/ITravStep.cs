using System;

namespace Fabric.New.Operations.Traversal.Routing {

	/*================================================================================================*/
	public interface ITravStep {

		string Command { get; }
		string CommandLow { get; }
		Type FromType { get; }
		Type ToType { get; }
		bool ToAliasType { get; }
		bool FromExactType { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		bool AcceptsPath(ITravPath pPath);

		/*--------------------------------------------------------------------------------------------*/
		void ConsumePath(ITravPath pPath, Type pToType);

	}

}