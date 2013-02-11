using Fabric.Api.Modify.Tasks;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	public abstract class BaseModifyFunc<TReturn> : ApiFunc<TReturn> {

		protected IModifyTasks Tasks { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected BaseModifyFunc(IModifyTasks pTasks) {
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
		
		/*--------------------------------------------------------------------------------------------*/
		protected Member GetContextMember() {
			Member m = Tasks.GetValidMemberByContext(ApiCtx);

			if ( m == null ) {
				throw new FabMembershipFault(ApiCtx.AppId, ApiCtx.UserId);
			}

			return m;
		}

	}

}