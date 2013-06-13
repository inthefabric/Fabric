namespace Fabric.Infrastructure.Traversal {
	
	/*================================================================================================*/
	public class StepLink : IStepLink {

		public string EdgeType { get; private set; }
		public string Node { get; private set; }
		public bool IsOutgoing { get; private set; }
		public string Uri { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public StepLink(string pEdgeType, string pNode, bool pIsOutgoing, string pUri) {
			EdgeType = pEdgeType;
			Node = pNode;
			IsOutgoing = pIsOutgoing;
			Uri = pUri;
		}

	}

}