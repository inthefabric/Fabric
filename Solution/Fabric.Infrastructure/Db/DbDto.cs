﻿using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using ServiceStack.Text;

namespace Fabric.Infrastructure.Db {
	
	/*================================================================================================*/
	public class DbDto : IDbDto {

		public enum ItemType {
			Unknown = 0,
			Node,
			Rel,
			Error
		}

		public ItemType Item { get; set; }
		public long? Id { get; set; }
		public string Class { get; set; }

		public long? ToNodeId { get; set; }
		public long? FromNodeId { get; set; }

		public IDictionary<string, string> Data { get; set; }

		public string Message { get; set; }
		public string Exception { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DbDto() {}

		/*--------------------------------------------------------------------------------------------*/
		public DbDto(IDictionary<string, string> pData) {
			Data = pData;

			if ( !Data.ContainsKey("_id") ) {
				return;
			}

			string type = Data["_type"];

			switch ( type ) {
				case "vertex":
					Id = long.Parse(Data["_id"]);
					Item = ItemType.Node;
					Class = GetClass(Data);
					break;

				case "edge":
					string relId = Data["_id"];
					Id = long.Parse(relId.Split(':')[0]);
					Item = ItemType.Rel;
					Class = Data["_label"];
					FromNodeId = long.Parse(Data["_outV"]);
					ToNodeId = long.Parse(Data["_inV"]);
					Data.Remove("_label");
					Data.Remove("_outV");
					Data.Remove("_inV");
					break;

				default:
					throw new Exception("Unknown ItemType: "+type);
			}

			Data.Remove("_id");
			Data.Remove("_type");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public T ToItem<T>() where T : IItemWithId, new() {
			if ( Id == null ) {
				throw new FabArgumentNullFault("DbDto.Id was null.");
			}

			Type resultType = typeof(T);

			if ( resultType.Name != Class ) {
				throw new Exception("Incorrect conversion from DbDto class '"+
					Class+"' to type '"+resultType.Name+"'.");
			}
			
			//OPTIMIZE: Going to JSON then back again is inefficient. Consider moving the serialization
			//from JSON to Dictionary into DbDto. Then DbDto will have the raw string, and can 
			//serialize directly to (T) in this function.

			string json = JsonSerializer.SerializeToString(Data);

			T result = JsonSerializer.DeserializeFromString<T>(json);
			result.Id = (long)Id;

			IRel rel = (result as IRel);

			if ( rel == null ) {
				rel.FromNodeId = (long)FromNodeId;
				rel.ToNodeId = (long)ToNodeId;
			}

			return result;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static string GetClass(IDictionary<string, string> pData) {
			if ( pData == null ) { return null; }

			foreach ( string key in pData.Keys ) {
				int ki = key.Length-2;
				if ( key.Substring(ki) != "Id" ) { continue; }
				return key.Substring(0, ki);
			}

			return null;
		}
		
	}

}