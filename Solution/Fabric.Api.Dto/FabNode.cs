using System;
using System.Collections.Generic;
using Fabric.Infrastructure;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public abstract class FabNode {

		public long NodeId { get; set; }

		public string ApiBaseUri { get; set; }
		public string IndexName { get; private set; }
		public string NodeUri { get { return ApiBaseUri+"/"+IndexName+"/"+NodeId; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected FabNode() {
			NodeId = -1;
			ApiBaseUri = "";
			IndexName = GetType().Name.Substring(3);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Fill(DbDto pDbDto) {
			if ( pDbDto.Id == null ) {
				throw new Exception("DbDto.Id is null.");
			}

			NodeId = (long)pDbDto.Id;
			FillResultData(pDbDto.Data);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void FillResultData(Dictionary<string,string> pData);

	}

}