using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth.Operations {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.OauthUri, FabHome.Get, FabHome.OauthAccessTokenClientDataProvUri,
		typeof(FabOauthAccess), ResxKey="AccessToken")]
	public class OperOauthAtcd : OperOauthAtcc {

		[ServiceOpParam(ServiceOpParamType.Query, OperOauthAt.DataProvUserIdParam, 4, typeof(User),
			DomainPropertyName="UserId", ResxKey="DataProvUserId")]
		public string DataProvUserId;

	}

}