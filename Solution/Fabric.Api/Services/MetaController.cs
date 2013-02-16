using Fabric.Api.Common;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Meta;
using Fabric.Api.Meta;
using Fabric.Infrastructure.Api;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Services {

	/*================================================================================================*/
	public class MetaController : FabResponseController {

		public enum Route {
			Home,
			Spec,
			Version,
			Time
		}

		private static FabService ServiceDto;
		private static string ServiceDtoJson;

		private readonly FabMetaVersion vVersion;
		private readonly Route vRoute;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MetaController(Request pRequest, IApiContext pApiCtx, FabMetaVersion pVersion, 
														Route pRoute) : base(pRequest, pApiCtx, null) {
			vVersion = pVersion;
			vRoute = pRoute;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildFabResponse() {
			if ( ServiceDto == null ) {
				ServiceDto = FabHome.NewMetaService(true);
				ServiceDtoJson = ServiceDto.ToJson();
			}

			switch ( vRoute ) {
				case Route.Home:
					return NewResponse(new FabRespJsonView(FabResp, ServiceDtoJson));

				case Route.Spec:
					var getDoc = new GetSpec(vVersion.Version);
					return NewResponse(new FabRespJsonView(FabResp, getDoc.Go(ApiCtx)));

				case Route.Version:
					var getVer = new GetVersion(vVersion);
					return NewResponse(new FabRespJsonView(FabResp, getVer.Go(ApiCtx).ToJson()));

				case Route.Time:
					var getTime = new GetTime();
					return NewResponse(new FabRespJsonView(FabResp, getTime.Go(ApiCtx).ToJson()));
			}

			return null;
		}

	}

}