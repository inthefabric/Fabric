using System.Runtime.Serialization;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Oauth {

	/*================================================================================================*/
	[DataContract]
	public class FabOauthLogout : FabObject {

		[DataMember(Name="success")]
		[DtoProp("success")]
		public int Success { get; set; }

		[DataMember(Name="access_token")]
		[DtoProp("access_token")]
		public string AccessToken { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {}

	}

}