using Fabric.Api.Dto;
using Fabric.Api.Dto.Spec;
using Fabric.Infrastructure.Api;
using ServiceStack.Text;

namespace Fabric.Api.Spec {

	/*================================================================================================*/
	[ServiceOp(FabHome.SpecUri, FabHome.Get, FabHome.SpecDocUri, typeof(FabSpec))]
	public class GetDocument : ApiFunc<string> {

		private static FabSpec DocDto;
		private static string DocDtoJson;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GetDocument(string pApiVers) {
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