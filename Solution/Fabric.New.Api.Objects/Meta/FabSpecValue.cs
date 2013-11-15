namespace Fabric.New.Api.Objects.Meta {

	/*================================================================================================*/
	public class FabSpecValue : FabObject {

		public string Name { get; set; }
		public string Type { get; set; }
		public string Description { get; set; }

		public bool? IsOptional { get; set; }
		public int? LenMax { get; set; }
		public int? LenMin { get; set; }
		//public long? Min { get; set; }
		//public long? Max { get; set; }
		public string ValidRegex { get; set; }

	}

}