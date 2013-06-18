using System;
using System.Collections.Generic;
using Fabric.Infrastructure.Db;
using Fabric.Domain;

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
		public override void Fill(IDbDto pDbDto) {
			if ( pDbDto.Id == null ) {
				throw new Exception("DbDto.Id is null.");
			}

			VertexId = pDbDto.Id;
			FillResultData(pDbDto.Data);

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