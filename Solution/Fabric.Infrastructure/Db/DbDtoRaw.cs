using System.Collections.Generic;

namespace Fabric.Infrastructure.Db {

	/*================================================================================================*/
	public class DbDtoRaw {

		// ReSharper disable InconsistentNaming

		public string _id { get; set; }
		public string _type { get; set; }
		public string _label { get; set; }
		public string _outV { get; set; }
		public string _inV { get; set; }
		public IDictionary<string, string> _properties { get; set; }

		// ReSharper restore InconsistentNaming

	}

}