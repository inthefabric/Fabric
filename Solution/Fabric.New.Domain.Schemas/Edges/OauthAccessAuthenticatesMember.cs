using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class OauthAccessAuthenticatesMember : EdgeSchema<OauthAccessSchema, MemberSchema> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessAuthenticatesMember() : base(EdgeQuantity.One) {
			SetNames("Authenticates", "a");
		}

	}

}