using System;

namespace Fabric.New.Operations.Traversal.Funcs {

	/*================================================================================================*/
	public interface ITravFunc {

		string Name { get; }
		Type ForObject { get; }
		string ForLink { get; }

	}

}