﻿using System;
using System.Collections.Generic;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public abstract class FabNode : FabDto, IFabNode {

		public string Uri { get; set; }

		protected long NodeId { get; set; }
		protected abstract long TypeId { get; }
		protected virtual List<string> AvailableProps { get { return AvailProps; } }

		public static readonly List<string> AvailProps = new List<string> {
			"NodeId" 
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected FabNode() {
			NodeId = -1;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {
			if ( pDbDto.Id == null ) {
				throw new Exception("DbDto.Id is null.");
			}

			NodeId = (long)pDbDto.Id;
			FillResultData(pDbDto.Data);

			Uri = "("+TypeId+")";
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void FillResultData(IDictionary<string,string> pData);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public bool HasProperty(string pPropName) {
			return AvailableProps.Contains(pPropName);
		}

	}

}