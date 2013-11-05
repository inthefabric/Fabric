using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class FactorDescriptorRefinesRelatedWithArtifactSchema : EdgeSchema<FactorSchema, ArtifactSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorDescriptorRefinesRelatedWithArtifactSchema() : base(EdgeQuantity.ZeroOrOne) {
			SetNames("DescriptorRefinesRelatedWith", "rr", "RefinesRelatedWith");
			CreateToVertexId = Access.All;
			SubObjectOf = "FabDescriptor";
		}

	}

}