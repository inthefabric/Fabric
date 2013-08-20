using System;
using System.Collections.Generic;
using System.Threading;
using Fabric.Infrastructure.Api;
using metrics;
using metrics.Core;

namespace Fabric.Infrastructure.Analytics {
	
	/*================================================================================================*/
	public class MetricsManager : IMetricsManager {

		private readonly GraphiteUdp vGraphite;
		private readonly Timer vTimer;

		private readonly HashSet<string> vTimerPaths;
		private readonly HashSet<string> vCounterPaths;
		private readonly HashSet<string> vGaugePaths;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MetricsManager(string pHost, int pPort, string pPrefix, int pFrequencyMillis=10000) {
			vGraphite = new GraphiteUdp(pHost, pPort, pPrefix);
			vTimer = new Timer(SendData, null, pFrequencyMillis, pFrequencyMillis);

			vTimerPaths = new HashSet<string>();
			vCounterPaths = new HashSet<string>();
			vGaugePaths = new HashSet<string>();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Timer(string pPath, long pMilliseconds) {
			vTimerPaths.Add(pPath);
			Metrics.ManualTimer(GetType(), pPath, TimeUnit.Milliseconds, TimeUnit.Milliseconds)
				.RecordElapsedMillis(pMilliseconds);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Counter(string pPath, long pIncrement) {
			vCounterPaths.Add(pPath);
			Metrics.Counter(GetType(), pPath).Increment(pIncrement);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Gauge(string pPath, Func<long> pEvaluator) {
			vGaugePaths.Add(pPath);
			Metrics.Gauge(GetType(), pPath, pEvaluator);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void SendData(object pState) {
			foreach ( string path in vTimerPaths ) {
				ManualTimerMetric mtm = Metrics.ManualTimer(GetType(), path, 
					TimeUnit.Milliseconds, TimeUnit.Milliseconds);
				double[] perc = mtm.Percentiles(0.95, 0.99);

				vGraphite.Send(path+".m1_rate", mtm.OneMinuteRate);
				vGraphite.Send(path+".stddev", mtm.StdDev);
				vGraphite.Send(path+".mean", mtm.Mean);
				vGraphite.Send(path+".mean_rate", mtm.MeanRate);
				vGraphite.Send(path+".count", mtm.Count);
				vGraphite.Send(path+".p95", perc[0]);
				vGraphite.Send(path+".p99", perc[1]);
			}

			foreach ( string path in vCounterPaths ) {
				CounterMetric cm = Metrics.Counter(GetType(), path);
				vGraphite.Send(path, cm.Count);
			}

			foreach ( string path in vGaugePaths ) {
				GaugeMetric<long> gm = Metrics.Gauge<long>(GetType(), path, null);
				vGraphite.Send(path, gm.Value);
			}
		}

	}

}