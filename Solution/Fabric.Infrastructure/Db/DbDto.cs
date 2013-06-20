using System;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using ServiceStack.Text;

namespace Fabric.Infrastructure.Db {
	
	/*================================================================================================*/
	public class DbDto : IDbDto {

		public enum ItemType {
			Vertex = 1,
			Edge,
			Unknown,
			Error
		}

		private static readonly Type ArtifactType = typeof(Artifact);

		public ItemType Item { get; set; }
		public string Id { get; set; }
		public string Class { get; set; }

		public string InVertexId { get; set; }
		public string OutVertexId { get; set; }

		public JsonObject Data { get; set; }

		public string Message { get; set; }
		public string Exception { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DbDto() {}

		/*--------------------------------------------------------------------------------------------*/
		public DbDto(JsonObject pObj) {
			if ( !pObj.ContainsKey("_id") ) {
				return;
			}

			Id = pObj["_id"];
			Data = pObj.Object("_properties");

			switch ( pObj["_type"] ) {
				case "vertex":
					VertexFabType nft = VertexFabType.Unspecified;

					if ( Data == null ) {
						Item = ItemType.Unknown;
						Class = nft+"";
						break;
					}
					
					if ( Data.ContainsKey(PropDbName.Vertex_FabType) ) {
						byte ft = byte.Parse(Data[PropDbName.Vertex_FabType]);
						nft = VertexFabTypeUtil.ValueMap[ft];
					}

					Item = ItemType.Vertex;
					Class = nft+"";

					if ( nft == VertexFabType.Unspecified ) {
						throw new Exception("Unspecified vertex class: Id="+Id);
					}
					
					break;

				case "edge":
					Item = ItemType.Edge;
					Class = pObj["_label"];
					OutVertexId = pObj["_outV"];
					InVertexId = pObj["_inV"];
					break;

				default:
					Item = ItemType.Error;
					throw new Exception("Unknown ItemType: "+pObj["_type"]);
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public T ToItem<T>() where T : IItemWithId, new() {
			if ( Id == null ) {
				throw new FabArgumentNullFault("DbDto.Id was null.");
			}

			string idProp = PropDbName.TypeIdMap[typeof(T)];

			if ( !Data.ContainsKey(idProp) ) {
				throw new Exception("Incorrect conversion from DbDto class '"+
					Class+"' to type '"+typeof(T).Name+"'.");
			}

			T result = new T();
			result.Id = Id;
			result.FillWithData(Data);

			IEdge edge = (result as IEdge);

			if ( edge != null ) {
				edge.OutVertexId = OutVertexId;
				edge.InVertexId = InVertexId;
			}

			return result;
		}
		
	}

}