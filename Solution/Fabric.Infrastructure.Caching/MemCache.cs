using System;
using System.Collections.Specialized;
using System.Runtime.Caching;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Infrastructure.Caching {

	/*================================================================================================*/
	public class MemCache : MemoryCache, IMemCache {

		private const string NodeRegion = null; //"Node";
		private const string MemberRegion = null; //"Member";
		private const string AccessRegion = null; //"Access";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemCache() : base("MemCache", GetConfig()) {}

		/*--------------------------------------------------------------------------------------------*/
		private static NameValueCollection GetConfig() {
			var config = new NameValueCollection();
			//config.Add("PhysicalMemoryLimitPercentage", "10");
			return config;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static CacheItemPolicy NewPolicy(int pExpiresInSec, bool pSliding=true) {
			var pol = new CacheItemPolicy();

			if ( pSliding ) {
				pol.SlidingExpiration = new TimeSpan(0, 1, 0, 0);
			}
			else {
				pol.AbsoluteExpiration = DateTime.UtcNow.AddSeconds(pExpiresInSec);
			}

			return pol;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddNode<T>(T pNode, CacheItemPolicy pPolicy=null) where T : INodeWithId {
			if ( pPolicy == null ) {
				pPolicy = NewPolicy(3600);
			}

			Add(GetDomainNodeKey<T>(pNode.GetTypeId()), pNode, pPolicy, NodeRegion);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public T FindNode<T>(long pNodeTypeId) where T : INodeWithId {
			string key = GetDomainNodeKey<T>(pNodeTypeId);
			return (Contains(key, NodeRegion) ? (T)Get(key, NodeRegion) : default(T));
		}

		/*--------------------------------------------------------------------------------------------*/
		public T RemoveNode<T>(long pNodeTypeId) where T : INodeWithId {
			string key = GetDomainNodeKey<T>(pNodeTypeId);
			return (Contains(key, NodeRegion) ? (T)Remove(key, NodeRegion) : default(T));
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string GetDomainNodeKey<T>(long pNodeTypeId) where T : INodeWithId {
			return typeof(T).Name+pNodeTypeId;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddMember(long pAppId, long pUserId, Member pMember, CacheItemPolicy pPolicy=null) {
			if ( pPolicy == null ) {
				pPolicy = new CacheItemPolicy();
				pPolicy.SlidingExpiration = new TimeSpan(0, 1, 0, 0);
			}

			Add(GetMemberKey(pAppId, pUserId), pMember, pPolicy, MemberRegion);
		}

		/*--------------------------------------------------------------------------------------------*/
		public Member FindMember(long pAppId, long pUserId) {
			string key = GetMemberKey(pAppId, pUserId);
			return (Contains(key, MemberRegion) ? (Member)Get(key, MemberRegion) : null);
		}

		/*--------------------------------------------------------------------------------------------*/
		public Member RemoveMember(long pAppId, long pUserId) {
			string key = GetMemberKey(pAppId, pUserId);
			return (Contains(key, MemberRegion) ? (Member)Remove(key, MemberRegion) : null);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string GetMemberKey(long pAppId, long pUserId) {
			return "Member|"+pAppId+"|"+pUserId;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddOauthAccess(string pToken, object pAccess, int pExpiresInSec) {
			Add(GetOauthAccessKey(pToken), pAccess, NewPolicy(pExpiresInSec, false), AccessRegion);
		}

		/*--------------------------------------------------------------------------------------------*/
		public object FindOauthAccess(string pToken) {
			string key = GetOauthAccessKey(pToken);
			return (Contains(key, AccessRegion) ? Get(key, AccessRegion) : null);
		}

		/*--------------------------------------------------------------------------------------------*/
		public object RemoveOauthAccess(string pToken) {
			string key = GetOauthAccessKey(pToken);
			return (Contains(key, AccessRegion) ? Remove(key, AccessRegion) : null);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string GetOauthAccessKey(string pToken) {
			return "Access|"+pToken;
		}

	}

}