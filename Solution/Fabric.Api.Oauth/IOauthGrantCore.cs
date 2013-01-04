using System;
using Fabric.Api.Oauth.Results;
using Fabric.Api.Oauth.Tasks;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Oauth {

	/*================================================================================================*/
	public interface IOauthGrantCore {

		string ClientId { get; }
		string RedirectUri { get; }
		long LoggedUserId { get; }

		long AppId { get; }
		long? UserId { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void SetUserId(long? pUserId);

		/*--------------------------------------------------------------------------------------------*/
		App GetApp(IApiContext pContext);
		User GetUser(IApiContext pContext);

		/*--------------------------------------------------------------------------------------------*/
		LoginScopeResult GetGrantCodeIfScopeAlreadyAllowed(IOauthTasks pTasks, IApiContext pContext);
		LoginScopeResult AddGrantCode(bool pScopeAlreadyAdded, IOauthTasks pTasks,IApiContext pContext);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		OauthException GetFaultOnException(Exception pEx);
		OauthException GetFault(GrantErrors pErr, GrantErrorDescs pDesc);

	}

}