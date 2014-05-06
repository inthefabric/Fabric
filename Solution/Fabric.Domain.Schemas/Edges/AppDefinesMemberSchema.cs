using Fabric.Domain.Schemas.Utils;
using Fabric.Domain.Schemas.Vertices;

namespace Fabric.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class AppDefinesMemberSchema : EdgeSchema<AppSchema, MemberSchema> {

		public EdgeProperty<MemberSchema, long, long> Timestamp { get; private set; }
		public EdgeProperty<MemberSchema, byte, byte> MemberType { get; private set; }
		public EdgeProperty<MemberSchema, MemberDefinedByUserSchema, long, long> 
			UserId { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AppDefinesMemberSchema() : base(EdgeQuantity.ZeroOrMore) {
			SetNames("Defines", "d");
			CreateFromOtherDirection = typeof(MemberDefinedByAppSchema);
			Sort = SortType.Desc;

			////

			Timestamp = Prop("Timestamp", "ts", (x => x.Timestamp), (x => x.FabTimestamp));
			Timestamp.SortIndex = 0;

			MemberType = Prop("MemberType", "mt", (x => x.MemberType), (x => x.FabMemberType));
			MemberType.SortIndex = 1;

			UserId = PropFromEdge<MemberDefinedByUserSchema>("UserId", "ui");
			UserId.SortIndex = 2;
		}

	}

}