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
			Names = new NameProvider("CreatesFactor", "CreatesFactors", "cf");
			TypeName = "Creates";
			CreateFromOtherDirection = true;

			Timestamp = Prop("Timestamp", "cf.ts", (x => x.Timestamp));
			DescriptorType = Prop("DescriptorType", "cf.dt", (x => x.DescriptorType));
			PrimaryArtifactId = Prop("PrimaryArtifactId", "cf.pa",
				(x => x.UsesPrimaryArtifact), (x => x.ToVertexId));
			RelatedArtifactId = Prop("RelatedArtifactId", "cf.ra",
				(x => x.UsesRelatedArtifact), (x => x.ToVertexId));
		}

	}

}