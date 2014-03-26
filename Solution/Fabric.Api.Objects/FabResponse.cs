﻿using System.Collections.Generic;

namespace Fabric.Api.Objects {

	/*================================================================================================*/
	public class FabResponse {

		public double TotalMs { get; set; }
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