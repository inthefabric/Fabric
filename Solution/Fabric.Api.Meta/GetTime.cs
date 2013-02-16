using Fabric.Api.Dto;
using Fabric.Api.Dto.Meta;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Meta {

	/*================================================================================================*/
	[ServiceOp(FabHome.MetaUri, FabHome.Get, FabHome.MetaTimeUri, typeof(FabMetaTime))]
	public class GetTime : ApiFunc<FabMetaTime> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {}

		/*--------------------------------------------------------------------------------------------*/
		protected override FabMetaTime Execute() {
			return new FabMetaTime();
		}

	}

}