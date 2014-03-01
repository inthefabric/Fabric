using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
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