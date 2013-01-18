using System;
using System.Collections.Generic;
using Fabric.Db.Server.Query;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.Common {

	/*================================================================================================*/
	public class TestApiDataAccess<T> : ApiDataAccess<T> where T : INodeWithId, new() {

		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TestApiDataAccess(IApiContext pContext, string pScript, 
						IDictionary<string, string> pParams=null) : base(pContext, pScript, pParams) {}

		/*--------------------------------------------------------------------------------------------*/
		public TestApiDataAccess(IApiContext pContext, IWeaverScript pScripted) :
												this(pContext, pScripted.Script, pScripted.Params) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override string GetResultString() {
			string q = TestApiDataAccess.CleanQueryIndexIds(Query);
			var qh = new QueryHandler(q, new Guid(), TestApiDataAccess.GremlinUri);
			return qh.GetJson();
		}

	}

}