using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class MemberCreatesFactorSchema : EdgeSchema<MemberSchema, FactorSchema> {

		public EdgeProperty<FactorSchema, long> Timestamp { get; private set; }
		public EdgeProperty<FactorSchema, byte> DescriptorType { get; private set; }
		public EdgeProperty<FactorSchema, FactorUsesPrimaryArtifactSchema, long> PrimaryArtifactId
		{ get; private set; }
		public EdgeProperty<FactorSchema, FactorUsesRelatedArtifactSchema, long> RelatedArtifactId
		{ get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberCreatesFactorSchema() : base(EdgeQuantity.ZeroOrMore) {
			SetNames("Creates", "c");
			CreateFromOtherDirection = true;

			Timestamp = Prop("Timestamp", "ts", (x => x.Timestamp));
			DescriptorType = Prop("DescriptorType", "dt", (x => x.DescriptorType));
			PrimaryArtifactId = Prop("PrimaryArtifactId", "pa",
				(x => x.UsesPrimaryArtifact), (x => x.ToVertexId));
			RelatedArtifactId = Prop("RelatedArtifactId", "ra",
				(x => x.UsesRelatedArtifact), (x => x.ToVertexId));
		}

	}

}