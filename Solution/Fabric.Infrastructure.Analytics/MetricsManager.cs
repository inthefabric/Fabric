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
		private readonly HashSet<string> vRangePaths;
		private readonly HashSet<string> vCounterPaths;
		private readonly HashSet<string> vGaugePaths;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MetricsManager(string pHost, int pPort, string pPrefix, int pFrequencyMillis=10000) {
			Log.Debug("CREATE MEM MGR");
			vGraphite = new GraphiteUdp(pHost, pPort, pPrefix);
			vTimer = new Timer(SendData, null, pFrequencyMillis, pFrequencyMillis);

			vTimerPaths = new HashSet<string>();
			vRangePaths = new HashSet<string>();
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
		public void Range(string pPath, long pValue) {
			vRangePaths.Add(pPath);
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
			Log.Debug("SEND DATA!");

			foreach ( string path in vTimerPaths ) {
				ManualTimerMetric mtm = Metrics.ManualTimer(GetType(), path, 
					TimeUnit.Milliseconds, TimeUnit.Milliseconds);
				double[] perc = mtm.Percentiles(0.95, 0.99);

				vGraphite.Send(path+".timer.m1_rate", mtm.OneMinuteRate);
				vGraphite.Send(path+".timer.mean", mtm.Mean);
				vGraphite.Send(path+".timer.count", mtm.Count);
				vGraphite.Send(path+".timer.p95", perc[0]);
				vGraphite.Send(path+".timer.p99", perc[1]);
			}

			foreach ( string path in vRangePaths ) {
				HistogramMetric hm = Metrics.Histogram(GetType(), path);
				vGraphite.Send(path+".range.mean", hm.Mean);
				vGraphite.Send(path+".range.min", hm.Min);
				vGraphite.Send(path+".range.max", hm.Max);
			}

			foreach ( string path in vCounterPaths ) {
				CounterMetric cm = Metrics.Counter(GetType(), path);
				vGraphite.Send(path+".counter", cm.Count);
			}

			foreach ( string path in vGaugePaths ) {
				GaugeMetric<long> gm = Metrics.Gauge<long>(GetType(), path, null);
				vGraphite.Send(path+".gauge", gm.Value);
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Dispose() {
			Log.Debug("DISPOSE!");
			SendData(null);
			vGraphite.Dispose();
			vTimer.Dispose();
		}

	}

}