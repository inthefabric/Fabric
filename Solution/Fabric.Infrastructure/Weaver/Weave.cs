using Fabric.Domain.Meta;
using Weaver;

namespace Fabric.Infrastructure.Weaver {

	/*================================================================================================*/
	public static class Weave {

		public static WeaverInstance Inst = Init();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static WeaverInstance Init() {
			var s = new Schema();
			return new WeaverInstance(s.Nodes, s.Rels);
		}

	}

}