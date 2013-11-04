using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class FactorUsesPrimaryArtifactSchema : EdgeSchema<FactorSchema, ArtifactSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorUsesPrimaryArtifactSchema() : base(EdgeQuantity.One) {
			Names = new NameProvider("UsesPrimaryArtifact", "UsesPrimaryArtifact", "upa");
			TypeName = "UsesPrimary";
			CreateToVertexId = Access.All;
		}

	}

}