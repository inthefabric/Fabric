using Weaver.Interfaces;

namespace Fabric.Domain {

	/*================================================================================================*/
	public interface IRel : IWeaverRel {

		string ToNodeId { get; set; }
		string FromNodeId { get; set; }
		
	}

}