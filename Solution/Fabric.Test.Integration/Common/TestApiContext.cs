using System;
using System.Collections.Generic;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Caching;
using Weaver.Interfaces;

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

		/*--------------------------------------------------------------------------------------------* /
		public override string Code32 {
			get { return (TestUtcNow == null ? base.Code32 : TestCode32); }
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
		protected override IApiDataAccess NewAccess(IWeaverScript pScripted) {
			return new TestApiDataAccess(this, pScripted);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override IApiDataAccess<T> NewAccess<T>(IWeaverScript pScripted) {
			return new TestApiDataAccess<T>(this, pScripted);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override IApiDataAccess NewAccess(IList<IWeaverScript> pScriptedList) {
			return new TestApiDataAccess(this, pScriptedList);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override IApiDataAccess DbDataAccess(string pQueryName, IApiDataAccess pDbQuery) {
			Log.Info("Query ("+pQueryName+") ExCount="+DbQueryExecutionCount+", NumCmds="+
				pDbQuery.Request.CmdList.Count);
			return base.DbDataAccess(pQueryName, pDbQuery);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override IApiDataAccess<T> DbDataAccess<T>(string pQueryName,
																		IApiDataAccess<T> pDbQuery) {
			Log.Info("Query<"+typeof(T).Name+"> ("+pQueryName+") ExCount="+DbQueryExecutionCount+
				", NumCmds="+pDbQuery.Request.CmdList.Count);
			return base.DbDataAccess(pQueryName, pDbQuery);
		}

	}

}