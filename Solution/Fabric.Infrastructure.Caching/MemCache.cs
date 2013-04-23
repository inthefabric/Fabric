using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.Caching;
using Fabric.Domain;
using Fabric.Infrastructure.Api;

namespace Fabric.Infrastructure.Caching {

	/*================================================================================================*/
	public class MemCache : MemoryCache, IMemCache {


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

			Add(GetDomainNodeKey<T>(pNode.GetTypeId()), pNode, pPolicy);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public T FindNode<T>(long pNodeTypeId) where T : INodeWithId {
			string key = GetDomainNodeKey<T>(pNodeTypeId);
			return (Contains(key) ? (T)Get(key) : default(T));
		}

		/*--------------------------------------------------------------------------------------------*/
		public T RemoveNode<T>(long pNodeTypeId) where T : INodeWithId {
			string key = GetDomainNodeKey<T>(pNodeTypeId);
			return (Contains(key) ? (T)Remove(key) : default(T));
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string GetDomainNodeKey<T>(long pNodeTypeId) where T : INodeWithId {
			return typeof(T).Name+"|"+pNodeTypeId;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddMember(long pAppId, long pUserId, Member pMember, CacheItemPolicy pPolicy=null) {
			if ( pPolicy == null ) {
				pPolicy = new CacheItemPolicy();
				pPolicy.SlidingExpiration = new TimeSpan(0, 1, 0, 0);
			}

			Add(GetMemberKey(pAppId, pUserId), pMember, pPolicy);
		}

		/*--------------------------------------------------------------------------------------------*/
		public Member FindMember(long pAppId, long pUserId) {
			string key = GetMemberKey(pAppId, pUserId);
			return (Contains(key) ? (Member)Get(key) : null);
		}

		/*--------------------------------------------------------------------------------------------* /
		public Member RemoveMember(long pAppId, long pUserId) {
			string key = GetMemberKey(pAppId, pUserId);
			return (Contains(key) ? (Member)Remove(key) : null);
		}

		/*--------------------------------------------------------------------------------------------*/
		public Member RemoveMember(long pMemberId) {
			IEnumerator<KeyValuePair<string, object>> e = GetEnumerator();

			while ( e.MoveNext() ) {
				var m = (e.Current.Value as Member);

				if ( m != null && m.MemberId == pMemberId ) {
					Remove(e.Current.Key);
					return m;
				}
			}

			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string GetMemberKey(long pAppId, long pUserId) {
			return "M|"+pAppId+"|"+pUserId;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddOauthAccess(string pToken, Tuple<OauthAccess, long, long?> pData,
																					int pExpiresInSec) {
			Add(GetOauthAccessKey(pToken), pData, NewPolicy(pExpiresInSec, false));
		}

		/*--------------------------------------------------------------------------------------------*/
		public Tuple<OauthAccess, long, long?> FindOauthAccess(string pToken) {
			string key = GetOauthAccessKey(pToken);
			return (Contains(key) ? (Tuple<OauthAccess, long, long?>)Get(key) : null);
		}

		/*--------------------------------------------------------------------------------------------* /
		public Tuple<OauthAccess, long, long?> RemoveOauthAccess(string pToken) {
			string key = GetOauthAccessKey(pToken);
			return (Contains(key) ? (Tuple<OauthAccess, long, long?>)Remove(key) : null);
		}

		/*--------------------------------------------------------------------------------------------*/
		public int RemoveOauthAccesses(long pAppId, long? pUserId) {
			IEnumerator<KeyValuePair<string, object>> e = GetEnumerator();
			int count = 0;

			while ( e.MoveNext() ) {
				var t = (e.Current.Value as Tuple<OauthAccess, long,long?>);

				if ( t != null && t.Item2 == pAppId && t.Item3 == pUserId ) {
					Remove(e.Current.Key);
					count++;
				}
			}

			return count;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string GetOauthAccessKey(string pToken) {
			return "OA|"+pToken;
		}
		
	}

}