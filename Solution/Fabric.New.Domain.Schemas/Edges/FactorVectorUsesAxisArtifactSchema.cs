using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class FactorVectorUsesAxisArtifactSchema : EdgeSchema<FactorSchema, ArtifactSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorVectorUsesAxisArtifactSchema() : base(EdgeQuantity.ZeroOrOne) {
			//TODO: Remove "Vector" from API naming
			Names = new NameProvider("VectorUsesAxisArtifact", "VectorUsesAxisArtifacts", "uaa");
			TypeName = "VectorUsesAxis";
			CreateToVertexId = Access.All;
			SubObjectOf = "FabVector";
		}

	}

}