using System;
using System.Collections.Generic;
using System.Threading;
using Fabric.Infrastructure.Api;
using metrics;
using metrics.Core;

namespace Fabric.Infrastructure.Analytics {
	
	/*================================================================================================*/
	public class MetricsManager : IMetricsManager {

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
			ResetPaths();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void ResetPaths() {
			vTimerPaths = new HashSet<string>();
			vMeanPaths = new HashSet<string>();
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
		public void Mean(string pPath, long pValue) {
			vMeanPaths.Add(pPath);
			Metrics.Histogram(GetType(), pPath).Update(pValue);
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