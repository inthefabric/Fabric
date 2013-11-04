using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class ArtifactUsedAsPrimaryByFactor : EdgeSchema<ArtifactSchema, FactorSchema> {

		public EdgeProperty<FactorSchema, long> Timestamp { get; private set; }
		public EdgeProperty<FactorSchema, byte> DescriptorType { get; private set; }
		public EdgeProperty<FactorSchema, FactorUsesRelatedArtifactSchema, long> RelatedArtifactId
			{ get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactUsedAsPrimaryByFactor() : base(EdgeQuantity.Many) {
			Names = new NameProvider("UsedAsPrimaryByFactor", "UsedAsPrimaryByFactors", "upbf");

			Timestamp = Prop("Timestamp", "upbf.ts", (x => x.Timestamp));
			DescriptorType = Prop("DesdcriptorType", "upbf.dt", (x => x.DescriptorType));
			RelatedArtifactId = Prop("RelatedArtifactId", "upbf.ra",
				(x => x.UsesRelatedArtifact), (x => x.ToVertexId));
		}

	}

}