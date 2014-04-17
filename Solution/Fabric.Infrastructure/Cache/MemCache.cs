using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.Caching;
using Fabric.Domain;
using Fabric.Infrastructure.Broadcast;

namespace Fabric.Infrastructure.Cache {

	/*================================================================================================*/
	public class MemCache : MemoryCache, IMemCache { //TEST: MemCache

		private readonly IMetricsManager vMetrics;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemCache(IMetricsManager pMetrics) : base("MemCache", GetConfig()) {
			vMetrics = pMetrics;
		}

		/*--------------------------------------------------------------------------------------------*/
		private static NameValueCollection GetConfig() {
			var config = new NameValueCollection();
			//config.Add("PhysicalMemoryLimitPercentage", "10");
			return config;
		}

		/*--------------------------------------------------------------------------------------------*/
		private bool IsCacheHit(string pName, string pKey) {
			bool hit = Contains(pKey);
			vMetrics.Counter("cache.mem."+pName+"."+(hit ? "hit" : "miss"), 1);
			return hit;
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
		public void AddVertex<T>(T pVertex, CacheItemPolicy pPolicy=null) where T : IVertex {
			if ( pPolicy == null ) {
				pPolicy = NewPolicy(3600);
			}

			Add(GetDomainVertexKey<T>(pVertex.VertexId), pVertex, pPolicy);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public T FindVertex<T>(long pVertexTypeId) where T : IVertex {
			string key = GetDomainVertexKey<T>(pVertexTypeId);
			return (IsCacheHit("FindVertex", key) ? (T)Get(key) : default(T));
		}

		/*--------------------------------------------------------------------------------------------*/
		public T RemoveVertex<T>(long pVertexTypeId) where T : IVertex {
			string key = GetDomainVertexKey<T>(pVertexTypeId);
			return (Contains(key) ? (T)Remove(key) : default(T));
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string GetDomainVertexKey<T>(long pVertexTypeId) where T : IVertex {
			return typeof(T).Name+"|"+pVertexTypeId;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddOauthMember(string pToken, Member pMember, int pExpiresInSec) {
			Add(GetOauthMemberKey(pToken), pMember, NewPolicy(pExpiresInSec, false));
		}

		/*--------------------------------------------------------------------------------------------*/
		public Member FindOauthMember(string pToken) {
			string key = GetOauthMemberKey(pToken);
			return (IsCacheHit("FindOauthMember", key) ? (Member)Get(key) : null);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void RemoveOauthMembers(long pMemberId) {
			IEnumerator<KeyValuePair<string, object>> e = GetEnumerator();

			while ( e.MoveNext() ) {
				var mem = (e.Current.Value as Member);

				if ( mem != null && mem.VertexId == pMemberId ) {
					Remove(e.Current.Key);
				}
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private static string GetOauthMemberKey(string pToken) {
			return "OM|"+pToken;
		}
		
	}

}