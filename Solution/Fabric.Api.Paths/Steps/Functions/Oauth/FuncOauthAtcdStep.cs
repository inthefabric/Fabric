using System;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Paths.Steps.Functions.Oauth {
	
	/*================================================================================================*/
	[Func("AccessTokenClientDataProv", typeof(FabOauthAccess), ResxKey="OauthAtcd")]
	public class FuncOauthAtcdStep : FuncOauthAtccStep { //TEST: FuncOauthAtcdStep

		public const string DataProvUserIdName = "data_prov_userid";

		[FuncParam(DataProvUserIdName, FuncResxKey="OauthAt")]
		public string DataProvUserId { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncOauthAtcdStep(Path pPath) : base(pPath) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public new static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabOauth));
		}

	}

}