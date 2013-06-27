using System.Collections.Generic;

namespace Fabric.Infrastructure.Data {
	
	/*================================================================================================*/
	public interface IDataDto {

		string Id { get; set; }
		string Class { get; set; }
		IDictionary<string, string> Properties { get; set; }

		string EdgeLabel { get; set; }
		string EdgeOutVertexId { get; set; }
		string EdgeInVertexId { get; set; }
		
	}

}