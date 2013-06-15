using System;
using System.Collections.Generic;
using Fabric.Api.Web.Results;
using Fabric.Api.Web.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Query;

namespace Fabric.Api.Web {
	
	/*================================================================================================*/
	public class CreateUser : BaseWebFunc<CreateUserResult> {

		public const string NameParam = "Name";
		public const string PasswordParam = "Password";
		public const string EmailParam = "Email";

		private readonly string vName;
		private readonly string vPass;
		private readonly string vEmail;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateUser(IWebTasks pTasks, string pName, string pPass, string pEmail) : base(pTasks) {
			vName = pName;
			vPass = pPass;
			vEmail = pEmail;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
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

			IWeaverVarAlias<Email> emailVar;
			IWeaverVarAlias<User> userVar;
			IWeaverVarAlias<Member> memVar;
			Action<IWeaverVarAlias<Member>> setMemberCreates;

			var txb = new TxBuilder();

			Tasks.TxAddEmail(ApiCtx, txb, vEmail, out emailVar);
			Tasks.TxAddUser(ApiCtx, txb, vName, vPass, emailVar,
				out userVar, out setMemberCreates);
			Tasks.TxAddMember(ApiCtx, txb, userVar, out memVar);
			setMemberCreates(memVar);

			var list = new List<IWeaverVarAlias> { userVar, emailVar };
			IWeaverVarAlias listVar;
			
			txb.Transaction.AddQuery(
				WeaverQuery.InitListVar("_V0", list, out listVar)
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