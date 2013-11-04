using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class MemberCreatesArtifactSchema : EdgeSchema<MemberSchema, ArtifactSchema> {

		public EdgeProperty<long> Timestamp { get; private set; }
		public EdgeProperty<byte> VertexType { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberCreatesArtifactSchema() : base(EdgeQuantity.Many) {
			Names = new NameProvider("CreatesArtifact", "CreatesArtifacts", "ca");

			Timestamp = new EdgeProperty<long>("Timestamp", "ca.ts", InVertex.Timestamp);
			VertexType = new EdgeProperty<byte>("VertexType", "ca.vt", InVertex.VertexType);
		}

	}

}