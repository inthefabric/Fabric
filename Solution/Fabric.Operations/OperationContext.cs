using System;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Cache;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Query;
using Fabric.New.Infrastructure.Util;

namespace Fabric.New.Operations {

	/*================================================================================================*/
	public class OperationContext : IOperationContext {

		//private static readonly Logger Log = Logger.Build<OperationContext>();

		public Guid ContextId { get; private set; }
		public IOperationAuth Auth { get; protected set; }
		public IOperationData Data { get; private set; }
		public IAnalyticsManager Analytics { get; private set; }
		public IMetricsManager Metrics { get; private set; }
		public ICacheManager Cache { get; private set; }

		//private readonly Stopwatch vProfiler;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OperationContext(IDataAccessFactory pAccessFactory, ICacheManager pCache,
						IMetricsManager pMetrics, Func<Guid, IAnalyticsManager> pAnalyticsProvider) {
			Metrics = pMetrics;
			Cache = pCache;

			ContextId = Guid.NewGuid();
			Data = new OperationData(ContextId, pAccessFactory, Metrics, Cache.Memory);
			Auth = new OperationAuth(() => Data.Build(), () => UtcNow.Ticks);
			Analytics = pAnalyticsProvider(ContextId);

			//vProfiler = new Stopwatch();
			//vProfiler.Start();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual DateTime UtcNow {
			get { return DateTime.UtcNow; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual string Code32 {
			get { return DataUtil.Code32; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual long GetSharpflakeId<T>() where T : IVertex {
			return Sharpflake.GetId<T>();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		public void ProfilerTrace(object pObj, string pName) {
			ProfilerTrace(pObj.GetType().Name, pName);
		}

		/*--------------------------------------------------------------------------------------------* /
		public void ProfilerTrace(string pObjName, string pName) {
			Log.Debug("---> "+String.Format("{0,7:##0.000}", vProfiler.Elapsed.TotalMilliseconds)+
				"ms ("+pObjName+"."+pName+")");
		}*/

	}

}