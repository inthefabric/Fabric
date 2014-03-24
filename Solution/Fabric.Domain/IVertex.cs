using Weaver.Core.Elements;

namespace Fabric.Domain {

	/*================================================================================================*/
	public interface IVertex : IElement, IWeaverVertex {

		long VertexId { get; set; }
		long Timestamp { get; set; }
		byte VertexType { get; set; }

	}

}