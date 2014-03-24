using Fabric.Domain.Schemas.Utils;
using Fabric.Domain.Schemas.Vertices;

namespace Fabric.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class MemberCreatesArtifactSchema : EdgeSchema<MemberSchema, ArtifactSchema> {

		public EdgeProperty<ArtifactSchema, long, long> Timestamp { get; private set; }
		public EdgeProperty<ArtifactSchema, byte, byte> VertexType { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberCreatesArtifactSchema() : base(EdgeQuantity.ZeroOrMore) {
			SetNames("Creates", "c");
			CreateFromOtherDirection = typeof(ArtifactCreatedByMemberSchema);
			Sort = SortType.Desc;

			////

			Timestamp = Prop("Timestamp", "ts", (x => x.Timestamp), (x => x.FabTimestamp));
			Timestamp.SortIndex = 0;

			VertexType = Prop("VertexType", "vt", (x => x.VertexType), (x => x.FabVertexType));
			VertexType.SortIndex = 1;
		}

	}

}