using System.Collections.Generic;
using System.Net;
using Fabric.Api.Dto;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Traversal {

	/*================================================================================================*/
	public class TraversalModel {

		public string Query { get; set; }
		public FabResponse Resp { get; set; }

		public List<IDbDto> DtoList { get; set; }
		public string NonDtoText { get; set; }
		public bool IsErrorHandled { get; set; }
		public HttpStatusCode HttpStatus { get; set; }

	}

}