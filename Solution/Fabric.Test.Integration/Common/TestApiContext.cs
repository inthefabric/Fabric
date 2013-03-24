﻿using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.Common {
	
	/*================================================================================================*/
	public class TestApiContext : ApiContext {

		public DateTime? TestUtcNow { get; set; }
		//public string TestCode32 { get; set; }
		public IList<long> SharpflakeIds { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestApiContext() : base("localhost", 8185, null, null) {
			SharpflakeIds = new List<long>();
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
			long id = Sharpflake.GetId<T>();
			SharpflakeIds.Add(id);
			return id;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override bool AddToCache<T>(string pKey, T pItem, int pExpiresInSec) {
			return false;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override T GetFromCache<T>(string pKey) {
			return default(T);
		}

		/*--------------------------------------------------------------------------------------------*/
		public override T RemoveFromCache<T>(string pKey) {
			return default(T);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		// TEST: ApiContext ClassName caching functionality and usages
		/*--------------------------------------------------------------------------------------------*/
		public override void AddToClassNameCache(long pClassId, string pName, string pDisamb) {}

		/*--------------------------------------------------------------------------------------------*/
		public override IList<long> GetClassIdsFromClassNameCache(string pName, string pDisamb) {
			return null;
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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override IApiDataAccess DbDataAccess(string pQueryName, IApiDataAccess pDbQuery) {
			Log.Info("Query ("+pQueryName+") "+DbQueryExecutionCount+": "+pDbQuery.Query);
			return base.DbDataAccess(pQueryName, pDbQuery);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override IApiDataAccess<T> DbDataAccess<T>(string pQueryName,
																		IApiDataAccess<T> pDbQuery) {
			Log.Info("Query<"+typeof(T).Name+"> ("+pQueryName+") "+
				DbQueryExecutionCount+": "+pDbQuery.Query);
			return base.DbDataAccess(pQueryName, pDbQuery);
		}

	}

}