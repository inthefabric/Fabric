using Fabric.Domain.Schemas.Utils;
using Fabric.Domain.Schemas.Vertices;

namespace Fabric.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class ArtifactUsedAsRelatedByFactor : EdgeSchema<ArtifactSchema, FactorSchema> {

		public EdgeProperty<FactorSchema, long, long> Timestamp { get; private set; }
		public EdgeProperty<FactorSchema, byte, byte> DescriptorType { get; private set; }
		public EdgeProperty<FactorSchema, FactorUsesPrimaryArtifactSchema, long, long>
			PrimaryArtifactId { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactUsedAsRelatedByFactor() : base(EdgeQuantity.ZeroOrMore) {
			SetNames("UsedAsRelatedBy", "rb");
			CreateFromOtherDirection = typeof(FactorUsesRelatedArtifactSchema);
			Sort = SortType.Desc;

			////

			Timestamp = Prop("Timestamp", "ts", (x => x.Timestamp), (x => x.FabTimestamp));
			Timestamp.SortIndex = 0;

			DescriptorType = Prop("DescriptorType", "dt", (x => x.DescriptorType),
				(x => x.FabDescriptorType));
			DescriptorType.SortIndex = 1;

			PrimaryArtifactId = PropFromEdge<FactorUsesPrimaryArtifactSchema>("PrimaryArtifactId","pa");
			PrimaryArtifactId.SortIndex = 2;
		}

	}

}