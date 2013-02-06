using System.Runtime.Serialization;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Oauth {

	/*================================================================================================*/
	[DataContract]
	public class FabOauthError : FabObject {

		[DataMember(Name="error")]
		[DtoProp("error")]
		public string Error { get; set; }

		[DataMember(Name="error_description")]
		[DtoProp("error_description")]
		public string ErrorDesc { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabOauthError ForInternalServerError() {
			var e = new FabOauthError();
			e.Error = "internal_error";
			e.ErrorDesc = "an+internal+server+error+occurred";
			return e;
		}


	}

}