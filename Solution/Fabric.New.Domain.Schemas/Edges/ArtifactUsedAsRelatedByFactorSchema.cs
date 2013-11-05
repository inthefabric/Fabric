using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class ArtifactUsedAsRelatedByFactor : EdgeSchema<ArtifactSchema, FactorSchema> {

		public EdgeProperty<FactorSchema, long> Timestamp { get; private set; }
		public EdgeProperty<FactorSchema, byte> DescriptorType { get; private set; }
		public EdgeProperty<FactorSchema, FactorUsesPrimaryArtifactSchema, long> PrimaryArtifactId
			{ get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactUsedAsRelatedByFactor() : base(EdgeQuantity.ZeroOrMore) {
			SetNames("UsedAsRelatedBy", "rb");
			CreateFromOtherDirection = true;

			Timestamp = Prop("Timestamp", "ts", (x => x.Timestamp));
			DescriptorType = Prop("DesdcriptorType", "dt", (x => x.DescriptorType));
			PrimaryArtifactId = PropFromEdge<FactorUsesPrimaryArtifactSchema>("PrimaryArtifactId","pa");
		}

	}

}