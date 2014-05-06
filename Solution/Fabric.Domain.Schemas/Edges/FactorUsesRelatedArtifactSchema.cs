using Fabric.Domain.Schemas.Utils;
using Fabric.Domain.Schemas.Vertices;

namespace Fabric.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class FactorUsesRelatedArtifactSchema : EdgeSchema<FactorSchema, ArtifactSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorUsesRelatedArtifactSchema() : base(EdgeQuantity.One) {
			SetNames("UsesRelated", "r");
			FabToVertexId.CreateAccess = Access.All;
		}

	}

}