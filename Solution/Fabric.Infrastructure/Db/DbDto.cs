using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using RexConnectClient.Core;
using RexConnectClient.Core.Result;

namespace Fabric.Infrastructure.Db {
	
	/*================================================================================================*/
	public class DbDto : IDbDto {

		public IGraphElement Element { get; set; }

		public string Id { get; set; }
		public string Class { get; set; }
		public IDictionary<string, string> Data { get; set; }
		public string OutVertexId { get; set; }
		public string InVertexId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DbDto() {}

		/*--------------------------------------------------------------------------------------------*/
		public DbDto(IGraphElement pElement) {
			Element = pElement;
			Id = Element.Id;
			Data = Element.Properties;

			Class = Element.Label;
			OutVertexId = Element.OutVertexId;
			InVertexId = Element.InVertexId;

			if ( Element.Type != RexConn.GraphElementType.Vertex ) {
				return;
			}

			VertexFabType nft = VertexFabType.Unspecified;

			if ( Element.Properties.ContainsKey(PropDbName.Vertex_FabType) ) {
				byte ft = byte.Parse(Element.Properties[PropDbName.Vertex_FabType]);
				nft = VertexFabTypeUtil.ValueMap[ft];
			}

			Class = nft+"";

			if ( nft == VertexFabType.Unspecified ) {
				throw new Exception("Unspecified vertex class: Id="+Element.Id);
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public T ToItem<T>() where T : IElementWithId, new() {
			if ( Element.Id == null ) {
				throw new FabArgumentNullFault("DbDto.Id was null.");
			}

			string idProp = PropDbName.TypeIdMap[typeof(T)];

			if ( !Element.Properties.ContainsKey(idProp) ) {
				throw new Exception("Incorrect conversion from DbDto class '"+
					Class+"' to type '"+typeof(T).Name+"'.");
			}

			T result = new T();
			result.Id = Element.Id;
			result.FillWithData(Element.Properties);

			IEdge edge = (result as IEdge);

			if ( edge != null ) {
				edge.OutVertexId = Element.OutVertexId;
				edge.InVertexId = Element.InVertexId;
			}

			return result;
		}
		
	}

}