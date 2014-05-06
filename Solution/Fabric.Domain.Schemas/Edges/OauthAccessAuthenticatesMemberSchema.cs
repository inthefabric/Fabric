using Fabric.Domain.Schemas.Vertices;

namespace Fabric.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class OauthAccessAuthenticatesMemberSchema : EdgeSchema<OauthAccessSchema, MemberSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessAuthenticatesMemberSchema() : base(EdgeQuantity.One) {
			SetNames("Authenticates", "a");
		}

	}

}