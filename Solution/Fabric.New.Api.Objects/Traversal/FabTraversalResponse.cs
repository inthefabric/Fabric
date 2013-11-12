namespace Fabric.New.Api.Objects.Traversal {

	/*================================================================================================*/
	public class FabTraversalResponse<T> : FabResponse<T> where T : FabObject {

		//public FabStepLink[] Links { get; set; }
		//public string[] Functions { get; set; }
		public long StartIndex { get; set; }
		public bool HasMore { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		public void SetLinks(List<IStepLink> pLinks) {
			int n = pLinks.Count;
			Links = new FabStepLink[n];

			for ( int i = 0 ; i < n ; ++i ) {
				Links[i] = new FabStepLink(pLinks[i]);
			}
		}*/

	}

}