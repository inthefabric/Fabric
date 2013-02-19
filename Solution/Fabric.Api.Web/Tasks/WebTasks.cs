using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Web.Tasks {

	/*================================================================================================*/
	public class WebTasks : IWebTasks {

		public IDomainValidator Validator { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public WebTasks() {
			Validator = new DomainValidator();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public User GetUserByName(IApiContext pApiCtx, string pName) {
			string propName = WeaverUtil.GetPropertyName<User>(x => x.Name);
			string filterStep = "filter{it.getProperty('"+propName+"').toLowerCase()==NAME}";

			IWeaverQuery q = 
				ApiFunc.NewPathFromRoot()
				.ContainsUserList.ToUser
					.CustomStep(filterStep)
				.End();

			q.AddParam("NAME", new WeaverQueryVal(pName.ToLower(), false));
			return pApiCtx.DbSingle<User>("GetUserByName", q);

		}

		/*--------------------------------------------------------------------------------------------*/
		public User GetUser(IApiContext pApiCtx, long pUserId) {
			IWeaverQuery q = ApiFunc.NewPathFromIndex(new User { UserId = pUserId }).End();
			return pApiCtx.DbSingle<User>("GetUser", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public App GetAppByName(IApiContext pApiCtx, string pName) {
			string propName = WeaverUtil.GetPropertyName<App>(x => x.Name);
			string filterStep = "filter{it.getProperty('"+propName+"').toLowerCase()==NAME}";

			IWeaverQuery q = 
				ApiFunc.NewPathFromRoot()
				.ContainsAppList.ToApp
					.CustomStep(filterStep)
				.End();

			q.AddParam("NAME", new WeaverQueryVal(pName.ToLower(), false));
			return pApiCtx.DbSingle<App>("GetAppByName", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public User UpdateUserPassword(IApiContext pApiCtx, long pUserId, string pPassword) {
			var user = new User();
			user.UserId = pUserId;
			user.Password = FabricUtil.HashPassword(pPassword);

			WeaverUpdates<User> updates = new WeaverUpdates<User>();
			updates.AddUpdate(user, u => u.Password);

			IWeaverQuery q = 
				ApiFunc.NewPathFromIndex(user)
				.UpdateEach(updates)
				.End();

			return pApiCtx.DbSingle<User>("UpdateUserPassword", q);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void TxAddEmail(IApiContext pApiCtx, TxBuilder pTxBuild, string pAddress, 
								IWeaverVarAlias<Root> pRootVar, out IWeaverVarAlias<Email> pEmailVar) {
			var email = new Email();
			email.EmailId = pApiCtx.GetSharpflakeId<Email>();
			email.Address = pAddress;
			email.Code = pApiCtx.Code32;
			email.Created = pApiCtx.UtcNow.Ticks;
			email.Verified = null;

			var emailBuild = new EmailBuilder(pTxBuild, email);
			emailBuild.AddNode(pRootVar);
			pEmailVar = emailBuild.NodeVar;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddUser(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, string pPassword,
									IWeaverVarAlias<Root> pRootVar, IWeaverVarAlias<Email> pEmailVar, 
									out IWeaverVarAlias<User> pUserVar) {
			var user = new User();
			user.UserId = pApiCtx.GetSharpflakeId<User>();
			user.Name = pName;
			user.Password = FabricUtil.HashPassword(pPassword);

			var userBuild = new UserBuilder(pTxBuild, user);
			userBuild.AddNode(pRootVar);
			userBuild.SetUsesEmail(pEmailVar);
			pUserVar = userBuild.NodeVar;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddMember(IApiContext pApiCtx, TxBuilder pTxBuild, IWeaverVarAlias<Root> pRootVar,
							IWeaverVarAlias<User> pUserVar, out IWeaverVarAlias<Member> pMemVar) {
			var mem = new Member();
			mem.MemberId = pApiCtx.GetSharpflakeId<Member>();

			var mta = new MemberTypeAssign();
			mta.MemberTypeAssignId = pApiCtx.GetSharpflakeId<MemberTypeAssign>();

			var memBuild = new MemberBuilder(pTxBuild, mem);
			memBuild.AddNode(pRootVar);
			memBuild.SetInUserDefines(pUserVar);
			memBuild.SetInAppDefines((long)AppId.FabricSystem);
			pMemVar = memBuild.NodeVar;

			var mtaBuild = new MemberTypeAssignBuilder(pTxBuild, mta);
			mtaBuild.AddNode(pRootVar);
			mtaBuild.SetInMemberCreates((long)MemberId.FabFabData);
			mtaBuild.SetInMemberHas(memBuild.NodeVar);
			mtaBuild.SetUsesMemberType((long)MemberTypeId.Member);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddApp(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, 
					IWeaverVarAlias<Root> pRootVar, long pUserId, out IWeaverVarAlias<App> pAppVar) {
			var emailVar = new WeaverVarAlias<Email>(pTxBuild.Transaction);

			IWeaverQuery q = 
				ApiFunc.NewPathFromIndex(new User { UserId = pUserId })
				.UsesEmail.ToEmail
					.ToNodeVar(emailVar)
				.End();

			pTxBuild.Transaction.AddQuery(q);
			pTxBuild.RegisterVarWithTxBuilder(emailVar);

			var app = new App();
			app.AppId = pApiCtx.GetSharpflakeId<App>();
			app.Name = pName;
			app.Secret = pApiCtx.Code32;

			var appBuild = new AppBuilder(pTxBuild, app);
			appBuild.AddNode(pRootVar);
			appBuild.SetUsesEmail(emailVar);
			pAppVar = appBuild.NodeVar;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddDataProvMember(IApiContext pApiCtx, TxBuilder pTxBuild,
							IWeaverVarAlias<Root> pRootVar, IWeaverVarAlias<App> pAppVar, long pUserId,
							out IWeaverVarAlias<Member> pMemVar) {
			var mem = new Member();
			mem.MemberId = pApiCtx.GetSharpflakeId<Member>();

			var mta = new MemberTypeAssign();
			mta.MemberTypeAssignId = pApiCtx.GetSharpflakeId<MemberTypeAssign>();

			var memBuild = new MemberBuilder(pTxBuild, mem);
			memBuild.AddNode(pRootVar);
			memBuild.SetInUserDefines(pUserId);
			memBuild.SetInAppDefines(pAppVar);
			pMemVar = memBuild.NodeVar;

			var mtaBuild = new MemberTypeAssignBuilder(pTxBuild, mta);
			mtaBuild.AddNode(pRootVar);
			mtaBuild.SetInMemberCreates((long)MemberId.FabFabData);
			mtaBuild.SetInMemberHas(memBuild.NodeVar);
			mtaBuild.SetUsesMemberType((long)MemberTypeId.DataProvider);
		}

	}

}