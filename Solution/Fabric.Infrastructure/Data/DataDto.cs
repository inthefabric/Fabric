﻿using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using RexConnectClient.Core;
using RexConnectClient.Core.Result;

namespace Fabric.Infrastructure.Data {
	
	/*================================================================================================*/
	public class DataDto : IDataDto {

		public string Id { get; set; }
		public string Class { get; set; }
		public IDictionary<string, string> Properties { get; set; }

		public string EdgeLabel { get; set; }
		public string EdgeOutVertexId { get; set; }
		public string EdgeInVertexId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DataDto() {}

		/*--------------------------------------------------------------------------------------------*/
		public DataDto(IGraphElement pGraphElement) {
			Id = pGraphElement.Id;
			Class = pGraphElement.Label; //null if not an edge
			Properties = pGraphElement.Properties;

			EdgeLabel = pGraphElement.Label;
			EdgeOutVertexId = pGraphElement.OutVertexId;
			EdgeInVertexId = pGraphElement.InVertexId;

			if ( pGraphElement.Type != RexConn.GraphElementType.Vertex ) {
				return;
			}

			if ( Properties.ContainsKey(PropDbName.Vertex_FabType) ) {
				byte ft = byte.Parse(Properties[PropDbName.Vertex_FabType]);
				Class = VertexFabTypeUtil.ValueMap[ft]+"";
				return;
			}
			
			throw new Exception("Unspecified vertex class: Id="+pGraphElement.Id);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IDataDto FromGraphElement(IGraphElement pGraphElement) {
			return new DataDto(pGraphElement);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static T ToElement<T>(IGraphElement pGraphElement) where T : IElementWithId, new() {
			return ToElement<T>(FromGraphElement(pGraphElement));
		}

		/*--------------------------------------------------------------------------------------------*/
		public static T ToElement<T>(IDataDto pDto) where T : IElementWithId, new() {
			if ( pDto.Id == null ) {
				throw new FabArgumentNullFault("DataDto.Id was null.");
			}

			string idProp = PropDbName.TypeIdMap[typeof(T)];

			if ( !pDto.Properties.ContainsKey(idProp) ) {
				throw new Exception("Incorrect conversion from DataDto class '"+
					pDto.Class+"' to type '"+typeof(T).Name+"'.");
			}

			T result = new T();
			result.Id = pDto.Id;
			result.FillWithData(pDto.Properties);

			IEdge edge = (result as IEdge);

			if ( edge != null ) {
				edge.OutVertexId = pDto.EdgeOutVertexId;
				edge.InVertexId = pDto.EdgeInVertexId;
			}

			return result;
		}
		
	}

}