using System;
using Fabric.Db.Server.Query;
using Fabric.Infrastructure;
using Nancy;

namespace Fabric.Db.Server {

	/*================================================================================================*/
	public class DbModule : NancyModule {

		public const string GremlinUri = "http://localhost:8182/graphs/Fabric/tp/gremlin";

		private readonly Guid vRequestId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DbModule() {
			Log.ConfigureOnce();
			vRequestId = Guid.NewGuid();
			Post["/(.*)"] = (p => new QueryHandler(Context, vRequestId, GremlinUri).GetResponse());
		}

	}

}