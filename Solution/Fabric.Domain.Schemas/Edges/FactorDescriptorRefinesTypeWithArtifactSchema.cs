using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
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