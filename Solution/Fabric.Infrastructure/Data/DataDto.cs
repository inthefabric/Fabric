﻿using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Domain.Enums;
using Fabric.Domain.Names;
using Fabric.Infrastructure.Faults;
using RexConnectClient.Core;
using RexConnectClient.Core.Result;
using ServiceStack.Text;

namespace Fabric.Infrastructure.Data {
	
	/*================================================================================================*/
	public class DataDto : IDataDto { //TEST: DataDto

		public enum ElementType {
			Vertex,
			Edge
		}

		public ElementType Type { get; set; }
		public string Id { get; set; }
		public VertexType.Id? VertexType { get; set; }
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
			Properties = pGraphElement.Properties;

			EdgeLabel = pGraphElement.Label;
			EdgeOutVertexId = pGraphElement.OutVertexId;
			EdgeInVertexId = pGraphElement.InVertexId;

			Type = ElementType.Vertex;

			if ( pGraphElement.Type != RexConn.GraphElementType.Vertex ) {
				Type = ElementType.Edge;
				return;
			}

			if ( Properties != null && Properties.ContainsKey(DbName.Vert.Vertex.VertexType) ) {
				byte ft = byte.Parse(Properties[DbName.Vert.Vertex.VertexType]);
				VertexType = (VertexType.Id)Enum.ToObject(typeof(VertexType.Id), ft);
				return;
			}
			
			throw new Exception("Unspecified DataTto type: Id="+pGraphElement.Id+
				", Props="+JsonSerializer.SerializeToString(pGraphElement.Properties));
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IDataDto FromGraphElement(IGraphElement pGraphElement) {
			return new DataDto(pGraphElement);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static T ToElement<T>(IGraphElement pGraphElement) where T : IElement, new() {
			return ToElement<T>(FromGraphElement(pGraphElement));
		}

		/*--------------------------------------------------------------------------------------------*/
		public static T ToElement<T>(IDataDto pDto) where T : IElement, new() {
			if ( pDto.Id == null ) {
				new FabPropertyNullFault("DataDto.Id was null.");
			}

			T result = new T();
			result.Id = pDto.Id;
			result.Fill(pDto.Properties);

			IEdge edge = (result as IEdge);

			if ( edge != null ) {
				edge.OutVertexId = pDto.EdgeOutVertexId;
				edge.InVertexId = pDto.EdgeInVertexId;
			}

			return result;
		}
		
	}

}