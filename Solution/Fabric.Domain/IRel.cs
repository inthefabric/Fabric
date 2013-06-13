using Weaver.Core.Elements;

namespace Fabric.Domain {

	/*================================================================================================*/
	public interface IRel : IWeaverEdge {

		string InVertexId { get; set; }
		string OutVertexId { get; set; }
		
	}

}