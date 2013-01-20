﻿using System.Collections.Generic;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class FabSpecDto : FabDto {

		public string Name { get; set; }
		public string Extends { get; set; }
		public string Description { get; set; }
		public List<FabSpecDtoProp> PropertyList { get; set; }
		public List<FabSpecDtoLink> LinkList { get; set; }
		public List<string> FunctionList { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabSpecDto() {
			PropertyList = new List<FabSpecDtoProp>();
			LinkList = new List<FabSpecDtoLink>();
			FunctionList = new List<string>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}