using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class ArtifactUsedAsPrimaryByFactor : EdgeSchema<ArtifactSchema, FactorSchema> {

		public EdgeProperty<FactorSchema, long, long> Timestamp { get; private set; }
		public EdgeProperty<FactorSchema, byte, byte> DescriptorType { get; private set; }
		public EdgeProperty<FactorSchema, FactorUsesRelatedArtifactSchema, long, long> 
			RelatedArtifactId { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactUsedAsPrimaryByFactor() : base(EdgeQuantity.ZeroOrMore) {
			SetNames("UsedAsPrimaryBy", "pb");
			CreateFromOtherDirection = typeof(FactorUsesPrimaryArtifactSchema);
			Sort = SortType.Desc;

			////

			Timestamp = Prop("Timestamp", "ts", (x => x.Timestamp), (x => x.FabTimestamp));
			Timestamp.SortIndex = 0;

			DescriptorType = Prop("DescriptorType", "dt", (x => x.DescriptorType),
				(x => x.FabDescriptorType));
			DescriptorType.SortIndex = 1;
			
			RelatedArtifactId = PropFromEdge<FactorUsesRelatedArtifactSchema>("RelatedArtifactId","ra");
			RelatedArtifactId.SortIndex = 2;
		}

	}

}