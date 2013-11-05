using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class MemberCreatesArtifactSchema : EdgeSchema<MemberSchema, ArtifactSchema> {

		public EdgeProperty<ArtifactSchema, long> Timestamp { get; private set; }
		public EdgeProperty<ArtifactSchema, byte> VertexType { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberCreatesArtifactSchema() : base(EdgeQuantity.ZeroOrMore) {
			SetNames("Creates", "c");
			CreateFromOtherDirection = true;

			Timestamp = Prop("Timestamp", "ts", (x => x.Timestamp));
			VertexType = Prop("VertexType", "vt", (x => x.VertexType));
		}

	}

}