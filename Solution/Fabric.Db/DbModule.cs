using Fabric.Db.Gremlin;
using Fabric.Infrastructure;
using Nancy;

namespace Fabric.Db {

	/*================================================================================================*/
	public class DbModule : NancyModule {

		public const string GremlinUri = "http://rexster:8182/graphs/Fabric/tp/gremlin";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DbModule() {
			Log.ConfigureOnce();
			Get["/"] = (p => "Fabric Database Server");
			Post["/gremlin"] = (p => new GremlinController(Context.Request, GremlinUri).GetResponse());
		}

	}

}