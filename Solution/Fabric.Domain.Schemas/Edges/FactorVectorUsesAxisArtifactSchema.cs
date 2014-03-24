using Fabric.Domain.Schemas.Utils;
using Fabric.Domain.Schemas.Vertices;

namespace Fabric.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class FactorVectorUsesAxisArtifactSchema : EdgeSchema<FactorSchema, ArtifactSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorVectorUsesAxisArtifactSchema() : base(EdgeQuantity.ZeroOrOne) {
			SetNames("VectorUsesAxis", "a", "UsesAxis");
			FabToVertexId.CreateAccess = Access.All;
			SubObjectOf = "FabVector";
		}

	}

}