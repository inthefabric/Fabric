using System;
using System.Collections.Generic;
using Fabric.Domain;
using Weaver.Interfaces;

namespace Fabric.Infrastructure.Api {
	
	/*================================================================================================*/
	public class ApiContext {

		public string DbServerUrl { get; private set; }

		public long UserId { get; private set; }
		public long AppId { get; private set; }
		public long MemberId { get; private set; }

		public long DbQueryExecutionCount { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiContext(string pDbServerUrl) {
			DbServerUrl = pDbServerUrl;
			UserId = -1;
			AppId = -1;
			MemberId = -1;
			DbQueryExecutionCount = 0;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void SetUserAppId(long pUserId, long pAppId) {
			if ( UserId != -1 ) { throw new Exception("UserId and AppId are already set."); }
			UserId = pUserId;
			AppId = pAppId;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void SetMemberId(long pMember) {
			if ( MemberId != -1 ) { throw new Exception("MemberId is already set."); }
			MemberId = MemberId;
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess ExecuteQuery(string pScript, IDictionary<string, string> pParams=null) {
			return ExecuteQuery(new ApiDataAccess(this, pScript, pParams));
		}

		/*--------------------------------------------------------------------------------------------*/
		public ApiDataAccess ExecuteQuery(IWeaverQuery pQuery) {
			return ExecuteQuery(new ApiDataAccess(this, pQuery));
		}

		/*--------------------------------------------------------------------------------------------*/
		private ApiDataAccess ExecuteQuery(ApiDataAccess pDbQuery) {
			pDbQuery.Execute();
			DbQueryExecutionCount++;
			return pDbQuery;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public T QueryForSingle<T>(string pScript,
								IDictionary<string, string> pParams=null) where T : INode, new() {
			var a = new ApiDataAccess<T>(this, pScript, pParams);
			return ExecuteQuery(a).TypedResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public T QueryForSingle<T>(IWeaverQuery pQuery) where T : INode, new() {
			var a = new ApiDataAccess<T>(this, pQuery);
			return ExecuteQuery(a).TypedResult;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<T> QueryForList<T>(string pScript,
								IDictionary<string, string> pParams=null) where T : INode, new() {
			var a = new ApiDataAccess<T>(this, pScript, pParams);
			return ExecuteQuery(a).TypedResultList;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<T> QueryForList<T>(IWeaverQuery pQuery) where T : INode, new() {
			var a = new ApiDataAccess<T>(this, pQuery);
			return ExecuteQuery(a).TypedResultList;
		}

		/*--------------------------------------------------------------------------------------------*/
		private ApiDataAccess<T> ExecuteQuery<T>(ApiDataAccess<T> pDbQuery) where T : INode, new() {
			pDbQuery.Execute();
			DbQueryExecutionCount++;
			return pDbQuery;
		}

	}

}