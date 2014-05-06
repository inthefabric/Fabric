using Fabric.Domain.Schemas.Vertices;

namespace Fabric.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class ArtifactUsesEmailSchema : EdgeSchema<ArtifactSchema, EmailSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactUsesEmailSchema() : base(EdgeQuantity.ZeroOrMore) {
			SetNames("Uses", "u");
			CreateFromOtherDirection = typeof(EmailUsedByArtifactSchema);
		}

	}

}