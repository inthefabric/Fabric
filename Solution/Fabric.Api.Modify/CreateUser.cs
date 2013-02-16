using System.Collections.Generic;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
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
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModUsersUri, typeof(FabUser),
		Auth=ServiceAuthType.Fabric)]
	public class CreateUser : BaseModifyFunc<CreateUserResult> {

		public const string NameParam = "Name";
		public const string PasswordParam = "Password";
		public const string EmailParam = "Email";

		[ServiceOpParam(ServiceOpParamType.Form, NameParam, 0, typeof(User))]
		private readonly string vName;

		[ServiceOpParam(ServiceOpParamType.Form, PasswordParam, 1, typeof(User))]
		private readonly string vPass;

		[ServiceOpParam(ServiceOpParamType.Form, EmailParam, 2, typeof(Email),
			DomainPropertyName="Address")]
		private readonly string vEmail;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateUser(IModifyTasks pTasks, string pName, string pPass, string pEmail) :base(pTasks){
			vName = pName;
			vPass = pPass;
			vEmail = pEmail;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			EnsureFabricSystem();
			Tasks.Validator.UserName(vName, NameParam);
			Tasks.Validator.UserPassword(vPass, PasswordParam);
			Tasks.Validator.EmailAddress(vEmail, EmailParam);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override CreateUserResult Execute() {
			if ( Tasks.GetUserByName(ApiCtx, vName) != null ) {
				throw new FabDuplicateFault(typeof(User), NameParam, vName);
			}

			//Allow users to reuse email address. They may not want certain apps/factors associated
			//with their primary identity. Email address is not part of "open data" so they can use
			//one email address for several different User identities.

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