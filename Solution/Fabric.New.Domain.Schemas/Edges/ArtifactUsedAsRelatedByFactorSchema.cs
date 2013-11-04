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
			Names = new NameProvider("UsedAsRelatedByFactor", "UsedAsRelatedByFactors", "urbf");
			TypeName = "UsedAsRelatedBy";
			CreateFromOtherDirection = true;

			Timestamp = Prop("Timestamp", "urbf.ts", (x => x.Timestamp));
			DescriptorType = Prop("DesdcriptorType", "urbf.dt", (x => x.DescriptorType));
			PrimaryArtifactId = Prop("PrimaryArtifactId", "urbf.pa",
				(x => x.UsesPrimaryArtifact), (x => x.ToVertexId));
		}

	}

}