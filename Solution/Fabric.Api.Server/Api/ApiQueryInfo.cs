using System;
using System.Collections.Generic;
using Fabric.Api.Dto;
using Fabric.Infrastructure;

namespace Fabric.Api.Server.Api {

	/*================================================================================================*/
	public class ApiQueryInfo {

		public string Query { get; set; }
		public Type DtoType { get; set; }
		public FabResponse Resp { get; set; }

		public List<DbDto> DtoList { get; set; }
		public bool IsSingleDto { get; set; }
		public string NonDtoText { get; set; }

		public Action<IFabNode> NodeAction { get; set; }

	}

}