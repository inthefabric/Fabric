using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.Caching;
using Fabric.Domain;
using Fabric.Infrastructure.Analytics;
using Weaver;
using Weaver.Interfaces;
using Weaver.Items;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public class ApiContext : IApiContext {

		public string RexConnUrl { get; private set; }
		public int RexConnPort { get; private set; }

		public Guid ContextId { get; private set; }
		public long UserId { get; private set; }
		public long AppId { get; private set; }
		public AnalyticsManager Analytics { get; private set; }
		//public long MemberId { get; private set; }

		public int DbQueryExecutionCount { get; private set; }
		public int DbQueryMillis { get; private set; }

		private readonly MemoryCache vMemCache;
		private readonly ClassNameCache vClassNameCache;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiContext(string pRexConnUrl, int pRexConnPort,
												MemoryCache pMemCache, ClassNameCache pClassNameCache) {
			RexConnUrl = pRexConnUrl;
			RexConnPort = pRexConnPort;
			vMemCache = pMemCache;
			vClassNameCache = pClassNameCache;

			ContextId = Guid.NewGuid();
			UserId = -1;
			AppId = -1;
			//MemberId = -1;
			Analytics = new AnalyticsManager(ContextId, x => Log.Debug(ContextId, "ANALYT", x));
			DbQueryExecutionCount = 0;
			DbQueryMillis = 0;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void SetAppUserId(long? pAppId, long? pUserId) {
			if ( AppId != -1 ) { throw new Exception("UserId and AppId are already set."); }
			AppId = (pAppId ?? 0);
			UserId = (pUserId ?? 0);
			//Analytics.SetAppUserId(AppId, UserId);
		}

		/*--------------------------------------------------------------------------------------------* /
		public void SetMemberId(long pMemberId) {
			if ( MemberId != -1 ) { throw new Exception("MemberId is already set."); }
			MemberId = MemberId;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual DateTime UtcNow {
			get { return DateTime.UtcNow; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual string Code32 {
			get { return FabricUtil.Code32; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual long GetSharpflakeId<T>() where T : INode {
			return Sharpflake.GetId<T>();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		// TEST: ApiContext caching functionality and usages
		/*--------------------------------------------------------------------------------------------*/
		public virtual bool AddToCache<T>(string pKey, T pItem, int pExpiresInSec) {
			var ci = new CacheItem(pKey, pItem);
			
			var pol = new CacheItemPolicy();
			pol.AbsoluteExpiration = DateTime.UtcNow.AddSeconds(pExpiresInSec);

			Log.Debug(ContextId, "CACHE", "Add "+typeof(T).Name+" to cache: "+pKey+" = "+
				(pItem == null ? "[null]" : pItem.GetType().Name)+" ("+pExpiresInSec+" sec)");
			return vMemCache.Add(ci, pol);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual T GetFromCache<T>(string pKey) {
			object obj = vMemCache.Get(pKey);
			Log.Debug(ContextId, "CACHE", "Get "+typeof(T).Name+" from cache: "+pKey+" = "+
				(obj == null ? "[null]" : obj.GetType().Name));
			return (T)obj;
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual T RemoveFromCache<T>(string pKey) {
			return (T)vMemCache.Remove(pKey);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		// TEST: ApiContext ClassName caching functionality and usages
		/*--------------------------------------------------------------------------------------------*/
		public virtual void AddToClassNameCache(Class pClass) {
			vClassNameCache.AddClass(this, pClass);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IList<long> GetClassIdsFromClassNameCache(string pName, string pDisamb) {
			return vClassNameCache.GetClassIds(this, pName, pDisamb);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IApiDataAccess DbData(string pQueryName, IWeaverScript pScripted) {
			var a = NewAccess(pScripted);
			return DbDataAccess(pQueryName, a);
		}

		/*--------------------------------------------------------------------------------------------*/
		public T DbSingle<T>(string pQueryName, IWeaverScript pScripted)
																where T : class, IItemWithId, new() {
			var a = NewAccess<T>(pScripted);
			IApiDataAccess<T> da = DbDataAccess(pQueryName, a);

			if ( da.TypedResultList == null || da.TypedResultList.Count == 0 ) {
				return default(T);
			}
			
			if ( da.TypedResultList.Count > 1 ) {
				throw new Exception("DbSingle<"+typeof(T).Name+"> expects 1 result, but received "+
					da.TypedResultList.Count);
			}

			return da.TypedResultList[0];
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<T> DbList<T>(string pQueryName, IWeaverScript pScripted)
																		where T : IItemWithId, new() {
			var a = NewAccess<T>(pScripted);
			return DbDataAccess(pQueryName, a).TypedResultList;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public T DbAddNode<T, TRootRel>(string pQueryName, T pNode,
															Expression<Func<T, object>> pIndexProp)
												where T : class, INode, IItemWithId, new()
												where TRootRel : WeaverRel<Root, Contains, T>, new() {
			T newNode = DbSingle<T>(
				pQueryName,
				WeaverTasks.AddNode(pNode)
			);

			DbData(
				pQueryName,
				WeaverTasks.AddNodeToIndex(typeof(T).Name, newNode, pIndexProp)
			);

			DbData(
				pQueryName,
				WeaverTasks.AddRel(new Root { Id = 0 }, new TRootRel(), newNode)
			);

			return newNode;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected virtual IApiDataAccess NewAccess(IWeaverScript pScripted) {
			return new ApiDataAccess(this, pScripted);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual IApiDataAccess<T> NewAccess<T>(IWeaverScript pScripted)
																		where T : IItemWithId, new() {
			return new ApiDataAccess<T>(this, pScripted);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected virtual IApiDataAccess DbDataAccess(string pQueryName, IApiDataAccess pDbQuery) {
			pDbQuery.Execute();
			DbQueryExecutionCount++;
			DbQueryMillis += pDbQuery.Result.QueryTime;
			return pDbQuery;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual IApiDataAccess<T> DbDataAccess<T>(string pQueryName,
											IApiDataAccess<T> pDbQuery) where T : IItemWithId, new() {
			pDbQuery.Execute();
			DbQueryExecutionCount++;
			DbQueryMillis += pDbQuery.Result.QueryTime;
			return pDbQuery;
		}

	}

}