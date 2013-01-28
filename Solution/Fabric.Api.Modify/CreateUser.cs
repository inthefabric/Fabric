using System.Collections.Generic;
using Fabric.Api.Modify.Results;
using Fabric.Api.Modify.Tasks;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	public class CreateUser : BaseModifyFunc<CreateUserResult> { //TEST: CreateUser
		
		private readonly string vEmail;
		private readonly string vName;
		private readonly string vPass;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateUser(IModifyTasks pTasks, string pName, string pPass, string pEmail) :base(pTasks){
			vEmail = pEmail;
			vName = pName;
			vPass = pPass;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			Tasks.Validator.UserName(vName);
			Tasks.Validator.UserPassword(vPass);
			Tasks.Validator.EmailAddress(vEmail);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override CreateUserResult Execute() {
			if ( Tasks.GetUserByName(Context, vName) != null ) {
				throw new FabDuplicateFault("Name", vName);
			}

			////

			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<Email> emailVar;
			IWeaverVarAlias<User> userVar;
			IWeaverVarAlias<Artifact> artVar;
			IWeaverVarAlias<Member> memVar;

			var txb = new TxBuilder();

			txb.GetRoot(out rootVar);
			Tasks.TxAddEmail(Context, txb, vEmail, rootVar, out emailVar);
			Tasks.TxAddUser(Context, txb, vName, vPass, rootVar, emailVar, out userVar);
			Tasks.TxAddMember(Context, txb, rootVar, userVar, out memVar);
			Tasks.TxAddArtifact<User, UserHasArtifact>(
				Context, txb, ArtifactTypeId.User, rootVar, userVar, memVar, out artVar);

			var list = new List<IWeaverVarAlias> { userVar, emailVar };
			IWeaverVarAlias listVar;
			WeaverTasks.InitListVar(txb.Transaction, list, out listVar);

			////

			IApiDataAccess data = Context.DbData("CreateUserTx", txb.Finish(listVar));
			
			var result = new CreateUserResult();
			result.NewUser = data.GetResultAt<User>(0);
			result.NewEmail = data.GetResultAt<Email>(1);
			return result;
		}

	}

}