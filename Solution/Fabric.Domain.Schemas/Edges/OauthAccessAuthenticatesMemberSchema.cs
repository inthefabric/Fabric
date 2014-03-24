using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class OauthAccessAuthenticatesMemberSchema : EdgeSchema<OauthAccessSchema, MemberSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessAuthenticatesMemberSchema() : base(EdgeQuantity.One) {
			SetNames("Authenticates", "a");
		}

	}

}