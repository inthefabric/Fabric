using System;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using ServiceStack.Text;

namespace Fabric.Infrastructure.Db {
	
	/*================================================================================================*/
	public class DbDto : IDbDto {

		public enum ItemType {
			Node = 1,
			Rel,
			Unknown,
			Error
		}

		private static readonly Type ArtifactType = typeof(Artifact);

		public ItemType Item { get; set; }
		public string Id { get; set; }
		public string Class { get; set; }

		public string ToNodeId { get; set; }
		public string FromNodeId { get; set; }

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
					NodeFabType nft = NodeFabType.Unspecified;

					if ( Data == null ) {
						Item = ItemType.Unknown;
						Class = nft+"";
						break;
					}
					
					if ( Data.ContainsKey(PropDbName.Node_FabType) ) {
						int ft = int.Parse(Data[PropDbName.Node_FabType]);
						nft = NodeFabTypeUtil.ValueMap[ft];
					}

					Item = ItemType.Node;
					Class = nft+"";

					if ( nft == NodeFabType.Unspecified ) {
						throw new Exception("Unspecified node class: Id="+Id);
					}
					
					break;

				case "edge":
					Item = ItemType.Rel;
					Class = pObj["_label"];
					FromNodeId = pObj["_outV"];
					ToNodeId = pObj["_inV"];
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

			Type resultType = typeof(T);

			//TODO: Implement a type check that works with new DbName functionality
			/*if ( resultType.Name != Class ) {
				//IMPROVE: implement more flexible super-class checks
				if ( resultType != ArtifactType || !ArtifactType.IsAssignableFrom(resultType) ) {
					throw new Exception("Incorrect conversion from DbDto class '"+
						Class+"' to type '"+resultType.Name+"'.");
				}
			}*/

			T result = new T();
			result.Id = Id;
			result.FillWithData(Data);

			IRel rel = (result as IRel);

			if ( rel != null ) {
				rel.FromNodeId = FromNodeId;
				rel.ToNodeId = ToNodeId;
			}

			return result;
		}
		
	}

}