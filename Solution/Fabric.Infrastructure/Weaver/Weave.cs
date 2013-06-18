using Fabric.Domain.Meta;
using Weaver.Core;

namespace Fabric.Infrastructure.Weaver {

	/*================================================================================================*/
	public static class Weave {

		public static readonly WeaverInstance Inst = Init();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static WeaverInstance Init() {
			var s = new Schema();
			return new WeaverInstance(s.Vertices, s.Edges);
		}

	}

}