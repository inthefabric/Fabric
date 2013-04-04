using System.Collections.Generic;
using Fabric.Domain;

namespace Fabric.Infrastructure.Db {
	
	/*================================================================================================*/
	public interface IDbDto {

		DbDto.ItemType Item { get; set; }
		string Id { get; set; }
		string Class { get; set; }
		string ToNodeId { get; set; }
		string FromNodeId { get; set; }

		IDictionary<string, string> Data { get; set; }

		string Message { get; set; }
		string Exception { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		T ToItem<T>() where T : IItemWithId, new();
		
	}

}