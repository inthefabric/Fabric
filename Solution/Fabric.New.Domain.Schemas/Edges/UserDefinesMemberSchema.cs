using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class UserDefinesMemberSchema : EdgeSchema<UserSchema, MemberSchema> {

		public EdgeProperty<MemberSchema, long, long> Timestamp { get; private set; }
		public EdgeProperty<MemberSchema, byte, byte> MemberType { get; private set; }
		public EdgeProperty<MemberSchema, MemberDefinedByAppSchema, long, long>
			AppId { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UserDefinesMemberSchema() : base(EdgeQuantity.ZeroOrMore) {
			SetNames("Defines", "d");
			CreateFromOtherDirection = typeof(MemberDefinedByUserSchema);

			////

			Timestamp = Prop("Timestamp", "ts", (x => x.Timestamp), (x => x.FabTimestamp));
			Timestamp.Sort = EdgeProperty.SortType.Desc;

			MemberType = Prop("MemberType", "mt", (x => x.MemberType), (x => x.FabMemberType));

			AppId = PropFromEdge<MemberDefinedByAppSchema>("AppId", "pi");
		}

	}

}