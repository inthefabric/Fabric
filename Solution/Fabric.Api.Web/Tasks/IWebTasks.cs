﻿using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Web.Tasks {

	/*================================================================================================*/
	public interface IWebTasks {

		IDomainValidator Validator { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		User GetUserByName(IApiContext pApiCtx, string pName);

		/*--------------------------------------------------------------------------------------------*/
		User GetUser(IApiContext pApiCtx, long pUserId);

		/*--------------------------------------------------------------------------------------------*/
		App GetAppByName(IApiContext pApiCtx, string pName);
		
		/*--------------------------------------------------------------------------------------------*/
		App GetApp(IApiContext pApiCtx, long pAppId);
		
		/*--------------------------------------------------------------------------------------------*/
		User UpdateUserPassword(IApiContext pApiCtx, long pUserId, string pPassword);

		/*--------------------------------------------------------------------------------------------*/
		App UpdateAppName(IApiContext pApiCtx, long pAppId, string pName);
		
		/*--------------------------------------------------------------------------------------------*/
		App UpdateAppSecret(IApiContext pApiCtx, long pAppId, string pSecret);
		
		/*--------------------------------------------------------------------------------------------*/
		//TEST: WebTasks.GetMemberOfApp()
		Member GetMemberOfApp(IApiContext pApiCtx, long pAppId, long pMemberId);
		
		/*--------------------------------------------------------------------------------------------*/
		//TEST: WebTasks.AddMemberTypeAssign()
		MemberTypeAssign AddMemberTypeAssign(IApiContext pApiCtx,
			long pAppId, long pAssigningMemberId, long pMemberId, long pMemberTypeId);
		
		/*--------------------------------------------------------------------------------------------*/
		//TEST: WebTasks.AddOauthDomain() integration
		OauthDomain AddOauthDomain(IApiContext pApiCtx, long pAppId, string pDomain);
		
		/*--------------------------------------------------------------------------------------------*/
		//TEST: WebTasks.DeleteOauthDomain()
		bool DeleteOauthDomain(IApiContext pApiCtx, long pAppId, long pOauthDomainId);
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void TxAddEmail(IApiContext pApiCtx, TxBuilder pTxBuild, string pAddress,
								IWeaverVarAlias<Root> pRootVar, out IWeaverVarAlias<Email> pEmailVar);
		
		/*--------------------------------------------------------------------------------------------*/
		void TxAddUser(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, string pPassword,
									IWeaverVarAlias<Root> pRootVar, IWeaverVarAlias<Email> pEmailVar,
									out IWeaverVarAlias<User> pUserVar);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddMember(IApiContext pApiCtx, TxBuilder pTxBuild, IWeaverVarAlias<Root> pRootVar,
								IWeaverVarAlias<User> pUserVar, out IWeaverVarAlias<Member> pMemVar);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddApp(IApiContext pApiCtx, TxBuilder pTxBuild, string pName,
						IWeaverVarAlias<Root> pRootVar, long pUserId, out IWeaverVarAlias<App> pAppVar);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddDataProvMember(IApiContext pApiCtx, TxBuilder pTxBuild,IWeaverVarAlias<Root> pRootVar, 
					IWeaverVarAlias<App> pAppVar, long pUserId, out IWeaverVarAlias<Member> pMemVar);
		
	}

}