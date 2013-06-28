using System;
using System.Collections.Generic;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Caching;
using RexConnectClient.Core.Result;
using Weaver.Core.Query;

namespace Fabric.Test.Integration.Common {
	
	/*================================================================================================*/
	public class TestApiContext : ApiContext {

		public DateTime? TestUtcNow { get; set; }
		public IList<long> SharpflakeIds { get; private set; }
		public Func<string, string> AlterRequestJson { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestApiContext() : base("rexster", 8185, new CacheManager("ApiTest", true)) {
			SharpflakeIds = new List<long>();
			AlterRequestJson = (r => r);
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
		protected override void OnDataPostExecute(IResponseResult pResult) {
			base.OnDataPostExecute(pResult);
			Log.Info("Query: "+pResult.ExecutionMilliseconds+"ms ("+pResult.Response.Timer+"ms)");
			Log.Info("");
		}

	}

}