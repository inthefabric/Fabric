using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class UserDefinesMemberSchema : EdgeSchema<UserSchema, MemberSchema> {

		public EdgeProperty<long> Timestamp { get; private set; }
		public EdgeProperty<byte> MemberType { get; private set; }
		public EdgeProperty<long> AppId { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UserDefinesMemberSchema() : base(EdgeQuantity.Many) {
			Names = new NameProvider("DefinesMember", "DefinesMembers", "dm");

			Timestamp = new EdgeProperty<long>("Timestamp", "dm.ts", InVertex.Timestamp);
			MemberType = new EdgeProperty<byte>("MemberType", "dm.mt", InVertex.MemberType);
			AppId = new EdgeProperty<long>("AppId", "dm.ai", InVertex.DefinedByApp.ToVertexId);
		}

	}

}