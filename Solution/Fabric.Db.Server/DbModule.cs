using System;
using Fabric.Db.Server.Query;
using Fabric.Infrastructure;
using Nancy;

namespace Fabric.Db.Server {

	/*================================================================================================*/
	public class DbModule : NancyModule {

		private readonly Guid vRequestId;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DbModule() {
			Log.ConfigureOnce();
			vRequestId = Guid.NewGuid();
			Post["/(.*)"] = (p => new QueryHandler(Context, vRequestId).GetResponse());
		}

	}

}