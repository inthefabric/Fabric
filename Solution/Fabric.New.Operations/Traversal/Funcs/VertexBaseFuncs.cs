using System.Collections.Generic;

namespace Fabric.New.Operations.Traversal.Funcs {

	/*================================================================================================*/
	public abstract class VertexBaseFuncs {

		public List<ITravFunc> Funcs { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected VertexBaseFuncs() {
			Funcs = new List<ITravFunc>();
		}

	}

}