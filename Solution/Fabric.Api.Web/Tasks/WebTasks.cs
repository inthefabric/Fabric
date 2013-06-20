using System;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;
using Weaver.Core.Steps.Statements;
using Weaver.Core.Util;

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
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.NameKey, pName.ToLower())
				.ToQuery();

			return pApiCtx.DbSingle<User>("GetUserByName", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public App GetAppByName(IApiContext pApiCtx, string pName) {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.NameKey, pName.ToLower())
				.ToQuery();

			App app = pApiCtx.DbSingle<App>("GetAppByName", q);

			if ( app == null || app.Name.ToLower() != pName.ToLower() ) {
				return null;
			}

			return app;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public User UpdateUserPassword(IApiContext pApiCtx, long pUserId, string pPassword) {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.ArtifactId, pUserId)
					.SideEffect(
						new WeaverStatementSetProperty<User>(x => x.Password,
							FabricUtil.HashPassword(pPassword))
					)
				.ToQuery();

			return pApiCtx.DbSingle<User>("UpdateUserPassword", q);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public App UpdateAppName(IApiContext pApiCtx, long pAppId, string pName) {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.ArtifactId, pAppId)
					.SideEffect(new WeaverStatementSetProperty<App>(x => x.Name, pName))
				.ToQuery();
					
			return pApiCtx.DbSingle<App>("UpdateAppName", q);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public App UpdateAppSecret(IApiContext pApiCtx, long pAppId, string pSecret) {
			var update = new WeaverStatementSetProperty<App>(x => x.Secret, pSecret);

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.ArtifactId, pAppId)
					.SideEffect	(update)
				.ToQuery();

			return pApiCtx.DbSingle<App>("UpdateAppSecret", q);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public Member GetMemberOfApp(IApiContext pApiCtx, long pAppId, long pMemberId) {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.ArtifactId, pAppId)
				.DefinesMemberList.ToMember
					.Has(x => x.MemberId, WeaverStepHasOp.EqualTo, pMemberId)
				.ToQuery();
			
			return pApiCtx.DbSingle<Member>("GetMemberOfApp", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssign GetMemberTypeAssignByMember(IApiContext pApiCtx, long pMemberId) {
			IWeaverQuery q = 
				ApiFunc.NewPathFromIndex(new Member { MemberId = pMemberId })
				.HasMemberTypeAssign.ToMemberTypeAssign
				.ToQuery();

			return pApiCtx.DbSingle<MemberTypeAssign>("GetMemberTypeAssignByMember", q);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssign AddMemberTypeAssign(IApiContext pApiCtx,
										long pAssigningMemberId, long pMemberId, byte pMemberTypeId) {
			var txb = new TxBuilder();

			var mem = new Member { MemberId = pMemberId };
			IWeaverVarAlias<Member> memAlias;
			txb.GetVertex(mem, out memAlias);

			IWeaverQuery q = Weave.Inst.FromVar(memAlias)
				.HasMemberTypeAssign.ToMemberTypeAssign
					.Next()
				.ToQuery();

			IWeaverVarAlias<MemberTypeAssign> mtaAlias;
			q = WeaverQuery.StoreResultAsVar("_MTA", q, out mtaAlias);
			txb.Transaction.AddQuery(q);
			txb.RegisterVarWithTxBuilder(mtaAlias);
		
			txb.Transaction.AddQuery(
				Weave.Inst.FromVar(mtaAlias)
				.InMemberHas
					.Remove() //remove relationship between Member and MTA
				.ToQuery()
			);

			var memBuild = new MemberBuilder(txb, pMemberId);
			memBuild.SetVertexVar(memAlias);
			memBuild.AddToHasHistoricMemberTypeAssignList(mtaAlias);
			
			////
			
			var mta = new MemberTypeAssign();
			mta.MemberTypeAssignId = pApiCtx.GetSharpflakeId<MemberTypeAssign>();
			mta.MemberTypeId = pMemberTypeId;
			mta.Performed = pApiCtx.UtcNow.Ticks;
			
			var mtaBuild = new MemberTypeAssignBuilder(txb, mta);
			mtaBuild.AddVertex();
			mtaBuild.SetInMemberCreates(pAssigningMemberId);
			mtaBuild.SetInMemberHas(memAlias);

			txb.Finish(mtaBuild.VertexVar);
			return pApiCtx.DbSingle<MemberTypeAssign>("AddMemberTypeAssign", txb.Transaction);
		}

		/*--------------------------------------------------------------------------------------------*/
		public OauthDomain GetOauthDomainByDomain(IApiContext pApiCtx, long pAppId, string pDomain) {
			string propName = WeaverUtil.GetPropertyName<OauthDomain>(Weave.Inst.Config, x => x.Domain);
			string filterStep = "filter{it.getProperty('"+propName+"').toLowerCase()==_P1}";

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.ArtifactId, pAppId)
				.InOauthDomainListUses.FromOauthDomain
					.CustomStep(filterStep)
				.ToQuery();

			q.AddStringParam(pDomain.ToLower());
			return pApiCtx.DbSingle<OauthDomain>("GetOauthDomainByDomain", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public OauthDomain AddOauthDomain(IApiContext pApiCtx, long pAppId, string pDomain) {
			var txb = new TxBuilder();
			
			var od = new OauthDomain();
			od.OauthDomainId = pApiCtx.GetSharpflakeId<OauthDomain>();
			od.Domain = pDomain.ToLower();
			
			var odBuild = new OauthDomainBuilder(txb, od);
			odBuild.AddVertex();
			odBuild.SetUsesApp(pAppId);
			
			txb.Finish(odBuild.VertexVar);
			return pApiCtx.DbSingle<OauthDomain>("AddOauthDomain", txb.Transaction);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public bool DeleteOauthDomain(IApiContext pApiCtx, long pAppId, long pOauthDomainId) {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<App>(x => x.ArtifactId, pAppId)
				.InOauthDomainListUses.FromOauthDomain
					.Has(x => x.OauthDomainId, WeaverStepHasOp.EqualTo, pOauthDomainId)
					.Remove()
				.ToQuery();
				
			pApiCtx.DbData("DeleteOauthDomain", q);
			return true;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void TxAddEmail(IApiContext pApiCtx, TxBuilder pTxBuild, string pAddress, 
																out IWeaverVarAlias<Email> pEmailVar) {
			var email = new Email();
			email.EmailId = pApiCtx.GetSharpflakeId<Email>();
			email.Address = pAddress.ToLower();
			email.Code = pApiCtx.Code32;
			email.Created = pApiCtx.UtcNow.Ticks;
			email.Verified = null;

			var emailBuild = new EmailBuilder(pTxBuild, email);
			emailBuild.AddVertex();
			pEmailVar = emailBuild.VertexVar;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddUser(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, string pPassword,
								IWeaverVarAlias<Email> pEmailVar, out IWeaverVarAlias<User> pUserVar, 
								out Action<IWeaverVarAlias<Member>> pSetMemberCreatesAction) {
			var user = new User();
			user.Name = pName;
			user.NameKey = pName.ToLower();
			user.Password = FabricUtil.HashPassword(pPassword);
			user.ArtifactId = pApiCtx.GetSharpflakeId<Artifact>();
			user.Created = pApiCtx.UtcNow.Ticks;

			var userBuild = new UserBuilder(pTxBuild, user);
			userBuild.AddVertex();
			userBuild.SetUsesEmail(pEmailVar);

			pUserVar = userBuild.VertexVar;
			pSetMemberCreatesAction = userBuild.SetInMemberCreates;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddMember(IApiContext pApiCtx, TxBuilder pTxBuild, IWeaverVarAlias<User> pUserVar,
																	out IWeaverVarAlias<Member> pMemVar) {
			var mem = new Member();
			mem.MemberId = pApiCtx.GetSharpflakeId<Member>();

			var mta = new MemberTypeAssign();
			mta.MemberTypeAssignId = pApiCtx.GetSharpflakeId<MemberTypeAssign>();
			mta.MemberTypeId = (byte)MemberTypeId.Member;
			mta.Performed = pApiCtx.UtcNow.Ticks;

			var memBuild = new MemberBuilder(pTxBuild, mem);
			memBuild.AddVertex();
			memBuild.SetInUserDefines(pUserVar);
			memBuild.SetInAppDefines((long)AppId.FabricSystem);
			pMemVar = memBuild.VertexVar;

			var mtaBuild = new MemberTypeAssignBuilder(pTxBuild, mta);
			mtaBuild.AddVertex();
			mtaBuild.SetInMemberCreates((long)MemberId.FabFabData);
			mtaBuild.SetInMemberHas(memBuild.VertexVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddApp(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, long pUserId,
										out IWeaverVarAlias<App> pAppVar,
										out Action<IWeaverVarAlias<Member>> pSetMemberCreatesAction) {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.ArtifactId, pUserId)
				.UsesEmail.ToEmail
					.Next()
				.ToQuery();

			IWeaverVarAlias<Email> emailVar;
			q = WeaverQuery.StoreResultAsVar("_EM", q, out emailVar);
			pTxBuild.Transaction.AddQuery(q);
			pTxBuild.RegisterVarWithTxBuilder(emailVar);

			var app = new App();
			app.Name = pName;
			app.NameKey = pName.ToLower();
			app.Secret = pApiCtx.Code32;
			app.ArtifactId = pApiCtx.GetSharpflakeId<Artifact>();
			app.Created = pApiCtx.UtcNow.Ticks;

			var appBuild = new AppBuilder(pTxBuild, app);
			appBuild.AddVertex();
			appBuild.SetUsesEmail(emailVar);

			pAppVar = appBuild.VertexVar;
			pSetMemberCreatesAction = appBuild.SetInMemberCreates;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddDataProvMember(IApiContext pApiCtx, TxBuilder pTxBuild,
					IWeaverVarAlias<App> pAppVar, long pUserId, out IWeaverVarAlias<Member> pMemVar) {
			var mem = new Member();
			mem.MemberId = pApiCtx.GetSharpflakeId<Member>();

			var mta = new MemberTypeAssign();
			mta.MemberTypeAssignId = pApiCtx.GetSharpflakeId<MemberTypeAssign>();
			mta.MemberTypeId = (byte)MemberTypeId.DataProvider;
			mta.Performed = pApiCtx.UtcNow.Ticks;

			var memBuild = new MemberBuilder(pTxBuild, mem);
			memBuild.AddVertex();
			memBuild.SetInUserDefines(pUserId);
			memBuild.SetInAppDefines(pAppVar);
			pMemVar = memBuild.VertexVar;

			var mtaBuild = new MemberTypeAssignBuilder(pTxBuild, mta);
			mtaBuild.AddVertex();
			mtaBuild.SetInMemberCreates((long)MemberId.FabFabData);
			mtaBuild.SetInMemberHas(memBuild.VertexVar);
		}

	}

}