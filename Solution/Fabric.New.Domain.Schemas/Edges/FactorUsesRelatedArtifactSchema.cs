using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class FactorUsesRelatedArtifactSchema : EdgeSchema<FactorSchema, ArtifactSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorUsesRelatedArtifactSchema() : base(EdgeQuantity.One) {
			Names = new NameProvider("UsesRelatedArtifact", "UsesRelatedArtifact", "ura");
			TypeName = "UsesRelated";
			CreateToVertexId = Access.All;
		}

	}

}