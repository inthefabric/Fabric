using System.Collections.Generic;
using System.Net;
using Fabric.Api.Dto;
using Fabric.Infrastructure.Data;

namespace Fabric.Api.Traversal {

	/*================================================================================================*/
	public class TraversalModel {

		public string Query { get; set; }
		public FabResponse Resp { get; set; }

		public IList<IDataDto> DtoList { get; set; }
		public bool IsErrorHandled { get; set; }
		public HttpStatusCode HttpStatus { get; set; }

	}

}