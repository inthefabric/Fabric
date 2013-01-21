using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Dto.Traversal {

	/*================================================================================================*/
	public class FabStepLink {
		
		public bool IsOut { get; set; }
		public string Rel { get; set; }
		public string Class { get; set; }
		public string Uri { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabStepLink(IStepLink pLink) {
			IsOut = pLink.IsOutgoing;
			Rel = pLink.RelType;
			Class = "Fab"+pLink.Node;
			Uri = pLink.Uri;
		}

	}

}