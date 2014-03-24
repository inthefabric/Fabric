using Weaver.Core.Elements;

namespace Fabric.New.Domain {

	/*================================================================================================*/
	public interface IVertex : IElement, IWeaverVertex {

		long VertexId { get; set; }
		long Timestamp { get; set; }
		byte VertexType { get; set; }

	}

}