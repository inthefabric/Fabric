using Weaver.Interfaces;

namespace Fabric.Domain {

	/*================================================================================================*/
	public interface IRel : IWeaverRel {

		long ToNodeId { get; set; }
		long FromNodeId { get; set; }
		
	}

}