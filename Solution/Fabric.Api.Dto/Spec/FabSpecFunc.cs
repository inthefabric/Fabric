using System;
using System.Collections.Generic;

namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class FabSpecFunc {

		public string Name { get; set; }
		public string Description { get; set; }
		public Type ReturnType { get; set; }
		public List<FabSpecFuncParam> ParameterList { get; set; }

	}

}