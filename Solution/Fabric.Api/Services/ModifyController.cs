using System.Collections.Generic;
using Fabric.Api.Common;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Batch;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify;
using Fabric.Api.Modify.Tasks;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
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
			Classes,
			ClassesBatch,
			Descriptors,
			Directors,
			Eventors,
			Factors,
			Identors,
			Instances,
			Locators,
			Urls,
			Vectors
		}

		private static FabService ServiceDto;
		private static string ServiceDtoJson;

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
			return NewFabJsonResponse(GetRouteJson());
		}

		/*--------------------------------------------------------------------------------------------*/
		private string GetRouteJson() {
			switch ( vRoute ) {
				case Route.Home: return ServiceDtoJson;
				case Route.Classes: return Classes();
				case Route.ClassesBatch: return ClassesBatch();
				case Route.Descriptors: return Descriptors();
				case Route.Directors: return Directors();
				case Route.Eventors: return Eventors();
				case Route.Factors: return Factors();
				case Route.Identors: return Identors();
				case Route.Instances: return Instances();
				case Route.Locators: return Locators();
				case Route.Urls: return Urls();
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
		private string ToJsonList<T>(T pItem) where T : IFabNode {
			return new [] { pItem }.ToJson(); //return list for FabResponse<T>
		}

		/*--------------------------------------------------------------------------------------------*/
		private string ToBoolList(bool pResult) {
			return "{"+pResult.ToString().ToLower()+"}";
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabNotFoundFault BadRequest() {
			return new FabNotFoundFault(typeof(FabServiceOperation), NancyReq.Method+" "+NancyReq.Path);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string Classes() {
			switch ( NancyReq.Method ) {
				case "POST":
					Class c = new CreateClass(
						NewModTasks(),
						GetPostString(CreateClass.NameParam),
						GetPostString(CreateClass.DisambParam, false),
						GetPostString(CreateClass.NoteParam, false)
					)
					.Go(ApiCtx);
					return ToJsonList(new FabClass(c));
			}

			throw BadRequest();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private string ClassesBatch() {
			switch ( NancyReq.Method ) {
				case "POST":
					IList<FabBatchResult> results = new BatchCreateClass(
						NewModTasks(),
						GetPostString(BatchCreateClass.ClassesParam)
					)
					.Go(ApiCtx);
					return results.ToJson();
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Factors() {
			Factor f;
			
			switch ( NancyReq.Method ) {
				case "POST":
					f = new CreateFactor(
						NewModTasks(),
						GetPostLong(CreateFactor.PrimArtParam),
						GetPostLong(CreateFactor.RelArtParam),
						GetPostByte(CreateFactor.AssertParam),
						GetPostBool(CreateFactor.IsDefParam),
						GetPostString(CreateFactor.NoteParam, false)
					)
					.Go(ApiCtx);
					return ToJsonList(new FabFactor(f));

				case "PUT":
					f = new CompleteFactor(
						NewModTasks(),
						GetPostLong(UpdateFactor.FactorParam),
						GetPostBool(UpdateFactor.CompletedParam)
					)
					.Go(ApiCtx);
					return ToJsonList(new FabFactor(f));

				case "DELETE":
					f = new DeleteFactor(
						NewModTasks(),
						GetPostLong(UpdateFactor.FactorParam),
						GetPostBool(UpdateFactor.DeletedParam)
					)
					.Go(ApiCtx);
					return ToJsonList(new FabFactor(f));
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Descriptors() {
			switch ( NancyReq.Method ) {
				case "POST":
					bool result = new AttachDescriptor(
						NewModTasks(),
						GetPostLong(AttachFactorElement.FactorParam),
						GetPostByte(AttachDescriptor.DescTypeParam),
						GetPostLong(AttachDescriptor.PrimArtRefParam, false),
						GetPostLong(AttachDescriptor.RelArtRefParam, false),
						GetPostLong(AttachDescriptor.DescTypeRefParam, false)
					)
					.Go(ApiCtx);
					return ToBoolList(result);
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Directors() {
			switch ( NancyReq.Method ) {
				case "POST":
					bool result = new AttachDirector(
						NewModTasks(),
						GetPostLong(AttachFactorElement.FactorParam),
						GetPostByte(AttachDirector.DirTypeParam),
						GetPostByte(AttachDirector.PrimActionParam),
						GetPostByte(AttachDirector.RelActionParam)
					)
					.Go(ApiCtx);
					return ToBoolList(result);
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Eventors() {
			switch ( NancyReq.Method ) {
				case "POST":
					bool result = new AttachEventor(
						NewModTasks(),
						GetPostLong(AttachFactorElement.FactorParam),
						GetPostByte(AttachEventor.EveTypeParam),
						GetPostByte(AttachEventor.EvePrecParam),
						GetPostLong(AttachEventor.DateTimeParam)
					)
					.Go(ApiCtx);
					return ToBoolList(result);
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Identors() {
			switch ( NancyReq.Method ) {
				case "POST":
					bool result = new AttachIdentor(
						NewModTasks(),
						GetPostLong(AttachFactorElement.FactorParam),
						GetPostByte(AttachIdentor.IdenTypeParam),
						GetPostString(AttachIdentor.ValueParam)
					)
					.Go(ApiCtx);
					return ToBoolList(result);
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Instances() {
			switch ( NancyReq.Method ) {
				case "POST":
					Instance i = new CreateInstance(
						NewModTasks(),
						GetPostString(CreateInstance.NameParam, false),
						GetPostString(CreateInstance.DisambParam, false),
						GetPostString(CreateInstance.NoteParam, false)
					)
					.Go(ApiCtx);
					return ToJsonList(new FabInstance(i));
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Locators() {
			switch ( NancyReq.Method ) {
				case "POST":
					bool result = new AttachLocator(
						NewModTasks(),
						GetPostLong(AttachFactorElement.FactorParam),
						GetPostByte(AttachLocator.LocTypeParam),
						GetPostDouble(AttachLocator.XParam),
						GetPostDouble(AttachLocator.YParam),
						GetPostDouble(AttachLocator.ZParam)
					)
					.Go(ApiCtx);
					return ToBoolList(result);
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Urls() {
			switch ( NancyReq.Method ) {
				case "POST":
					Fabric.Domain.Url u = new CreateUrl(
						NewModTasks(),
						GetPostString(CreateUrl.AbsoluteUrlParam),
						GetPostString(CreateUrl.NameParam)
					)
					.Go(ApiCtx);
					return ToJsonList(new FabUrl(u));
			}

			throw BadRequest();
		}

		/*--------------------------------------------------------------------------------------------*/
		private string Vectors() {
			switch ( NancyReq.Method ) {
				case "POST":
					bool result = new AttachVector(
						NewModTasks(),
						GetPostLong(AttachFactorElement.FactorParam),
						GetPostByte(AttachVector.VecTypeParam),
						GetPostLong(AttachVector.ValueParam),
						GetPostLong(AttachVector.AxisArtParam),
						GetPostByte(AttachVector.UnitParam),
						GetPostByte(AttachVector.UnitPrefParam)
					)
					.Go(ApiCtx);
					return ToBoolList(result);
			}

			throw BadRequest();
		}

	}

}