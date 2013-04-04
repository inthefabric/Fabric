using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using ServiceStack.Text;

namespace Fabric.Infrastructure.Db {
	
	/*================================================================================================*/
	public class DbDto : IDbDto {

		public enum ItemType {
			Node = 1,
			Rel,
			Error
		}

		private static readonly Type ArtifactType = typeof(Artifact);
		private static readonly string ArtifactId = ArtifactType.Name+"Id";

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

			string type = pRaw._type;

			switch ( type ) {
				case "vertex":
					Item = ItemType.Node;
					Class = GetClass(Data);
					break;

				case "edge":
					Item = ItemType.Rel;
					Class = pRaw._label;
					FromNodeId = pRaw._outV;
					ToNodeId = pRaw._inV;
					break;

				default:
					Item = ItemType.Error;
					throw new Exception("Unknown ItemType: "+type);
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public T ToItem<T>() where T : IItemWithId, new() {
			if ( Id == null ) {
				throw new FabArgumentNullFault("DbDto.Id was null.");
			}

			Type resultType = typeof(T);

			if ( resultType.Name != Class ) {
				if ( resultType != ArtifactType || !ArtifactType.IsAssignableFrom(resultType) ) {
					throw new Exception("Incorrect conversion from DbDto class '"+
						Class+"' to type '"+resultType.Name+"'.");
				}
			}
			
			//OPTIMIZE: Going to JSON then back again is inefficient. Consider moving the serialization
			//from JSON to Dictionary into DbDto. Then DbDto will have the raw string, and can 
			//serialize directly to (T) in this function.

			T result;

			if ( Data == null ) {
				result = new T();
			}
			else {
				string json = JsonSerializer.SerializeToString(Data);
				result = JsonSerializer.DeserializeFromString<T>(json);
			}

			result.Id = Id;

			IRel rel = (result as IRel);

			if ( rel != null ) {
				rel.FromNodeId = FromNodeId;
				rel.ToNodeId = ToNodeId;
			}

			return result;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static string GetClass(IDictionary<string, string> pData) {
			if ( pData == null ) { return null; }
			bool isArt = false;

			foreach ( string key in pData.Keys ) {
				int ki = key.Length-2;

				if ( key.Substring(ki) != "Id" ) {
					continue;
				}

				if ( key == ArtifactId ) {
					isArt = true;
					continue;
				}

				return key.Substring(0, ki);
			}

			return (isArt ? ArtifactType.Name : null);
		}
		
	}

}