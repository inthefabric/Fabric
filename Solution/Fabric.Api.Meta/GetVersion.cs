using Fabric.Api.Dto;
using Fabric.Api.Dto.Meta;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Meta {

	/*================================================================================================*/
	[ServiceOp(FabHome.MetaUri, FabHome.Get, FabHome.MetaVersionUri, typeof(FabMetaVersion))]
	public class GetVersion : ApiFunc<FabMetaVersion> {

		private readonly FabMetaVersion vVersion;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GetVersion(FabMetaVersion pVersion) {
			vVersion = pVersion;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {}

		/*--------------------------------------------------------------------------------------------*/
		protected override FabMetaVersion Execute() {
			return vVersion;
		}

	}

}