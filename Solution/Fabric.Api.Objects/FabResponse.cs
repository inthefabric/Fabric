using System.Collections.Generic;

namespace Fabric.Api.Objects {

	/*================================================================================================*/
	public class FabResponse<T> where T : FabObject {

		public double TotalMs { get; set; }
		public FabError Error { get; set; }
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