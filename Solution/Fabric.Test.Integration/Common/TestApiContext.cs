using System;
using System.Collections.Generic;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Analytics;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Caching;
using Fabric.Infrastructure.Data;
using RexConnectClient.Core.Result;

namespace Fabric.Test.Integration.Common {
	
	/*================================================================================================*/
	public class TestApiContext : ApiContext {

		private static readonly MetricsManager TestMetrics =
			new MetricsManager("graphite.inthefabric.net", 2003, "api.test", 1000);
		private static readonly Func<Guid, IAnalyticsManager> TestAnalyt = (g=>new AnalyticsManager(g));

		public DateTime? TestUtcNow { get; set; }
		public IList<long> SharpflakeIds { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestApiContext() : base("rexster", 8185, new CacheManager(TestMetrics, true),
																			TestMetrics, TestAnalyt) {
			SharpflakeIds = new List<long>();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override DateTime UtcNow {
			get {
				return (TestUtcNow == null ? base.UtcNow : (DateTime)TestUtcNow);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public override long GetSharpflakeId<T>() {
			lock ( this ) {
				long id = Sharpflake.GetId<T>();
				SharpflakeIds.Add(id);
				return id;
			}
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void OnDataPostExecute(IDataAccess pAccess, IResponseResult pResult) {
			base.OnDataPostExecute(pAccess, pResult);
			Log.Info("Query: "+pResult.ExecutionMilliseconds+"ms ("+pResult.Response.Timer+"ms)");
			Log.Info("");
		}

	}

}