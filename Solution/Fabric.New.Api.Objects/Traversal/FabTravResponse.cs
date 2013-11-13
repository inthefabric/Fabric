namespace Fabric.New.Api.Objects.Traversal {

	/*================================================================================================*/
	public class FabTravResponse<T> : FabResponse<T> where T : FabObject {

		public FabTravStep[] Steps { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabTravResponse() {
 			Steps = new FabTravStep[0];
		}

	}

}