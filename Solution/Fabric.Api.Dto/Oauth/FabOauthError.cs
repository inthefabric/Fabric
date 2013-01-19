using System.Runtime.Serialization;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Oauth {

	/*================================================================================================*/
	[DataContract]
	public class FabOauthError : FabDto {

		[DataMember(Name="error")]
		[DtoProp("error")]
		public string Error { get; set; }

		[DataMember(Name="error_description")]
		[DtoProp("error_description")]
		public string ErrorDesc { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) { }

	}

}