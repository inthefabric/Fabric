using System;
using System.Collections.Generic;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public abstract class FabNode : IFabNode {

		public long NodeId { get; set; }
		protected abstract long TypeId { get; }
		protected virtual List<string> AvailableProps { get { return AvailProps; } }
		public string NodeUri { get; set; }

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
		public void Fill(IDbDto pDbDto) {
			if ( pDbDto.NodeId == null ) {
				throw new Exception("DbDto.Id is null.");
			}

			NodeId = (long)pDbDto.NodeId;
			FillResultData(pDbDto.Data);

			NodeUri = "("+TypeId+")";
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