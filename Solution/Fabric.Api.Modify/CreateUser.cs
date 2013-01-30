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
	public class CreateUser : BaseModifyFunc<CreateUserResult> {

		public const string EmailParam = "Email";
		public const string NameParam = "Name";
		public const string PasswordParam = "Password";

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
			EnsureFabricSystem();
			Tasks.Validator.EmailAddress(vEmail, EmailParam);
			Tasks.Validator.UserName(vName, NameParam);
			Tasks.Validator.UserPassword(vPass, PasswordParam);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override CreateUserResult Execute() {
			if ( Tasks.GetUserByName(ApiCtx, vName) != null ) {
				throw new FabDuplicateFault(typeof(User), NameParam, vName);
			}

			////

			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<Email> emailVar;
			IWeaverVarAlias<User> userVar;
			IWeaverVarAlias<Artifact> artVar;
			IWeaverVarAlias<Member> memVar;

			var txb = new TxBuilder();

			txb.GetRoot(out rootVar);
			Tasks.TxAddEmail(ApiCtx, txb, vEmail, rootVar, out emailVar);
			Tasks.TxAddUser(ApiCtx, txb, vName, vPass, rootVar, emailVar, out userVar);
			Tasks.TxAddMember(ApiCtx, txb, rootVar, userVar, out memVar);
			Tasks.TxAddArtifact<User, UserHasArtifact>(
				ApiCtx, txb, ArtifactTypeId.User, rootVar, userVar, memVar, out artVar);

			var list = new List<IWeaverVarAlias> { userVar, emailVar };
			IWeaverVarAlias listVar;
			
			txb.Transaction.AddQuery(
				WeaverTasks.InitListVar(txb.Transaction, list, out listVar)
			);

			////

			IApiDataAccess data = ApiCtx.DbData("CreateUserTx", txb.Finish());
			
			var result = new CreateUserResult();
			result.NewUser = data.GetResultAt<User>(0);
			result.NewEmail = data.GetResultAt<Email>(1);
			return result;
		}

	}

}