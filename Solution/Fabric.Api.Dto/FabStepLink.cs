using Fabric.Infrastructure.Paths;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public class FabStepLink {
		
		public bool IsOutgoing { get; set; }
		public string Relation { get; set; }
		public string Class { get; set; }
		public string Uri { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabStepLink(IStepLink pLink) {
			IsOutgoing = pLink.IsOutgoing;
			Relation = pLink.RelType;
			Class = "Fab"+pLink.Node;
			Uri = pLink.Uri;
		}

	}

}