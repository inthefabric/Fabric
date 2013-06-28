using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Data;

namespace Fabric.Api.Dto.Traversal {

	/*================================================================================================*/
	public abstract class FabVertex : FabObject, IFabVertex {

		public string Uri { get; set; }

		protected string VertexId { get; set; }
		protected abstract long TypeId { get; }
		protected virtual List<string> AvailableProps { get { return AvailProps; } }

		public static readonly List<string> AvailProps = new List<string> {
			"VertexId" 
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDataDto pDto) {
			if ( pDto.Id == null ) {
				throw new Exception("DbDto.Id is null.");
			}

			VertexId = pDto.Id;
			FillResultData(pDto.Properties);

			Uri = "/WhereId("+TypeId+")";
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void FillResultData(IDictionary<string,string> pData);
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithVertex(IVertex pVertex) {
			VertexId = pVertex.Id;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public bool HasProperty(string pPropName) {
			return AvailableProps.Contains(pPropName);
		}

	}

}