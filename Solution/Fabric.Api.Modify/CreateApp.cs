using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Modify {

	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModAppsUri, typeof(FabApp))]
	public class CreateApp : BaseModifyFunc<App> {

		public const string NameParam = "Name";
		public const string UserIdParam = "UserId";

		[ServiceOpParam(ServiceOpParamType.Form, NameParam, typeof(App))]
		private readonly string vName;

		[ServiceOpParam(ServiceOpParamType.Form, UserIdParam, typeof(User))]
		private readonly long vUserId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateApp(IModifyTasks pTasks, string pName, long pUserId) : base(pTasks){
			vName = pName;
			vUserId = pUserId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			EnsureFabricSystem();
			Tasks.Validator.AppName(vName, NameParam);
			Tasks.Validator.UserId(vUserId, UserIdParam);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override App Execute() {
			if ( Tasks.GetAppByName(ApiCtx, vName) != null ) {
				throw new FabDuplicateFault(typeof(App), NameParam, vName);
			}

			////

			User user = Tasks.GetUser(ApiCtx, vUserId);

			if ( user == null ) {
				throw new FabNotFoundFault(typeof(User), UserIdParam+"="+vUserId);
			}

			////

			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<App> appVar;
			IWeaverVarAlias<Artifact> artVar;
			IWeaverVarAlias<Member> memVar;

			var txb = new TxBuilder();

			txb.GetRoot(out rootVar);
			Tasks.TxAddApp(ApiCtx, txb, vName, rootVar, user.UserId, out appVar);
			Tasks.TxAddDataProvMember(ApiCtx, txb, rootVar, appVar, user.UserId, out memVar);
			Tasks.TxAddArtifact<App, AppHasArtifact>(
				ApiCtx, txb, ArtifactTypeId.App, rootVar, appVar, memVar, out artVar);

			////
			
			txb.RegisterVarWithTxBuilder(appVar);
			return ApiCtx.DbSingle<App>("CreateAppTx", txb.Finish(appVar));
		}

	}

}