using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
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

			////

			Timestamp = Prop("Timestamp", "ts", (x => x.Timestamp), (x => x.FabTimestamp));
			Timestamp.Sort = EdgeProperty.SortType.Desc;

			DescriptorType = Prop("DescriptorType", "dt", (x => x.DescriptorType),
				(x => x.FabDescriptorType));

			PrimaryArtifactId = PropFromEdge<FactorUsesPrimaryArtifactSchema>("PrimaryArtifactId","pa");
		}

	}

}