using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class ArtifactUsedAsPrimaryByFactor : EdgeSchema<ArtifactSchema, FactorSchema> {

		public EdgeProperty<long> Timestamp { get; private set; }
		public EdgeProperty<byte> DescriptorType { get; private set; }
		public EdgeProperty<long> RelatedArtifactId { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactUsedAsPrimaryByFactor() : base(EdgeQuantity.Many) {
			Names = new NameProvider("UsedAsPrimaryByFactor", "UsedAsPrimaryByFactors", "upbf");

			Timestamp = new EdgeProperty<long>("Timestamp", "upbf.ts", InVertex.Timestamp);
			DescriptorType = new EdgeProperty<byte>("Timestamp", "upbf.dt", InVertex.DescriptorType);
			RelatedArtifactId = new EdgeProperty<long>("RelatedArtifactId", "upbf.ra",
				InVertex.UsesRelatedArtifact.ToVertexId);
		}

	}

}