using Fabric.Domain.Schemas.Utils;
using Fabric.Domain.Schemas.Vertices;

namespace Fabric.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class FactorDescriptorRefinesPrimaryWithArtifactSchema : EdgeSchema<FactorSchema, ArtifactSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorDescriptorRefinesPrimaryWithArtifactSchema() : base(EdgeQuantity.ZeroOrOne) {
			SetNames("DescriptorRefinesPrimaryWith", "rp", "RefinesPrimaryWith");
			FabToVertexId.CreateAccess = Access.All;
			SubObjectOf = "FabDescriptor";
		}

	}

}