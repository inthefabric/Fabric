using System;
using System.Runtime.Caching;
using Fabric.Domain;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public interface IMemCache {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void AddExists<T>(long pVertexTypeId, CacheItemPolicy pPolicy=null) where T : IVertexWithId;
		bool? FindExists<T>(long pVertexTypeId) where T : IVertexWithId;
		bool? RemoveExists<T>(long pVertexTypeId) where T : IVertexWithId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void AddVertex<T>(T pVertex, CacheItemPolicy pPolicy=null) where T : IVertexWithId;
		T FindVertex<T>(long pVertexTypeId) where T : IVertexWithId;
		T RemoveVertex<T>(long pVertexTypeId) where T : IVertexWithId;


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