using System;
using System.Collections.Generic;
using Weaver;

namespace Fabric.Infrastructure.Api {
	
	/*================================================================================================*/
	public class ApiRequestContext {

		public string DbServerUrl { get; private set; }

		public long UserId { get; private set; }
		public long AppId { get; private set; }
		public long MemberId { get; private set; }

		public long DbQueryExecutionCount { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiRequestContext(string pDbServerUrl) {
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
		public DbQuery ExecuteQuery(string pScript, IDictionary<string, string> pParams=null) {
			return ExecuteQuery(new DbQuery(this, pScript, pParams));
		}

		/*--------------------------------------------------------------------------------------------*/
		public DbQuery ExecuteQuery(WeaverQuery pQuery) {
			return ExecuteQuery(new DbQuery(this, pQuery));
		}

		/*--------------------------------------------------------------------------------------------*/
		private DbQuery ExecuteQuery(DbQuery pDbQuery) {
			pDbQuery.Execute();
			DbQueryExecutionCount++;
			return pDbQuery;
		}

	}

}