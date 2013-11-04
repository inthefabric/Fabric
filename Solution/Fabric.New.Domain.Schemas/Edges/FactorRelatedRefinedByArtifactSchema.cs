using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class FactorRelatedRefinedByArtifactSchema : EdgeSchema<FactorSchema, ArtifactSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorRelatedRefinedByArtifactSchema() : base(EdgeQuantity.ZeroOrOne) {
			Names = new NameProvider("RelatedRefinedByArtifact", "RelatedRefinedByArtifacts", "rrba");
			TypeName = "RelatedRefinedBy";
			CreateToVertexId = Access.All;
			SubObjectOf = "FabDescriptor";
		}

	}

}