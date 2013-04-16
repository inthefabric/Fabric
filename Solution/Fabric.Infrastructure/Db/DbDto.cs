using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;

namespace Fabric.Infrastructure.Db {
	
	/*================================================================================================*/
	public class DbDto : IDbDto {

		public enum ItemType {
			Node = 1,
			Rel,
			Error
		}

		private static readonly Type ArtifactType = typeof(Artifact);

		public ItemType Item { get; set; }
		public string Id { get; set; }
		public string Class { get; set; }

		public string ToNodeId { get; set; }
		public string FromNodeId { get; set; }

		public IDictionary<string, string> Data { get; set; }

		public string Message { get; set; }
		public string Exception { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DbDto() {}

		/*--------------------------------------------------------------------------------------------*/
		public DbDto(DbDtoRaw pRaw) {
			Id = pRaw._id;
			Data = pRaw._properties;

			if ( Id == null ) {
				return;
			}

			switch ( pRaw._type ) {
				case "vertex":
					int ft = 0;
					
					if ( Data != null && Data.ContainsKey(PropDbName.Node_FabType) ) {
						ft = int.Parse(Data[PropDbName.Node_FabType]);
					}

					Item = ItemType.Node;
					Class = NodeFabTypeUtil.ValueMap[ft]+"";
					break;

				case "edge":
					Item = ItemType.Rel;
					Class = pRaw._label;
					FromNodeId = pRaw._outV;
					ToNodeId = pRaw._inV;
					break;

				default:
					Item = ItemType.Error;
					throw new Exception("Unknown ItemType: "+pRaw._type);
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