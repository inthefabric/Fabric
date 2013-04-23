using System;
using System.Collections.Generic;
using Fabric.Infrastructure.Db;
using Fabric.Domain;

namespace Fabric.Api.Dto.Traversal {

	/*================================================================================================*/
	public abstract class FabNode : FabObject, IFabNode {

		public string Uri { get; set; }

		protected string NodeId { get; set; }
		protected abstract long TypeId { get; }
		protected virtual List<string> AvailableProps { get { return AvailProps; } }

		public static readonly List<string> AvailProps = new List<string> {
			"NodeId" 
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {
			if ( pDbDto.Id == null ) {
				throw new Exception("DbDto.Id is null.");
			}

			NodeId = pDbDto.Id;
			FillResultData(pDbDto.Data);

			Uri = "/WhereId("+TypeId+")";
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void FillResultData(IDictionary<string,string> pData);
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(INode pNode) {
			NodeId = pNode.Id;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public bool HasProperty(string pPropName) {
			return AvailableProps.Contains(pPropName);
		}

	}

}