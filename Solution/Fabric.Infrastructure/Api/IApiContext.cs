using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Analytics;
using Weaver.Interfaces;

namespace Fabric.Infrastructure.Api {
	
	/*================================================================================================*/
	public interface IApiContext {

		string RexConnUrl { get; }
		int RexConnPort { get; }

		Guid ContextId { get; }
		long UserId { get; }
		long AppId { get; }
		//long MemberId { get; }
		AnalyticsManager Analytics { get; }
		ICacheManager Cache { get; }

		int DbQueryExecutionCount { get; }
		int DbQueryMillis { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void SetAppUserId(long? pAppId, long? pUserId);
		//void SetMemberId(long pMemberId);

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		DateTime UtcNow { get; }
		string Code32 { get; }
		long GetSharpflakeId<T>() where T : INode;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IApiDataAccess DbData(string pQueryName, IWeaverScript pScripted);
		
		/*--------------------------------------------------------------------------------------------*/
		T DbSingle<T>(string pQueryName, IWeaverScript pScripted) where T : class, IItemWithId, new();

		/*--------------------------------------------------------------------------------------------*/
		IList<T> DbList<T>(string pQueryName, IWeaverScript pScripted) where T : IItemWithId, new();

	}

}