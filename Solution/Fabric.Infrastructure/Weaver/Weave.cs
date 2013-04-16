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

			var nodes = s.Nodes;

			/*foreach ( WeaverNodeSchema ns in nodes ) {
				Log.Debug("NODE: "+ns.DbName+" ("+ns.Name+")");

				foreach ( WeaverPropSchema ps in ns.Props ) {
					Log.Debug(" - "+ps.DbName+" ("+ps.Name+")");
				}
			}*/

			return new WeaverInstance(nodes, s.Rels);
		}

	}

}