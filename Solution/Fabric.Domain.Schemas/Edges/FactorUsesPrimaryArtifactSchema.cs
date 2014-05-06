using Fabric.Domain.Schemas.Utils;
using Fabric.Domain.Schemas.Vertices;

namespace Fabric.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class FactorUsesPrimaryArtifactSchema : EdgeSchema<FactorSchema, ArtifactSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorUsesPrimaryArtifactSchema() : base(EdgeQuantity.One) {
			SetNames("UsesPrimary", "p");
			FabToVertexId.CreateAccess = Access.All;
		}

	}

}