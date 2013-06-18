using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Dto.Traversal {

	/*================================================================================================*/
	public class FabStepLink : FabObject {
		
		public bool IsOut { get; set; }
		public string Edge { get; set; }
		public string Class { get; set; }
		public string Uri { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabStepLink() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabStepLink(IStepLink pLink) {
			IsOut = pLink.IsOutgoing;
			Edge = pLink.EdgeType;
			Class = "Fab"+pLink.Vertex;
			Uri = pLink.Uri;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) { }

	}

}