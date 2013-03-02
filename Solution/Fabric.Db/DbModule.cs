using System.Configuration;
using Fabric.Db.Gremlin;
using Fabric.Infrastructure;
using Nancy;

namespace Fabric.Db {

	/*================================================================================================*/
	public class DbModule : NancyModule {

#if DEBUG
		private const string RexKey = "Dev_Rex";
#else
		private const string RexKey = "Prod_Rex";
#endif

		public static readonly string RexUrl = ConfigurationManager.AppSettings[RexKey];
		public static readonly string GremlinUri = "http://"+RexUrl+"/graphs/Fabric/tp/gremlin";


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DbModule() {
			Log.ConfigureOnce();
			Get["/"] = (p => "Fabric Database Server");
			Post["/gremlin"] = (p => new GremlinController(Context.Request, GremlinUri).GetResponse());
		}

	}

}