using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
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

			////

			Timestamp = Prop("Timestamp", "ts", (x => x.Timestamp), (x => x.FabTimestamp));
			Timestamp.Sort = EdgeProperty.SortType.Desc;

			MemberType = Prop("MemberType", "mt", (x => x.MemberType), (x => x.FabMemberType));

			UserId = PropFromEdge<MemberDefinedByUserSchema>("UserId", "ui");
		}

	}

}