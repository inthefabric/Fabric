using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class UserDefinesMemberSchema : EdgeSchema<UserSchema, MemberSchema> {

		public EdgeProperty<MemberSchema, long> Timestamp { get; private set; }
		public EdgeProperty<MemberSchema, byte> MemberType { get; private set; }
		public EdgeProperty<MemberSchema, MemberDefinedByAppSchema, long> AppId { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UserDefinesMemberSchema() : base(EdgeQuantity.ZeroOrMore) {
			Names = new NameProvider("DefinesMember", "DefinesMembers", "dm");
			TypeName = "Defines";
			CreateFromOtherDirection = true;

			Timestamp = Prop("Timestamp", "dm.ts", (x => x.Timestamp));
			MemberType = Prop("MemberType", "dm.mt", (x => x.MemberType));
			AppId = Prop("AppId", "dm.ai", (x => x.DefinedByApp), (x => x.ToVertexId));
		}

	}

}