using Fabric.Api.Modify.Validators;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Weaver;
using Weaver;
using Weaver.Functions;
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
		public Url GetUrlByAbsoluteUrl(IApiContext pApiCtx, string pAbsoluteUrl) {
			string propName = WeaverUtil.GetPropertyName<Url>(x => x.AbsoluteUrl);
			string filterStep = "filter{it.getProperty('"+propName+"').toLowerCase()==AU}";

			IWeaverQuery q = 
				ApiFunc.NewPathFromRoot()
				.ContainsUrlList.ToUrl
					.CustomStep(filterStep)
				.End();

			q.AddParam("AU", new WeaverQueryVal(pAbsoluteUrl.ToLower(), false));
			return pApiCtx.DbSingle<Url>("GetUrlByAbsoluteUrl", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public Member GetValidMemberByContext(IApiContext pApiCtx) {
			IWeaverFuncAs<Member> memAlias;

			IWeaverQuery q = 
				ApiFunc.NewPathFromIndex(new User { UserId = pApiCtx.UserId })
				.DefinesMemberList.ToMember
					.As(out memAlias)
				.InAppDefines.FromApp
					.Has(x => x.AppId, WeaverFuncHasOp.EqualTo, pApiCtx.AppId)
				.Back(memAlias)
				.HasMemberTypeAssign.ToMemberTypeAssign
				.UsesMemberType.ToMemberType
					.Has(x => x.MemberTypeId, WeaverFuncHasOp.NotEqualTo, (long)MemberTypeId.None)
					.Has(x => x.MemberTypeId, WeaverFuncHasOp.NotEqualTo, (long)MemberTypeId.Invite)
					.Has(x => x.MemberTypeId, WeaverFuncHasOp.NotEqualTo, (long)MemberTypeId.Request)
				.Back(memAlias)
				.End();

			return pApiCtx.DbSingle<Member>("GetValidMemberByContext", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public Class GetClassByNameDisamb(IApiContext pApiCtx, string pName, string pDisamb) {
			string propName = WeaverUtil.GetPropertyName<Class>(x => x.Name);
			string filterStep = "filter{it.getProperty('"+propName+"').toLowerCase()==NAME}";

			Class path = 
				ApiFunc.NewPathFromRoot()
				.ContainsClassList.ToClass
					.CustomStep(filterStep);

			if ( pDisamb != null ) {
				propName = WeaverUtil.GetPropertyName<Class>(x => x.Disamb);
				filterStep = "filter{it.getProperty('"+propName+"').toLowerCase()==DISAMB}";
				path.CustomStep(filterStep);
			}

			IWeaverQuery q = path.End();
			q.AddParam("NAME", new WeaverQueryVal(pName.ToLower(), false));

			if ( pDisamb != null ) {
				q.AddParam("DISAMB", new WeaverQueryVal(pDisamb.ToLower(), false));
			}

			return pApiCtx.DbSingle<Class>("GetClassByNameDisamb", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public Artifact GetArtifact(IApiContext pApiCtx, long pArtifactId) {
			IWeaverQuery q = ApiFunc.NewPathFromIndex(new Artifact { ArtifactId = pArtifactId }).End();
			return pApiCtx.DbSingle<Artifact>("GetArtifact", q);
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

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddUrl(IApiContext pApiCtx, TxBuilder pTxBuild, string pAbsoluteUrl, string pName,
									IWeaverVarAlias<Root> pRootVar, out IWeaverVarAlias<Url> pUrlVar) {
			var url = new Url();
			url.UrlId = pApiCtx.GetSharpflakeId<Url>();
			url.AbsoluteUrl = pAbsoluteUrl;
			url.Name = pName;

			var urlBuild = new UrlBuilder(pTxBuild, url);
			urlBuild.AddNode(pRootVar);
			pUrlVar = urlBuild.NodeVar;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddClass(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, string pDisamb, 
				string pNote, IWeaverVarAlias<Root> pRootVar, out IWeaverVarAlias<Class> pClassVar) {
			var c = new Class();
			c.ClassId = pApiCtx.GetSharpflakeId<Class>();
			c.Name = pName;
			c.Disamb = pDisamb;
			c.Note = pNote;

			var classBuild = new ClassBuilder(pTxBuild, c);
			classBuild.AddNode(pRootVar);
			pClassVar = classBuild.NodeVar;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddInstance(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, string pDisamb, 
				string pNote, IWeaverVarAlias<Root> pRootVar, out IWeaverVarAlias<Instance> pInstVar) {
			var c = new Instance();
			c.InstanceId = pApiCtx.GetSharpflakeId<Instance>();
			c.Name = pName;
			c.Disamb = pDisamb;
			c.Note = pNote;

			var classBuild = new InstanceBuilder(pTxBuild, c);
			classBuild.AddNode(pRootVar);
			pInstVar = classBuild.NodeVar;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddFactor(IApiContext pApiCtx, TxBuilder pTxBuild, long pPrimArtId,long pRelArtId,
						long pAssertId, bool pIsDefining, string pNote, IWeaverVarAlias<Root> pRootVar,
						IWeaverVarAlias<Member> pMemVar, out IWeaverVarAlias<Factor> pFactorVar) {
			var fac = new Factor();
			fac.FactorId = pApiCtx.GetSharpflakeId<Factor>();
			fac.IsDefining = pIsDefining;
			fac.Note = pNote;
			fac.Created = pApiCtx.UtcNow.Ticks;

			var facBuild = new FactorBuilder(pTxBuild, fac);
			facBuild.AddNode(pRootVar);
			facBuild.SetUsesPrimaryArtifact(pPrimArtId);
			facBuild.SetUsesRelatedArtifact(pRelArtId);
			facBuild.SetUsesFactorAssertion(pAssertId);
			facBuild.SetInMemberCreates(pMemVar);
			pFactorVar = facBuild.NodeVar;
		}

	}

}