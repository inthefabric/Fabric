namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class SpecProperty {

		public string Name { get; set; }
		public string Type { get; set; }
		public string Description { get; set; }

		public bool? IsCaseInsensitive { get; set; }
		public bool? IsNullable { get; set; }
		public bool? IsPrimaryKey { get; set; }
		public bool? IsTimestamp { get; set; }
		public bool? IsUnique { get; set; }

		public int? Len { get; set; }
		public int? LenMax { get; set; }
		public int? LenMin { get; set; }
		public string ValidRegex { get; set; }

	}

}