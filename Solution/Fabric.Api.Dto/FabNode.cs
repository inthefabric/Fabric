﻿using System;
using System.Collections.Generic;
using Fabric.Infrastructure;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public abstract class FabNode : IFabNode {

		public long NodeId { get; set; }
		protected abstract long TypeId { get; }

		//public string BaseUri { get; set; }
		//public string NodeUri { get { return BaseUri+"Contains"+vIndexName+"List("+TypeId+")"; } }
		//private string vIndexName;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected FabNode() {
			NodeId = -1;
			//BaseUri = "localhost:9000/api/";
			//vIndexName = GetType().Name.Substring(3);
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