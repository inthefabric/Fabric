using System.Collections.Generic;

namespace Fabric.New.Infrastructure.Data {
	
	/*================================================================================================*/
	public interface IDataDto {

		DataDto.ElementType Type { get; set; }
		string Id { get; set; }
		string Class { get; set; }
		IDictionary<string, string> Properties { get; set; }

		string EdgeLabel { get; set; }
		string EdgeOutVertexId { get; set; }
		string EdgeInVertexId { get; set; }
		
	}

}