using System.Collections.Generic;
using Fabric.Domain.Enums;

namespace Fabric.Infrastructure.Data {
	
	/*================================================================================================*/
	public interface IDataDto {

		DataDto.ElementType Type { get; set; }
		string Id { get; set; }
		VertexType.Id? VertexType { get; set; }
		IDictionary<string, string> Properties { get; set; }

		string EdgeLabel { get; set; }
		string EdgeOutVertexId { get; set; }
		string EdgeInVertexId { get; set; }
		
	}

}