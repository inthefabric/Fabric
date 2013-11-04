using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class ArtifactUsedAsRelatedByFactor : EdgeSchema<ArtifactSchema, FactorSchema> {

		public EdgeProperty<long> Timestamp { get; private set; }
		public EdgeProperty<byte> DescriptorType { get; private set; }
		public EdgeProperty<long> PrimaryArtifactId { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactUsedAsRelatedByFactor() : base(EdgeQuantity.Many) {
			Names = new NameProvider("UsedAsRelatedByFactor", "UsedAsRelatedByFactors", "urbf");

			Timestamp = new EdgeProperty<long>("Timestamp", "urbf.ts", InVertex.Timestamp);
			DescriptorType = new EdgeProperty<byte>("DesdcriptorType", "urbf.dt", InVertex.DescriptorType);
			PrimaryArtifactId = new EdgeProperty<long>("PrimaryArtifactId", "urbf.pa",
				InVertex.UsesPrimaryArtifact.ToVertexId);
		}

	}

}