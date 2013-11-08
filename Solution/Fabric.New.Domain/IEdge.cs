using Weaver.Core.Elements;

namespace Fabric.New.Domain {

	/*================================================================================================*/
	public interface IEdge : IElement, IWeaverEdge {

		string InVertexId { get; set; }
		string OutVertexId { get; set; }
		
	}

}