using System;
using Fabric.Domain;
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
		Member GetMemberOfApp(IApiContext pApiCtx, long pAppId, long pMemberId);
		
		/*--------------------------------------------------------------------------------------------*/
		MemberTypeAssign AddMemberTypeAssign(IApiContext pApiCtx, long pAssigningMemberId,
																	long pMemberId, byte pMemberTypeId);

		/*--------------------------------------------------------------------------------------------*/
		//TEST: WebTasks.GetOauthDomainByDomain()
		OauthDomain GetOauthDomainByDomain(IApiContext pApiCtx, long pAppId, string pDomain);

		/*--------------------------------------------------------------------------------------------*/
		OauthDomain AddOauthDomain(IApiContext pApiCtx, long pAppId, string pDomain);
		
		/*--------------------------------------------------------------------------------------------*/
		bool DeleteOauthDomain(IApiContext pApiCtx, long pAppId, long pOauthDomainId);
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void TxAddEmail(IApiContext pApiCtx, TxBuilder pTxBuild, string pAddress,
																out IWeaverVarAlias<Email> pEmailVar);
		
		/*--------------------------------------------------------------------------------------------*/
		void TxAddUser(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, string pPassword,
								IWeaverVarAlias<Email> pEmailVar, out IWeaverVarAlias<User> pUserVar,
								out Action<IWeaverVarAlias<Member>> pSetMemberCreatesAction);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddMember(IApiContext pApiCtx, TxBuilder pTxBuild, IWeaverVarAlias<User> pUserVar,
																out IWeaverVarAlias<Member> pMemVar);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddApp(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, long pUserId,
										out IWeaverVarAlias<App> pAppVar,
										out Action<IWeaverVarAlias<Member>> pSetMemberCreatesAction);

		/*--------------------------------------------------------------------------------------------*/
		void TxAddDataProvMember(IApiContext pApiCtx, TxBuilder pTxBuild, IWeaverVarAlias<App> pAppVar,
													long pUserId, out IWeaverVarAlias<Member> pMemVar);
		
	}

}