using System;
using System.Collections.Generic;
using Fabric.New.Infrastructure.Broadcast;
using Fabric.New.Infrastructure.Cache;
using Fabric.New.Infrastructure.Data;
using Fabric.New.Infrastructure.Query;
using Fabric.New.Operations;
using Moq;
using Weaver.Core.Query;

namespace Fabric.New.Test.Integration.Shared {
	
	/*================================================================================================*/
	public class TestOperationContext : OperationContext {

		private static readonly MetricsManager TestMetrics =
			new MetricsManager("graphite.inthefabric.net", 2003, "api.test", 1000);
		private static readonly CacheManager CacheMgr = new CacheManager(TestMetrics);
		private static readonly Func<Guid, IAnalyticsManager> TestAnalyt = (g=>new AnalyticsManager(g));
		private static readonly DataAccessFactory DataAccFact = new DataAccessFactory(
			new[] { "rexster" }, 8185, CacheMgr);

		public DateTime? TestUtcNow { get; set; }
		public IList<long> SharpflakeIds { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestOperationContext() : base(DataAccFact, CacheMgr, TestMetrics, TestAnalyt) {
			SharpflakeIds = new List<long>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public void SetMockAuth(Mock<IOperationAuth> pMockAuth) {
			Auth = pMockAuth.Object;
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
		public IDataResult ExecuteForTest(IWeaverQuery pQuery, string pName=null) {
			return Data.Execute(pQuery, "TestQuery"+(pName == null ? "" : "-"+pName));
		}

	}

}