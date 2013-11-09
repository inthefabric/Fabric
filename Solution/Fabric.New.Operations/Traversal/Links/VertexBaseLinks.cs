using System.Collections.Generic;

namespace Fabric.New.Operations.Traversal.Links {

	/*================================================================================================*/
	public abstract class VertexBaseLinks {

		public List<ITravLink> Links { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected VertexBaseLinks() {
			Links = new List<ITravLink>();
		}

	}

}