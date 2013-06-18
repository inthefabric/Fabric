namespace Fabric.Infrastructure.Traversal {
	
	/*================================================================================================*/
	public class StepLink : IStepLink {

		public string EdgeType { get; private set; }
		public string Vertex { get; private set; }
		public bool IsOutgoing { get; private set; }
		public string Uri { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public StepLink(string pEdgeType, string pVertex, bool pIsOutgoing, string pUri) {
			EdgeType = pEdgeType;
			Vertex = pVertex;
			IsOutgoing = pIsOutgoing;
			Uri = pUri;
		}

	}

}