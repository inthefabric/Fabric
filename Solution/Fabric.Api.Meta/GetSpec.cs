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
		public GetSpec(string pApiVers) {
			if ( DocDto == null ) {
				var doc = new SpecDoc();
				DocDto = doc.GetFabSpec();
				DocDto.ApiVersion = pApiVers;
				DocDtoJson = DocDto.ToJson();
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