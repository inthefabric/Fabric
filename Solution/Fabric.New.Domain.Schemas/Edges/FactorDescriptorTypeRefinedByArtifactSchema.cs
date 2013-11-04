using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class FactorDescriptorTypeRefinedByArtifactSchema : EdgeSchema<FactorSchema, ArtifactSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorDescriptorTypeRefinedByArtifactSchema() : base(EdgeQuantity.ZeroOrOne) {
			Names = new NameProvider("DescriptorTypeRefinedByArtifact",
				"DescriptorTypeRefinedByArtifacts", "drba");
		}

	}

}