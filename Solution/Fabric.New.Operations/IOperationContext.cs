using System;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Cache;
using Fabric.New.Infrastructure.Data;

namespace Fabric.New.Operations {
	
	/*================================================================================================*/
	public interface IOperationContext {

		Guid ContextId { get; }
		IOperationAccess Access { get; }
		IAnalyticsManager Analytics { get; }
		IMetricsManager Metrics { get; }
		ICacheManager Cache { get; }

		int DbQueryExecutionCount { get; }
		int DbQueryMillis { get; }


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