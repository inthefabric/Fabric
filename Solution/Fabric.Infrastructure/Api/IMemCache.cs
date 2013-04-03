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
		Member RemoveMember(long pAppId, long pUserId);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void AddOauthAccess(string pToken, object pAccess, int pExpiresInSec);
		object FindOauthAccess(string pToken);
		object RemoveOauthAccess(string pToken);

	}

}