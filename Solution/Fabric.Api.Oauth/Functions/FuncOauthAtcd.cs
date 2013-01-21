using Fabric.Api.Dto.Oauth;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Oauth.Functions {
	
	/*================================================================================================*/
	[Func("AccessTokenClientDataProv", typeof(FabOauthAccess), ResxKey="OauthAtcd")]
	public class FuncOauthAtcd : FuncOauthAtcc {

		[FuncParam(FuncOauthAt.DataProvUserIdName, FuncResxKey="OauthAt")]
		public string DataProvUserId { get; private set; }

	}

}