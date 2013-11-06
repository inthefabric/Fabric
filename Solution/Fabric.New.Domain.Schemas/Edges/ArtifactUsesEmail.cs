using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class ArtifactUsesEmail : EdgeSchema<ArtifactSchema, EmailSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactUsesEmail() : base(EdgeQuantity.ZeroOrMore) {
			SetNames("Uses", "u");
			CreateFromOtherDirection = typeof(EmailUsedByArtifact);
		}

	}

}