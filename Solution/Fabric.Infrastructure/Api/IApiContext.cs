using System;
using Fabric.Domain;
using Fabric.Infrastructure.Data;

namespace Fabric.Infrastructure.Api {
	
	/*================================================================================================*/
	public interface IApiContext {

		string RexConnUrl { get; }
		int RexConnPort { get; }

		Guid ContextId { get; }
		long UserId { get; }
		long AppId { get; }
		IAnalyticsManager Analytics { get; }
		IMetricsManager Metrics { get; }
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
		IDataAccess NewData(string pSessionId=null);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void ProfilerTrace(object pObj, string pName);
		void ProfilerTrace(string pObjName, string pName);

	}

}