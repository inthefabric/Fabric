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
		public ArtifactUsedAsPrimaryByFactor() : base(EdgeQuantity.ZeroOrMore) {
			SetNames("UsedAsPrimaryBy", "pb");
			CreateFromOtherDirection = typeof(FactorUsesPrimaryArtifactSchema);

			Timestamp = Prop("Timestamp", "ts", (x => x.Timestamp));
			DescriptorType = Prop("DesdcriptorType", "dt", (x => x.DescriptorType));
			RelatedArtifactId = PropFromEdge<FactorUsesRelatedArtifactSchema>("RelatedArtifactId","ra");
		}

	}

}