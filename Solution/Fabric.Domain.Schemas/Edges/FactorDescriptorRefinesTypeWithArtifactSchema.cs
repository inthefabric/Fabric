using Fabric.Domain.Schemas.Utils;
using Fabric.Domain.Schemas.Vertices;

namespace Fabric.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class FactorDescriptorRefinesTypeWithArtifactSchema : EdgeSchema<FactorSchema, ArtifactSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorDescriptorRefinesTypeWithArtifactSchema() : base(EdgeQuantity.ZeroOrOne) {
			SetNames("DescriptorRefinesTypeWith", "rt", "RefinesTypeWith");
			FabToVertexId.CreateAccess = Access.All;
			SubObjectOf = "FabDescriptor";
		}

	}

}