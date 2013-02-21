using Weaver.Interfaces;
using Weaver.Items;

namespace Fabric.Domain {

	/*================================================================================================*/
	public abstract class Rel<TFrom, TType, TTo> : WeaverRel<TFrom,TType,TTo>, IRel
																	where TFrom : IWeaverNode, new()
																	where TType : IWeaverRelType, new()
																	where TTo : IWeaverNode, new() {

		public long ToNodeId { get; set; }
		public long FromNodeId { get; set; }

	}

}