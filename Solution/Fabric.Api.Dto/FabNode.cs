using System;
using System.Collections.Generic;
using Fabric.Infrastructure;

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
			if ( pDbDto.Id == null ) {
				throw new Exception("DbDto.Id is null.");
			}

			NodeId = (long)pDbDto.Id;
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