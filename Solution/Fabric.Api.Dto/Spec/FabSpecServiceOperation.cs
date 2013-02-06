﻿using System.Collections.Generic;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class FabSpecServiceOperation : FabObject {

		public string Name { get; set; }
		public string Uri { get; set; }
		public string Method { get; set; }
		public string ReturnType { get; set; }
		public string Description { get; set; }

		public string RequiredAuth { get; set; }
		public string AuthMemberOwns { get; set; }
		public List<FabSpecServiceOperationParam> Parameters { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}