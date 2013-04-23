using System.Collections.Generic;
using Fabric.Api.Common;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Meta;
using Fabric.Api.Meta;
using Fabric.Api.Oauth.Tasks;
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

		private readonly FabMetaVersion vVers;
		private readonly Route vRoute;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MetaController(Request pRequest, IApiContext pApiCtx, FabMetaVersion pVers, 
						IOauthTasks pOauthTasks, Route pRoute) : base(pRequest, pApiCtx, pOauthTasks) {
			vVers = pVers;
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
					return NewFabJsonResponse(ServiceDtoJson);

				case Route.Spec:
					var getDoc = new GetSpec(vVers);
					return NewFabJsonResponse(getDoc.Go(ApiCtx));

				case Route.Version:
					var getVer = new GetVersion(vVers);
					var verList = new List<FabMetaVersion>();
					verList.Add(getVer.Go(ApiCtx));
					return NewFabJsonResponse(verList.ToJson());

				case Route.Time:
					var getTime = new GetTime();
					var timeList = new List<FabMetaTime>();
					timeList.Add(getTime.Go(ApiCtx));
					return NewFabJsonResponse(timeList.ToJson());
			}

			return null;
		}

	}

}