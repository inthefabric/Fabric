namespace Fabric.Infrastructure.Paths {
	
	/*================================================================================================*/
	public class StepLink : IStepLink {

		public string RelType { get; private set; }
		public string Node { get; private set; }
		public bool IsOutgoing { get; private set; }
		public string Uri { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public StepLink(string pRelType, string pNode, bool pIsOutgoing, string pUri) {
			RelType = pRelType;
			Node = pNode;
			IsOutgoing = pIsOutgoing;
			Uri = pUri;
		}

	}

}