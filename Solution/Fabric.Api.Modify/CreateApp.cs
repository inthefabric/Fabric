using Fabric.Api.Modify.Tasks;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	public class CreateApp : BaseModifyFunc<App> {

		public const string NameParam = "Name";
		public const string UserIdParam = "UserId";

		private readonly string vName;
		private readonly long vUserId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateApp(IModifyTasks pTasks, string pName, long pUserId) :base(pTasks){
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
			if ( Tasks.GetAppByName(Context, vName) != null ) {
				throw new FabDuplicateFault(typeof(App), NameParam, vName);
			}

			////

			User user = Tasks.GetUser(Context, vUserId);

			if ( user == null ) {
				throw new FabNotFoundFault(typeof(User).Name);
			}

			////

			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<App> appVar;
			IWeaverVarAlias<Artifact> artVar;
			IWeaverVarAlias<Member> memVar;

			var txb = new TxBuilder();

			txb.GetRoot(out rootVar);
			Tasks.TxAddApp(Context, txb, vName, rootVar, user.UserId, out appVar);
			Tasks.TxAddDataProvMember(Context, txb, rootVar, appVar, user.UserId, out memVar);
			Tasks.TxAddArtifact<App, AppHasArtifact>(
				Context, txb, ArtifactTypeId.App, rootVar, appVar, memVar, out artVar);

			////

			return Context.DbSingle<App>("CreateAppTx", txb.Finish(appVar));
		}

	}

}