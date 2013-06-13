using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Analytics;
using Fabric.Infrastructure.Db;
using Weaver.Core.Query;

namespace Fabric.Infrastructure.Api {
	
	/*================================================================================================*/
	public interface IApiContext {

		string RexConnUrl { get; }
		int RexConnPort { get; }

		Guid ContextId { get; }
		long UserId { get; }
		long AppId { get; }
		AnalyticsManager Analytics { get; }
		ICacheManager Cache { get; }

		int DbQueryExecutionCount { get; }
		int DbQueryMillis { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void SetAppUserId(long? pAppId, long? pUserId);

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		DateTime UtcNow { get; }
		string Code32 { get; }
		long GetSharpflakeId<T>() where T : INode;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IApiDataAccess DbData(string pQueryName, IWeaverScript pScripted);

		/*--------------------------------------------------------------------------------------------*/
		IApiDataAccess DbData(string pQueryName, IList<IWeaverScript> pScriptedList);
		
		/*--------------------------------------------------------------------------------------------*/
		IApiDataAccess DbData(string pQueryName, RexConnTcpRequest pRequest);
		
		/*--------------------------------------------------------------------------------------------*/
		T DbNodeById<T>(long pTypeId) where T : class, INode<T>, INodeWithId, new();
		
		/*--------------------------------------------------------------------------------------------*/
		T DbSingle<T>(string pQueryName, IWeaverScript pScripted) where T : class, IItemWithId, new();

		/*--------------------------------------------------------------------------------------------*/
		IList<T> DbList<T>(string pQueryName, IWeaverScript pScripted) where T : IItemWithId, new();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void ProfilerTrace(object pObj, string pName);
		void ProfilerTrace(string pObjName, string pName);

	}

}