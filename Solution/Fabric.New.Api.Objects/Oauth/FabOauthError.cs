using System.Runtime.Serialization;

namespace Fabric.New.Api.Objects.Oauth {

	/*================================================================================================*/
	[DataContract]
	public class FabOauthError : FabObject {

		[DataMember(Name="error")]
		public string Error { get; set; }

		[DataMember(Name="error_description")]
		public string ErrorDesc { get; set; }


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