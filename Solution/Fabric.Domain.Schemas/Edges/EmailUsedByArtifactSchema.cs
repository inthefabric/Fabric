using Fabric.Domain.Schemas.Vertices;

namespace Fabric.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class EmailUsedByArtifactSchema : EdgeSchema<EmailSchema, ArtifactSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EmailUsedByArtifactSchema() : base(EdgeQuantity.One) {
			SetNames("UsedBy", "b");
		}

	}

}