using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class AppDefinesMemberSchema : EdgeSchema<AppSchema, MemberSchema> {

		public EdgeProperty<MemberSchema, long> Timestamp { get; private set; }
		public EdgeProperty<MemberSchema, byte> MemberType { get; private set; }
		public EdgeProperty<MemberSchema, MemberDefinedByUserSchema, long> UserId { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AppDefinesMemberSchema() : base(EdgeQuantity.Many) {
			Names = new NameProvider("DefinesMember", "DefinesMembers", "dm");

			Timestamp = Prop("Timestamp", "dm.ts", (x => x.Timestamp));
			MemberType = Prop("MemberType", "dm.mt", (x => x.MemberType));
			UserId = Prop("UserId", "dm.ui", (x => x.DefinedByUser), (x => x.ToVertexId));
		}

	}

}