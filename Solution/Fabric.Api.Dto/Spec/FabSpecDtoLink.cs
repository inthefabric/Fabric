namespace Fabric.Api.Dto.Spec {

	/*================================================================================================*/
	public class FabSpecDtoLink {

		public string Name { get; set; }
		public bool IsOutgoing { get; set; }
		public string FromDto { get; set; }
		public string FromDtoConn { get; set; }
		public string Verb { get; set; }
		public string ToDto { get; set; }
		public string ToDtoConn { get; set; }

	}

}