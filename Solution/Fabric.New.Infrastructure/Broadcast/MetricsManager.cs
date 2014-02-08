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

		private ConcurrentQueue<string> vTimerPaths;
		private ConcurrentQueue<string> vMeanPaths;
		private ConcurrentQueue<string> vCounterPaths;
		private ConcurrentQueue<string> vGaugePaths;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MetricsManager(string pHost, int pPort, string pPrefix, int pFrequencyMillis=10000) {
			vGraphite = new GraphiteTcp(pHost, pPort, pPrefix);
			vTimer = new Timer(SendData, null, pFrequencyMillis, pFrequencyMillis);
			ResetPaths(true);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ResetPaths(bool pResetGauges=false) {
			vTimerPaths = new ConcurrentQueue<string>();
			vMeanPaths = new ConcurrentQueue<string>();
			vCounterPaths = new ConcurrentQueue<string>();

			if ( pResetGauges ) {
				vGaugePaths = new ConcurrentQueue<string>();
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Timer(string pPath, long pMilliseconds) {
			vTimerPaths.Enqueue(pPath);
			Metrics.ManualTimer(GetType(), pPath, TimeUnit.Milliseconds, TimeUnit.Milliseconds)
				.RecordElapsedMillis(pMilliseconds);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Mean(string pPath, long pValue) {
			vMeanPaths.Enqueue(pPath);
			Metrics.Histogram(GetType(), pPath).Update(pValue);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Counter(string pPath, long pIncrement) {
			vCounterPaths.Enqueue(pPath);
			Metrics.Counter(GetType(), pPath).Increment(pIncrement);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Gauge(string pPath, Func<long> pEvaluator) {
			vGaugePaths.Enqueue(pPath);
			Metrics.Gauge(GetType(), pPath, pEvaluator);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void SendData(object pState) {
			string path;

			while ( vTimerPaths.TryDequeue(out path) ) {
				ManualTimerMetric mtm = Metrics.ManualTimer(GetType(), path,
					TimeUnit.Milliseconds, TimeUnit.Milliseconds);
				double[] perc = mtm.Percentiles(0.95, 0.99);

				vGraphite.Send(path+".timer.mean", mtm.Mean);
				vGraphite.Send(path+".timer.p95", perc[0]);
				vGraphite.Send(path+".timer.p99", perc[1]);
				mtm.Clear();
			}

			while ( vMeanPaths.TryDequeue(out path) ) {
				HistogramMetric hm = Metrics.Histogram(GetType(), path);
				vGraphite.Send(path+".mean", hm.Mean);
				hm.Clear();
			}

			while ( vCounterPaths.TryDequeue(out path) ) {
				CounterMetric cm = Metrics.Counter(GetType(), path);
				vGraphite.Send(path+".counter", cm.Count);
				cm.Clear();
			}

			while ( vGaugePaths.TryDequeue(out path) ) {
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