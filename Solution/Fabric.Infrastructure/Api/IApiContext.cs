using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Analytics;
using Fabric.Infrastructure.Data;
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

		/*--------------------------------------------------------------------------------------------*/
		DateTime UtcNow { get; }
		string Code32 { get; }
		long GetSharpflakeId<T>() where T : IVertex;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IDataAccess GetData(string pSessionId=null);
		T GetVertexById<T>(long pTypeId) where T : class, IVertex, IVertexWithId, new();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IApiDataAccess DbData(string pQueryName, IWeaverScript pScripted);
		IApiDataAccess DbData(string pQueryName, IList<IWeaverScript> pScriptedList);
		//IApiDataAccess DbData(string pQueryName, WeaverRequest pRequest);
		T DbVertexById<T>(long pTypeId) where T : class, IVertex, IVertexWithId, new();
		T DbSingle<T>(string pQueryName, IWeaverScript pScripted) where T : class, IElementWithId, new();
		//IList<T> DbList<T>(string pQueryName, IWeaverScript pScripted) where T : IElementWithId, new();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void ProfilerTrace(object pObj, string pName);
		void ProfilerTrace(string pObjName, string pName);

	}

}