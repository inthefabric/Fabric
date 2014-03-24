using System;

namespace Fabric.New.Infrastructure.Broadcast {

	/*================================================================================================*/
	public interface IMetricsManager : IDisposable {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Timer(string pPath, long pMilliseconds);
		void Mean(string pPath, long pValue);
		void Counter(string pPath, long pIncrement);
		void Gauge(string pPath, Func<long> pEvaluator);

	}

}