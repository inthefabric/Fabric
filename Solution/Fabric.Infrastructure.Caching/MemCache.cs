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
		public void AddExists<T>(long pVertexTypeId, CacheItemPolicy pPolicy=null) where T : IVertexWithId {
			if ( pPolicy == null ) {
				pPolicy = NewPolicy(3600);
			}

			Add(GetDomainVertexKey<T>(pVertexTypeId), true, pPolicy);
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool? FindExists<T>(long pVertexTypeId) where T : IVertexWithId {
			string key = GetDomainVertexKey<T>(pVertexTypeId);
			return (Contains(key) ? (bool)Get(key) : (bool?)null);
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool? RemoveExists<T>(long pVertexTypeId) where T : IVertexWithId {
			string key = GetDomainVertexKey<T>(pVertexTypeId);
			return (Contains(key) ? (bool)Remove(key) : (bool?)null);
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
		public void AddVertex<T>(T pVertex, CacheItemPolicy pPolicy=null) where T : IVertexWithId {
			if ( pPolicy == null ) {
				pPolicy = NewPolicy(3600);
			}

			Add(GetDomainVertexKey<T>(pVertex.GetTypeId()), pVertex, pPolicy);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public T FindVertex<T>(long pVertexTypeId) where T : IVertexWithId {
			string key = GetDomainVertexKey<T>(pVertexTypeId);
			return (Contains(key) ? (T)Get(key) : default(T));
		}

		/*--------------------------------------------------------------------------------------------*/
		public T RemoveVertex<T>(long pVertexTypeId) where T : IVertexWithId {
			string key = GetDomainVertexKey<T>(pVertexTypeId);
			return (Contains(key) ? (T)Remove(key) : default(T));
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string GetDomainVertexKey<T>(long pVertexTypeId) where T : IVertexWithId {
			return typeof(T).Name+"|"+pVertexTypeId;
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