using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using ServiceStack.Text;

namespace Fabric.Infrastructure {
	
	/*================================================================================================*/
	public class DbDto : IDbDto {

		public enum ItemType {
			Node = 1,
			Rel,
			Text,
			Error
		}

		public ItemType Item { get; set; }
		public long? Id { get; set; }
		public string Class { get; set; }

		public long? ToNodeId { get; set; }
		public long? FromNodeId { get; set; }

		public Dictionary<string, string> Data { get; set; }

		public string Message { get; set; }
		public string Exception { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DbDto() {}

		/*--------------------------------------------------------------------------------------------*/
		public DbDto(DbResult pResult) {
			Exception = pResult.Exception;
			Message = pResult.Message;

			if ( Exception != null ) {
				Item = ItemType.Error;
				return;
			}

			////

			string self = pResult.Self;

			if ( Message != null && string.IsNullOrEmpty(self) ) {
				Item = ItemType.Text;
				return;
			}

			////

			Id = DbResult.GetIdFromPath(pResult.Self);

			if ( pResult.Data != null && pResult.Data.Keys.Count > 0 ) {
				Data = pResult.Data;
			}

			Class = GetClass(Data);

			switch ( GetSelfType(self) ) {
				case 'n':
					Item = ItemType.Node;
					break;

				case 'r':
					Item = ItemType.Rel;
					Class = pResult.Type;
					FromNodeId = DbResult.GetIdFromPath(pResult.Start);
					ToNodeId = DbResult.GetIdFromPath(pResult.End);
					break;

				default:
					throw new Exception("Unknown ItemType: "+self[0]);
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public T ToNode<T>() where T : INodeWithId, new() {
			if ( Id == null ) {
				throw new FabArgumentNullFault("DbDto.Id was null.");
			}

			Type resultType = typeof(T);

			if ( resultType.Name != Class ) {
				throw new Exception("Incorrect conversion from DbDto class '"+
					Class+"' to type '"+resultType.Name+"'.");
			}
			
			string json = JsonSerializer.SerializeToString(Data);

			T result = JsonSerializer.DeserializeFromString<T>(json);
			result.Id = (long)Id;
			return result;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static string GetClass(Dictionary<string, string> pData) {
			if ( pData == null ) { return null; }

			foreach ( string key in pData.Keys ) {
				int ki = key.Length-2;
				if ( key.Substring(ki) != "Id" ) { continue; }
				return key.Substring(0, ki);
			}

			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static char GetSelfType(string pSelf) {
			int i0 = pSelf.LastIndexOf('/');
			int i1 = pSelf.LastIndexOf('/', i0-1);
			return pSelf[i1+1];
		}
		
	}

}