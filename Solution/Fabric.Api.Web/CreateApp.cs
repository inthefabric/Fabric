using Fabric.Api.Modify.Tasks;
using Fabric.Api.Web.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Web {

	/*================================================================================================*/
	public class CreateApp : BaseWebFunc<App> {

		public const string NameParam = "Name";
		public const string UserIdParam = "UserId";

		[ServiceOpParam(ServiceOpParamType.Form, NameParam, 0, typeof(App))]
		private readonly string vName;

		[ServiceOpParam(ServiceOpParamType.Form, UserIdParam, 1, typeof(User))]
		private readonly long vUserId;

		private readonly IModifyTasks vModTasks;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateApp(IWebTasks pTasks, IModifyTasks pModTasks, string pName, long pUserId) : 
																						base(pTasks) {
			vModTasks = pModTasks;
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
			vModTasks.TxAddArtifact<App, AppHasArtifact>(
				ApiCtx, txb, ArtifactTypeId.App, rootVar, appVar, memVar, out artVar);

			////
			
			txb.RegisterVarWithTxBuilder(appVar);
			return ApiCtx.DbSingle<App>("CreateAppTx", txb.Finish(appVar));
		}

	}

}