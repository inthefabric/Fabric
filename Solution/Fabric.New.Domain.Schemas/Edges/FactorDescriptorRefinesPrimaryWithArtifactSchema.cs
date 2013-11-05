using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class FactorDescriptorRefinesPrimaryWithArtifactSchema : EdgeSchema<FactorSchema, ArtifactSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorDescriptorRefinesPrimaryWithArtifactSchema() : base(EdgeQuantity.ZeroOrOne) {
			SetNames("DescriptorRefinesPrimaryWith", "rp", "RefinesPrimaryWith");
			CreateToVertexId = Access.All;
			SubObjectOf = "FabDescriptor";
		}

	}

}