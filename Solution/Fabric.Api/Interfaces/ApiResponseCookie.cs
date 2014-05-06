using System;

namespace Fabric.Api.Interfaces {

	/*================================================================================================*/
	public class ApiResponseCookie {

		public string Name { get; set; }
		public string Value { get; set; }
		public TimeSpan Expires { get; set; }

	}

}