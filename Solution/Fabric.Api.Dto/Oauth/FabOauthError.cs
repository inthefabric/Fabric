using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Oauth {

	/*================================================================================================*/
	public class FabOauthError : FabDto {

		[DtoProp("error")]
		public string Error { get; set; }

		[DtoProp("error_description")]
		public string ErrorDesc { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) { }

	}

}