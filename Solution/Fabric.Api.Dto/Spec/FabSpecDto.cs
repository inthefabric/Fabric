﻿using System.Collections.Generic;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class FabSpecDto : FabDto {

		public string Name { get; set; }
		public string Extends { get; set; }
		public string Description { get; set; }
		public List<FabSpecDtoProp> PropertyList { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabSpecDto() {
			PropertyList = new List<FabSpecDtoProp>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}