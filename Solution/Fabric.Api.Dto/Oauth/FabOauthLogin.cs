using Fabric.Infrastructure;

namespace Fabric.Api.Dto.Oauth {

	/*================================================================================================*/
	public class FabOauthLogin : IFabDto {

		[DtoProp("code")]
		public string Code { get; set; }

		[DtoProp("state")]
		public string State { get; set; }

		[DtoProp("error")]
		public string Error { get; set; }

		[DtoProp("error_description")]
		public string ErrorDesc { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		public bool ShowLoginPage { get; set; }

		/*--------------------------------------------------------------------------------------------* /
		public uint AppId { get; set; }
		public string AppName { get; set; }
		public uint LoggedUserId { get; set; }
		public string LoggedUserName { get; set; }
		public string LoginErrorText { get; set; }
		
		/*--------------------------------------------------------------------------------------------* /
		public FabOauthLoginScope Scope { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Fill(IDbDto pDbDto) {}

	}


	/*================================================================================================* /
	public class FabOauthLoginScope {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		public string Redirect { get; set; }
		public string Code { get; set; }

	}


	/*================================================================================================* /
	public class FabOauthLoginError {

	}*/

}