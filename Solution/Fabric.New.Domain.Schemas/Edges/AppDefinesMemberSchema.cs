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
		public AppDefinesMemberSchema() : base(EdgeQuantity.ZeroOrMore) {
			SetNames("Defines", "d");
			CreateFromOtherDirection = true;

			Timestamp = Prop("Timestamp", "ts", (x => x.Timestamp));
			MemberType = Prop("MemberType", "mt", (x => x.MemberType));
			UserId = Prop("UserId", "ui", (x => x.DefinedByUser), (x => x.ToVertexId));
		}

	}

}