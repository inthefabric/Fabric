﻿using System.Collections.Generic;
using Fabric.Infrastructure.Data;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public class FabService : FabObject {

		public string Name { get; set; }
		public string Uri { get; set; }
		public IList<FabServiceOperation> Operations { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabService() {
			Operations = new List<FabServiceOperation>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDataDto pDto) {}

	}

}