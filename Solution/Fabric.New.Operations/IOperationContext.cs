using System;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Cache;
using Fabric.New.Infrastructure.Data;

namespace Fabric.New.Operations {
	
	/*================================================================================================*/
	public interface IOperationContext {

		string RexConnUrl { get; }
		int RexConnPort { get; }

		Guid ContextId { get; }
		long MemberId { get; }
		//long UserId { get; }
		//long AppId { get; }
		IAnalyticsManager Analytics { get; }
		IMetricsManager Metrics { get; }
		ICacheManager Cache { get; }

		int DbQueryExecutionCount { get; }
		int DbQueryMillis { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		//void SetAppUserId(long? pAppId, long? pUserId);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		DateTime UtcNow { get; }

		/*--------------------------------------------------------------------------------------------*/
		string Code32 { get; }

		/*--------------------------------------------------------------------------------------------*/
		long GetSharpflakeId<T>() where T : IVertex;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IDataAccess NewData(string pSessionId=null, bool pSetCmdIds=false, bool pOmitCmdTimers=true);


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void ProfilerTrace(object pObj, string pName);

		/*--------------------------------------------------------------------------------------------*/
		void ProfilerTrace(string pObjName, string pName);

	}

}