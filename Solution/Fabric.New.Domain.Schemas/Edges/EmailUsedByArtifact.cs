using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class EmailUsedByArtifact : EdgeSchema<EmailSchema, ArtifactSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EmailUsedByArtifact() : base(EdgeQuantity.One) {
			SetNames("UsedBy", "b");
		}

	}

}