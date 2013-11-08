using System.Collections.Generic;

namespace Fabric.New.Api.Objects {

	/*================================================================================================*/
	public class FabResponse {

		public int TotalMs { get; set; }
		public FabError Error { get; set; }

	}

	/*================================================================================================*/
	public class FabResponse<T> : FabResponse where T : FabObject {

		public IList<T> Data { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabResponse() {}

		/*--------------------------------------------------------------------------------------------*/
		public FabResponse(IList<T> pData) {
			Data = pData;
		}

	}

}