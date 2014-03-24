﻿using Weaver.Core.Elements;

namespace Fabric.Domain {

	/*================================================================================================*/
	public interface IEdge : IElement, IWeaverEdge {

		string InVertexId { get; set; }
		string OutVertexId { get; set; }
		
	}

}