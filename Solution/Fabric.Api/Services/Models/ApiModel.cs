using System.Collections.Generic;
using Fabric.Api.Dto;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Services.Models {

	/*================================================================================================*/
	public class ApiModel {

		public string Query { get; set; }
		public FabResponse Resp { get; set; }

		public List<IDbDto> DtoList { get; set; }
		public string NonDtoText { get; set; }
		public FabError Error { get; set; }

	}

}