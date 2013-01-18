using Fabric.Db.Server.Gremlin;
using Fabric.Infrastructure;
using Nancy;

namespace Fabric.Db.Server {

	/*================================================================================================*/
	public class DbModule : NancyModule {

		public const string GremlinUri = "http://localhost:8182/graphs/Fabric/tp/gremlin";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DbModule() {
			Log.ConfigureOnce();
			Post["/gremlin"] = (p => new GremlinDbQuery(Context, GremlinUri).GetResponse());
		}

	}

}