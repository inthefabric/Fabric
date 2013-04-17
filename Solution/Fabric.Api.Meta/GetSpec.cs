using Fabric.Api.Dto;
using Fabric.Api.Dto.Meta;
using Fabric.Infrastructure.Api;
using ServiceStack.Text;

namespace Fabric.Api.Meta {

	/*================================================================================================*/
	[ServiceOp(FabHome.MetaUri, FabHome.Get, FabHome.MetaSpecUri, typeof(FabSpec))]
	public class GetSpec : ApiFunc<string> {

		private static FabSpec DocDto;
		private static string DocDtoJson;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GetSpec(string pBuildVers, long pBuildTime) {
			if ( DocDto == null ) {
				var doc = new SpecDoc();
				DocDto = doc.GetFabSpec();
				DocDto.BuildVersion = pBuildVers;
				DocDto.BuildTimestamp = pBuildTime;
				DocDtoJson = new [] { DocDto }.ToJson();
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {}

		/*--------------------------------------------------------------------------------------------*/
		protected override string Execute() {
			return DocDtoJson;
		}

	}

}