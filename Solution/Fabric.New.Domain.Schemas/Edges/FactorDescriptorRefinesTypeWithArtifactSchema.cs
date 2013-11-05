using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class FactorDescriptorRefinesTypeWithArtifactSchema : EdgeSchema<FactorSchema, ArtifactSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorDescriptorRefinesTypeWithArtifactSchema() : base(EdgeQuantity.ZeroOrOne) {
			//TODO: set this (and other edges) to IsNullable=true
			SetNames("DescriptorRefinesTypeWith", "rt", "RefinesTypeWith");
			CreateToVertexId = Access.All;
			SubObjectOf = "FabDescriptor";
		}

	}

}