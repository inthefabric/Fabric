using System;
using System.Runtime.Caching;
using Fabric.Domain;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public interface IMemCache {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void AddNode<T>(T pNode, CacheItemPolicy pPolicy=null) where T : INodeWithId;
		T FindNode<T>(long pNodeTypeId) where T : INodeWithId;
		T RemoveNode<T>(long pNodeTypeId) where T : INodeWithId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void AddMember(long pAppId, long pUserId, Member pMember, CacheItemPolicy pPolicy=null);
		Member FindMember(long pAppId, long pUserId);
		//Member RemoveMember(long pAppId, long pUserId);
		Member RemoveMember(long pMemberId);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void AddOauthAccess(string pToken, Tuple<OauthAccess, long, long?> pData, int pExpiresInSec);
		Tuple<OauthAccess, long, long?> FindOauthAccess(string pToken);
		//Tuple<OauthAccess, long, long?> RemoveOauthAccess(string pToken);
		int RemoveOauthAccesses(long pAppId, long? pUserId);

	}

}