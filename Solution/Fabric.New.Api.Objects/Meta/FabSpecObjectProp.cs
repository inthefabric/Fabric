﻿namespace Fabric.New.Api.Objects.Meta {

	/*================================================================================================*/
	public class FabSpecObjectProp : FabSpecValue {

		public string Enum { get; set; }
		public bool? IsCaseInsensitive { get; set; }
		public bool? ToLowerCase { get; set; }
		public bool? IsNullable { get; set; }
		public bool? IsPrimaryKey { get; set; }
		public bool? IsTimestamp { get; set; }
		public bool? IsUnique { get; set; }

	}

}