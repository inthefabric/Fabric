using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class EmailUsedByArtifactSchema : EdgeSchema<EmailSchema, ArtifactSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EmailUsedByArtifactSchema() : base(EdgeQuantity.One) {
			SetNames("UsedBy", "b");
		}

	}

}