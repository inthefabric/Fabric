using Fabric.Api.Common;
using Fabric.Api.Dto;
using Fabric.Api.Modify;
using Fabric.Api.Modify.Tasks;
using Fabric.Api.Oauth.Tasks;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Nancy;
using ServiceStack.Text;

namespace Fabric.Api.Services {

	/*================================================================================================*/
	public class ModifyController : FabResponseController {

		//NOTE: controller routing could be improved. For example, create a static ...
		//Dictionary<string, Func<string>> where the key is "METHOD /service/operation",
		//then just execute the Func<string> to get the data. Update methods to be
		//like AppsPost, FactorsPut, and FactorsDelete.

		public enum Route {
			Home,
			Apps,
			Classes,
			Descriptors,
			Directors,
			Eventors,
			Factors,
			Identors,
			Instances,
			Locators,
			Urls,
			Users,
			Vectors
		}

		private static FabService ServiceDto;
		private static string ServiceDtoJson;
		//private static Dictionary<string, Func<string>> RouteMap;

		private readonly Route vRoute;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ModifyController(Request pRequest, IApiContext pApiCtx, IOauthTasks pOauthTasks,
												Route pRoute) : base(pRequest, pApiCtx, pOauthTasks) {
			vRoute = pRoute;

			if ( ServiceDto == null ) {
				ServiceDto = FabHome.NewModifyService(true);
				ServiceDtoJson = ServiceDto.ToJson();
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Response BuildFabResponse() {
			return NewResponse(new FabRespJsonView(FabResp, GetRouteJson()));
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GetRouteJson() {
			switch ( vRoute ) {
				case Route.Home: return ServiceDtoJson;
				case Route.Apps: return Apps();
				case Route.Classes: return Classes();
				case Route.Descriptors: return Descriptors();
				case Route.Directors: return Directors();
				case Route.Eventors: return Eventors();
				case Route.Factors: return Factors();
				case Route.Identors: return Identors();
				case Route.Instances: return Instances();
				case Route.Locators: return Locators();
				case Route.Urls: return Urls();
				case Route.Users: return Users();
				case Route.Vectors: return Vectors();
				default: return "";
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static ModifyTasks NewModTasks() {
			return new ModifyTasks();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string FuncGo<T>(IApiFunc<T> pFunc) {
			return pFunc.Go(ApiCtx).ToJson();
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabNotFoundFault BadRequest() {
			return new FabNotFoundFault(typeof(FabServiceOperation), NancyReq.Method+" "+NancyReq.Path);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string Apps() {
			switch ( NancyReq.Method ) {
				case "POST":
					return FuncGo(new CreateApp(
						NewModTasks(),
						GetPostString(CreateApp.NameParam),
						GetPostLong(CreateApp.UserIdParam)
					));
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Classes() {
			switch ( NancyReq.Method ) {
				case "POST":
					return FuncGo(new CreateClass(
						NewModTasks(),
						GetPostString(CreateClass.NameParam),
						GetPostString(CreateClass.DisambParam, false),
						GetPostString(CreateClass.NoteParam, false)
					));
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Factors() {
			switch ( NancyReq.Method ) {
				case "POST":
					return FuncGo(new CreateFactor(
						NewModTasks(),
						GetPostLong(CreateFactor.PrimArtParam),
						GetPostLong(CreateFactor.RelArtParam),
						GetPostLong(CreateFactor.AssertParam),
						GetPostBool(CreateFactor.IsDefParam),
						GetPostString(CreateFactor.NoteParam, false)
					));

				case "PUT":
					return FuncGo(new CompleteFactor(
						NewModTasks(),
						GetPostLong(UpdateFactor.FactorParam),
						GetPostBool(UpdateFactor.CompletedParam)
					));

				case "DELETE":
					return FuncGo(new DeleteFactor(
						NewModTasks(),
						GetPostLong(UpdateFactor.FactorParam),
						GetPostBool(UpdateFactor.DeletedParam)
					));
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Descriptors() {
			switch ( NancyReq.Method ) {
				case "POST":
					return FuncGo(new CreateDescriptor(
						NewModTasks(),
						GetPostLong(CreateFactorElement.FactorParam),
						GetPostLong(CreateDescriptor.DescTypeParam),
						GetPostLong(CreateDescriptor.PrimArtRefParam, false),
						GetPostLong(CreateDescriptor.RelArtRefParam, false),
						GetPostLong(CreateDescriptor.DescTypeRefParam, false)
					));
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Directors() {
			switch ( NancyReq.Method ) {
				case "POST":
					return FuncGo(new CreateDirector(
						NewModTasks(),
						GetPostLong(CreateFactorElement.FactorParam),
						GetPostLong(CreateDirector.DirTypeParam),
						GetPostLong(CreateDirector.PrimActionParam),
						GetPostLong(CreateDirector.RelActionParam)
					));
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Eventors() {
			switch ( NancyReq.Method ) {
				case "POST":
					return FuncGo(new CreateEventor(
						NewModTasks(),
						GetPostLong(CreateFactorElement.FactorParam),
						GetPostLong(CreateEventor.EveTypeParam),
						GetPostLong(CreateEventor.EvePrecParam),
						GetPostLong(CreateEventor.DateTimeParam)
					));
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Identors() {
			switch ( NancyReq.Method ) {
				case "POST":
					return FuncGo(new CreateIdentor(
						NewModTasks(),
						GetPostLong(CreateFactorElement.FactorParam),
						GetPostLong(CreateIdentor.IdenTypeParam),
						GetPostString(CreateIdentor.ValueParam)
					));
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Instances() {
			switch ( NancyReq.Method ) {
				case "POST":
					return FuncGo(new CreateInstance(
						NewModTasks(),
						GetPostString(CreateInstance.NameParam, false),
						GetPostString(CreateInstance.DisambParam, false),
						GetPostString(CreateInstance.NoteParam, false)
					));
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Locators() {
			switch ( NancyReq.Method ) {
				case "POST":
					return FuncGo(new CreateLocator(
						NewModTasks(),
						GetPostLong(CreateFactorElement.FactorParam),
						GetPostLong(CreateLocator.LocTypeParam),
						GetPostDouble(CreateLocator.XParam),
						GetPostDouble(CreateLocator.YParam),
						GetPostDouble(CreateLocator.ZParam)
					));
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Urls() {
			switch ( NancyReq.Method ) {
				case "POST":
					return FuncGo(new CreateUrl(
						NewModTasks(),
						GetPostString(CreateUrl.AbsoluteUrlParam),
						GetPostString(CreateUrl.NameParam)
					));
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Users() {
			switch ( NancyReq.Method ) {
				case "POST":
					return FuncGo(new CreateUser(
						NewModTasks(),
						GetPostString(CreateUser.NameParam),
						GetPostString(CreateUser.PasswordParam),
						GetPostString(CreateUser.EmailParam)
					));
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Vectors() {
			switch ( NancyReq.Method ) {
				case "POST":
					return FuncGo(new CreateVector(
						NewModTasks(),
						GetPostLong(CreateFactorElement.FactorParam),
						GetPostLong(CreateVector.VecTypeParam),
						GetPostLong(CreateVector.ValueParam),
						GetPostLong(CreateVector.AxisArtParam),
						GetPostLong(CreateVector.UnitParam),
						GetPostLong(CreateVector.UnitPrefParam)
					));
			}

			throw BadRequest();
		}

	}

}