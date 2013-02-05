using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Dto.Traversal {

	/*================================================================================================*/
	public class FabStepLink : FabDto {
		
		public bool IsOut { get; set; }
		public string Rel { get; set; }
		public string Class { get; set; }
		public string Uri { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabStepLink() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabStepLink(IStepLink pLink) {
			IsOut = pLink.IsOutgoing;
			Rel = pLink.RelType;
			Class = "Fab"+pLink.Node;
			Uri = pLink.Uri;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) { }

	}

}