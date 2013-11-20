using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class MemberCreatesArtifactSchema : EdgeSchema<MemberSchema, ArtifactSchema> {

		public EdgeProperty<ArtifactSchema, long, long> Timestamp { get; private set; }
		public EdgeProperty<ArtifactSchema, byte, byte> VertexType { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberCreatesArtifactSchema() : base(EdgeQuantity.ZeroOrMore) {
			SetNames("Creates", "c");
			CreateFromOtherDirection = typeof(ArtifactCreatedByMemberSchema);

			////

			Timestamp = Prop("Timestamp", "ts", (x => x.Timestamp), (x => x.FabTimestamp));
			Timestamp.Sort = EdgeProperty.SortType.Desc;

			VertexType = Prop("VertexType", "vt", (x => x.VertexType), (x => x.FabVertexType));
		}

	}

}