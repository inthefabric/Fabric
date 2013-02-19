using Fabric.Api.Web.Tasks;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Web {
	
	/*================================================================================================*/
	public abstract class BaseWebFunc<TReturn> : ApiFunc<TReturn> {

		protected IWebTasks Tasks { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected BaseWebFunc(IWebTasks pTasks) {
			Tasks = pTasks;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void EnsureFabricSystem() {
			if ( ApiCtx.AppId != (long)AppId.FabricSystem ) {
				throw new FabPreventedFault(FabFault.Code.ActionNotPermitted,
					"The authenticated App (AppId="+ApiCtx.AppId+") is not permitted "+
					"to perform this action.");
			}
		}

	}

}