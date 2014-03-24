using Fabric.Domain.Schemas.Utils;
using Fabric.Domain.Schemas.Vertices;

namespace Fabric.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class MemberAuthenticatedByOauthAccessSchema : EdgeSchema<MemberSchema, OauthAccessSchema> {

		public EdgeProperty<OauthAccessSchema, long, long> Timestamp { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberAuthenticatedByOauthAccessSchema() : base(EdgeQuantity.ZeroOrMore) {
			SetNames("AuthenticatedBy", "ab");
			CreateFromOtherDirection = typeof(OauthAccessAuthenticatesMemberSchema);
			Sort = SortType.Desc;

			Timestamp = Prop("Timestamp", "ts", (x => x.Timestamp), (x => x.FabTimestamp));
			Timestamp.SortIndex = 0;
		}

	}

}