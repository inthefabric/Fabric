namespace Fabric.New.Api.Objects.Meta {

	/*================================================================================================*/
	public class FabSpecTravLink : FabObject {

		public string Name { get; set; }
		public string Type { get; set; }
		public string Description { get; set; }
		public bool IsOutgoing { get; set; }
		public string From { get; set; }
		public string FromConn { get; set; }
		public string Relation { get; set; }
		public string To { get; set; }
		public string ToConn { get; set; }

	}

}