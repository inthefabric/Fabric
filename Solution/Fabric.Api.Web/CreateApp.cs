using System;
using Fabric.Api.Web.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Query;

namespace Fabric.Api.Web {

	/*================================================================================================*/
	public class CreateApp : BaseWebFunc<App> {

		public const string NameParam = "Name";
		public const string UserIdParam = "UserId";

		private readonly string vName;
		private readonly long vUserId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateApp(IWebTasks pTasks, string pName, long pUserId) : base(pTasks) {
			vName = pName;
			vUserId = pUserId;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			Tasks.Validator.AppName(vName, NameParam);
			Tasks.Validator.ArtifactId(vUserId, UserIdParam);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override App Execute() {
			if ( Tasks.GetAppByName(ApiCtx, vName) != null ) {
				throw new FabDuplicateFault(typeof(App), NameParam, vName);
			}

			////

			User user = ApiCtx.DbNodeById<User>(vUserId);

			if ( user == null ) {
				throw new FabNotFoundFault(typeof(User), UserIdParam+"="+vUserId);
			}

			////

			IWeaverVarAlias<App> appVar;
			IWeaverVarAlias<Member> memVar;
			Action<IWeaverVarAlias<Member>> setMemberCreates;

			var txb = new TxBuilder();

			Tasks.TxAddApp(ApiCtx, txb, vName, user.ArtifactId, out appVar, out setMemberCreates);
			Tasks.TxAddDataProvMember(ApiCtx, txb, appVar, user.ArtifactId, out memVar);
			setMemberCreates(memVar);

			////
			
			txb.RegisterVarWithTxBuilder(appVar);
			return ApiCtx.DbSingle<App>("CreateAppTx", txb.Finish(appVar));
		}

	}

}