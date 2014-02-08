using System;
using System.Collections.Concurrent;
using System.Threading;
using metrics;
using metrics.Core;

namespace Fabric.New.Infrastructure.Broadcast {
	
	/*================================================================================================*/
	public class MetricsManager : IMetricsManager { //TEST: MetricsManager

		private readonly GraphiteTcp vGraphite;
		private readonly Timer vTimer;

		private ConcurrentDictionary<string, bool> vTimerPaths;
		private ConcurrentDictionary<string, bool> vMeanPaths;
		private ConcurrentDictionary<string, bool> vCounterPaths;
		private ConcurrentDictionary<string, bool> vGaugePaths;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MetricsManager(string pHost, int pPort, string pPrefix, int pFrequencyMillis=10000) {
			vGraphite = new GraphiteTcp(pHost, pPort, pPrefix);
			vTimer = new Timer(SendData, null, pFrequencyMillis, pFrequencyMillis);
			ResetPaths(true);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ResetPaths(bool pResetGauges=false) {
			vTimerPaths = new ConcurrentDictionary<string, bool>();
			vMeanPaths = new ConcurrentDictionary<string, bool>();
			vCounterPaths = new ConcurrentDictionary<string, bool>();

			if ( pResetGauges ) {
				vGaugePaths = new ConcurrentDictionary<string, bool>();
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Timer(string pPath, long pMilliseconds) {
			vTimerPaths.GetOrAdd(pPath, true);
			Metrics.ManualTimer(GetType(), pPath, TimeUnit.Milliseconds, TimeUnit.Milliseconds)
				.RecordElapsedMillis(pMilliseconds);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Mean(string pPath, long pValue) {
			vMeanPaths.GetOrAdd(pPath, true);
			Metrics.Histogram(GetType(), pPath).Update(pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Counter(string pPath, long pIncrement) {
			vCounterPaths.GetOrAdd(pPath, true);
			Metrics.Counter(GetType(), pPath).Increment(pIncrement);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Gauge(string pPath, Func<long> pEvaluator) {
			vGaugePaths.GetOrAdd(pPath, true);
			Metrics.Gauge(GetType(), pPath, pEvaluator);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void SendData(object pState) {
			foreach ( string path in vTimerPaths.Keys ) {
				ManualTimerMetric mtm = Metrics.ManualTimer(GetType(), path, 
					TimeUnit.Milliseconds, TimeUnit.Milliseconds);
				double[] perc = mtm.Percentiles(0.95, 0.99);

				vGraphite.Send(path+".timer.mean", mtm.Mean);
				vGraphite.Send(path+".timer.p95", perc[0]);
				vGraphite.Send(path+".timer.p99", perc[1]);
				mtm.Clear();
			}

			foreach ( string path in vMeanPaths.Keys ) {
				HistogramMetric hm = Metrics.Histogram(GetType(), path);
				vGraphite.Send(path+".mean", hm.Mean);
				hm.Clear();
			}

			foreach ( string path in vCounterPaths.Keys ) {
				CounterMetric cm = Metrics.Counter(GetType(), path);
				vGraphite.Send(path+".counter", cm.Count);
				cm.Clear();
			}

			foreach ( string path in vGaugePaths.Keys ) {
				GaugeMetric<long> gm = Metrics.Gauge<long>(GetType(), path, null);
				vGraphite.Send(path+".gauge", gm.Value);
			}

			ResetPaths();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Dispose() {
			SendData(null);
			vGraphite.Dispose();
			vTimer.Dispose();
		}

	}

}