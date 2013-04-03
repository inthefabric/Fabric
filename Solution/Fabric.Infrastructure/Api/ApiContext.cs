using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using Fabric.Domain;
using Fabric.Infrastructure.Analytics;
using Weaver.Interfaces;

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
		public ICacheManager Cache { get; private set; }

		public int DbQueryExecutionCount { get; private set; }
		public int DbQueryMillis { get; private set; }

		private readonly MemoryCache vMemCache;
		// TEST: ApiContext ClassName caching functionality and usages


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiContext(string pRexConnUrl, int pRexConnPort) :
															this(pRexConnUrl, pRexConnPort, null) {}

		/*--------------------------------------------------------------------------------------------*/
		public ApiContext(string pRexConnUrl, int pRexConnPort, ICacheManager pCache) {
			RexConnUrl = pRexConnUrl;
			RexConnPort = pRexConnPort;
			Cache = pCache;

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