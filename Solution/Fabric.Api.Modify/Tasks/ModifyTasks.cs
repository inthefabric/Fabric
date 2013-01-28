using Fabric.Api.Modify.Validators;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Weaver;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Modify.Tasks {

	/*================================================================================================*/
	public class ModifyTasks : IModifyTasks {

		public IDomainValidator Validator { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ModifyTasks() {
			Validator = new DomainValidator();
		}

		/*--------------------------------------------------------------------------------------------*/
		private Root BeginPathFromRoot() {
			return WeaverTasks.BeginPath<Root>(x => x.RootId, 0).BaseNode;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public User GetUserByName(IApiContext pApiCtx, string pName) {
			string propName = WeaverUtil.GetPropertyName<User>(x => x.Name);
			string filterStep = "filter{it.getProperty('"+propName+"').toLowerCase()==NAME}";

			IWeaverQuery q = 
				BeginPathFromRoot()
				.ContainsUserList.ToUser
					.CustomStep(filterStep)
				.End();

			q.AddParam("NAME", new WeaverQueryVal(pName.ToLower(), false));
			return pApiCtx.DbSingle<User>("GetUserByName", q);

		}

		/*--------------------------------------------------------------------------------------------*/
		public User GetUser(IApiContext pApiCtx, long pUserId) {
			IWeaverQuery q = 
				WeaverTasks.BeginPath<User>(x => x.UserId, pUserId).BaseNode
				.End();
			return pApiCtx.DbSingle<User>("GetUser", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public App GetAppByName(IApiContext pApiCtx, string pName) {
			string propName = WeaverUtil.GetPropertyName<App>(x => x.Name);
			string filterStep = "filter{it.getProperty('"+propName+"').toLowerCase()==NAME}";

			IWeaverQuery q = 
				BeginPathFromRoot()
				.ContainsAppList.ToApp
					.CustomStep(filterStep)
				.End();

			q.AddParam("NAME", new WeaverQueryVal(pName.ToLower(), false));
			return pApiCtx.DbSingle<App>("GetAppByName", q);
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
		public void TxAddArtifact<TNode, TNodeHasArt>(IApiContext pApiCtx, TxBuilder pTxBuild, 
							ArtifactTypeId pArtTypeId, IWeaverVarAlias<Root> pRootVar,
							IWeaverVarAlias<TNode> pNodeVar, IWeaverVarAlias<Member> pMemVar, 
							out IWeaverVarAlias<Artifact> pArtVar)
							where TNode : INode where TNodeHasArt : IWeaverRel<TNode, Artifact>, new() {
			var art = new Artifact();
			art.ArtifactId = pApiCtx.GetSharpflakeId<Artifact>();
			art.Created = pApiCtx.UtcNow.Ticks;
			art.IsPrivate = false;

			var artBuild = new ArtifactBuilder(pTxBuild, art);
			artBuild.AddNode(pRootVar);
			artBuild.SetUsesArtifactType((long)pArtTypeId);
			artBuild.SetInMemberCreates(pMemVar);
			pArtVar = artBuild.NodeVar;

			pTxBuild.AddRel<TNodeHasArt>(pNodeVar, pArtVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddApp(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, 
					IWeaverVarAlias<Root> pRootVar, long pUserId, out IWeaverVarAlias<App> pAppVar) {
			var emailVar = new WeaverVarAlias<Email>(pTxBuild.Transaction);

			IWeaverQuery q = WeaverTasks.BeginPath<User>(x => x.UserId, pUserId).BaseNode
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
		//TEST: ModifyTasks.TxAddDataProvMember
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