using System;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Paths.Steps.Functions.Oauth {
	
	/*================================================================================================*/
	[Func("AccessTokenClientDataProv", typeof(FabOauthAccess), ResxKey="OauthAtcd")]
	public class FuncOauthAtcdStep : FuncOauthAtccStep { //TEST: FuncOauthAtcdStep

		[FuncParam(FuncOauthAtStep.DataProvUserIdName, FuncResxKey="OauthAt")]
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