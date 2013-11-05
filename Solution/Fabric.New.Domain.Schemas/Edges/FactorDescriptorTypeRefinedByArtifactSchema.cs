using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class FactorDescriptorTypeRefinedByArtifactSchema : EdgeSchema<FactorSchema, ArtifactSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorDescriptorTypeRefinedByArtifactSchema() : base(EdgeQuantity.ZeroOrOne) {
			//TODO: set this (and other edges) to IsNullable=true
			Names = new NameProvider("DescriptorTypeRefinedByArtifact",
				"DescriptorTypeRefinedByArtifacts", "drba");
			TypeName = "DescriptorTypeRefinedBy";
			CreateToVertexId = Access.All;
			SubObjectOf = "FabDescriptor";
		}

	}

}