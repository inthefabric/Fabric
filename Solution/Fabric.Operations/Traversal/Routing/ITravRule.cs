using System;

namespace Fabric.Operations.Traversal.Routing {

	/*================================================================================================*/
	public interface ITravRule {
		
		ITravStep Step { get; }
		Type FromType { get; }
		Type ToType { get; }

	}

}