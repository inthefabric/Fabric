using System.Collections.Generic;
using Fabric.Domain;

namespace Fabric.Infrastructure.Db {
	
	/*================================================================================================*/
	public interface IDbDto {

		DbDto.ItemType Item { get; set; }
		long? NodeId { get; set; }
		string Class { get; set; }

		long? ToNodeId { get; set; }
		long? FromNodeId { get; set; }

		IDictionary<string, string> Data { get; set; }

		string Message { get; set; }
		string Exception { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		T ToNode<T>() where T : INodeWithId, new();
		
	}

}