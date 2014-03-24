using System;
using System.Collections.Generic;
using System.Threading;
using metrics;
using metrics.Core;

namespace Fabric.Infrastructure.Broadcast {
	
	/*================================================================================================*/
	public class MetricsManager : IMetricsManager { //TEST: MetricsManager

		private readonly GraphiteTcp vGraphite;
		private readonly Timer vTimer;

		private HashSet<string> vTimerPaths;
		private HashSet<string> vMeanPaths;
		private HashSet<string> vCounterPaths;
		private HashSet<string> vGaugePaths;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MetricsManager(string pHost, int pPort, string pPrefix, int pFrequencyMillis=10000) {
			vGraphite = new GraphiteTcp(pHost, pPort, pPrefix);
			vTimer = new Timer(SendData, null, pFrequencyMillis, pFrequencyMillis);
			ResetPaths(true);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ResetPaths(bool pResetGauges=false) {
			vTimerPaths = new HashSet<string>();
			vMeanPaths = new HashSet<string>();
			vCounterPaths = new HashSet<string>();

			if ( pResetGauges ) {
				vGaugePaths = new HashSet<string>();
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Timer(string pPath, long pMilliseconds) {
			Metrics.ManualTimer(GetType(), pPath, TimeUnit.Milliseconds, TimeUnit.Milliseconds)
				.RecordElapsedMillis(pMilliseconds);
			vTimerPaths.Add(pPath);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Mean(string pPath, long pValue) {
			Metrics.Histogram(GetType(), pPath).Update(pValue);
			vMeanPaths.Add(pPath);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Counter(string pPath, long pIncrement) {
			Metrics.Counter(GetType(), pPath).Increment(pIncrement);
			vCounterPaths.Add(pPath);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Gauge(string pPath, Func<long> pEvaluator) {
			Metrics.Gauge(GetType(), pPath, pEvaluator);
			vGaugePaths.Add(pPath);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void SendData(object pState) {

			foreach ( string path in vTimerPaths ) {
				ManualTimerMetric mtm = Metrics.ManualTimer(GetType(), path,
					TimeUnit.Milliseconds, TimeUnit.Milliseconds);
				double[] perc = mtm.Percentiles(0.95, 0.99);

				vGraphite.Send(path+".timer.mean", mtm.Mean);
				vGraphite.Send(path+".timer.p95", perc[0]);
				vGraphite.Send(path+".timer.p99", perc[1]);
				mtm.Clear();
			}

			foreach ( string path in vMeanPaths ) {
				HistogramMetric hm = Metrics.Histogram(GetType(), path);
				vGraphite.Send(path+".mean", hm.Mean);
				hm.Clear();
			}

			foreach ( string path in vCounterPaths ) {
				CounterMetric cm = Metrics.Counter(GetType(), path);
				vGraphite.Send(path+".counter", cm.Count);
				cm.Clear();
			}

			foreach ( string path in vGaugePaths ) {
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