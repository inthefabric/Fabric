using System;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Cache;

namespace Fabric.New.Operations {
	
	/*================================================================================================*/
	public interface IOperationContext {

		Guid ContextId { get; }
		IOperationData Data { get; }
		IOperationAuth Auth { get; }
		IAnalyticsManager Analytics { get; }
		IMetricsManager Metrics { get; }
		ICacheManager Cache { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		DateTime UtcNow { get; }

		/*--------------------------------------------------------------------------------------------*/
		string Code32 { get; }

		/*--------------------------------------------------------------------------------------------*/
		long GetSharpflakeId<T>() where T : IVertex;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		void ProfilerTrace(object pObj, string pName);

		/*--------------------------------------------------------------------------------------------* /
		void ProfilerTrace(string pObjName, string pName);*/

	}

}