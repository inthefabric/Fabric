using System.Collections.Generic;
using Fabric.Domain;

namespace Fabric.Infrastructure {
	
	/*================================================================================================*/
	public interface IDbDto {

		DbDto.ItemType Item { get; set; }
		long? Id { get; set; }
		string Class { get; set; }

		long? ToNodeId { get; set; }
		long? FromNodeId { get; set; }

		Dictionary<string, string> Data { get; set; }

		string Message { get; set; }
		string Exception { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		T ToNode<T>() where T : INode, new();
		
	}

}