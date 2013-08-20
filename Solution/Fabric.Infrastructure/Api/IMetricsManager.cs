using System;

namespace Fabric.Infrastructure.Api {

	/*================================================================================================*/
	public interface IMetricsManager {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Timer(string pPath, long pMilliseconds);
		void Counter(string pPath, long pIncrement);
		void Gauge(string pPath, Func<long> pEvaluator);

	}

}