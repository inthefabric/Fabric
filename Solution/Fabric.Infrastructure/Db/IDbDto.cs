using System.Collections.Generic;
using Fabric.Domain;

namespace Fabric.Infrastructure.Db {
	
	/*================================================================================================*/
	public interface IDbDto {

		string Id { get; set; }
		string Class { get; set; }
		IDictionary<string, string> Data { get; set; }
		string OutVertexId { get; set; }
		string InVertexId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		T ToItem<T>() where T : IItemWithId, new();
		
	}

}