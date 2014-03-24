using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class MemberCreatesFactorSchema : EdgeSchema<MemberSchema, FactorSchema> {

		public EdgeProperty<FactorSchema, long, long> Timestamp { get; private set; }
		public EdgeProperty<FactorSchema, byte, byte> DescriptorType { get; private set; }
		public EdgeProperty<FactorSchema, FactorUsesPrimaryArtifactSchema, long, long>
			PrimaryArtifactId { get; private set; }
		public EdgeProperty<FactorSchema, FactorUsesRelatedArtifactSchema, long, long>
			RelatedArtifactId { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberCreatesFactorSchema() : base(EdgeQuantity.ZeroOrMore) {
			SetNames("Creates", "c");
			CreateFromOtherDirection = typeof(FactorCreatedByMemberSchema);
			Sort = SortType.Desc;

			////

			Timestamp = Prop("Timestamp", "ts", (x => x.Timestamp), (x => x.FabTimestamp));
			Timestamp.SortIndex = 0;

			DescriptorType = Prop("DescriptorType", "dt", (x => x.DescriptorType),
				(x => x.FabDescriptorType));
			DescriptorType.SortIndex = 1;
			
			PrimaryArtifactId = PropFromEdge<FactorUsesPrimaryArtifactSchema>("PrimaryArtifactId","pa");
			PrimaryArtifactId.SortIndex = 2;
			
			RelatedArtifactId = PropFromEdge<FactorUsesRelatedArtifactSchema>("RelatedArtifactId","ra");
			RelatedArtifactId.SortIndex = 3;
		}

	}

}