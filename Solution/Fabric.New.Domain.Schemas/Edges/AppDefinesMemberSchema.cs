using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class AppDefinesMemberSchema : EdgeSchema<AppSchema, MemberSchema> {

		public EdgeProperty<long> Timestamp { get; private set; }
		public EdgeProperty<byte> MemberType { get; private set; }
		public EdgeProperty<long> UserId { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AppDefinesMemberSchema() : base(EdgeQuantity.Many) {
			Names = new NameProvider("DefinesMember", "DefinesMembers", "dm");

			Timestamp = new EdgeProperty<long>("Timestamp", "dm.ts", InVertex.Timestamp);
			MemberType = new EdgeProperty<byte>("MemberType", "dm.mt", InVertex.MemberType);
			UserId = new EdgeProperty<long>("UserId", "dm.ui", InVertex.DefinedByUser.ToVertexId);
		}

	}

}