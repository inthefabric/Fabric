using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class FactorPrimaryRefinedByArtifactSchema : EdgeSchema<FactorSchema, ArtifactSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorPrimaryRefinedByArtifactSchema() : base(EdgeQuantity.ZeroOrOne) {
			Names = new NameProvider("PrimaryRefinedByArtifact", "PrimaryRefinedByArtifacts", "prba");
			TypeName = "PrimaryRefinedBy";
			CreateToVertexId = Access.All;
			SubObjectOf = "FabDescriptor";
		}

	}

}