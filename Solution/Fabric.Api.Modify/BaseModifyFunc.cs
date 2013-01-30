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
		protected void EnsureFabricSystem() { //TEST: BaseModifyFunc.EnsureFabricSystem()
			if ( Context.AppId != (long)AppId.FabricSystem ) {
				throw new FabPreventedFault(Context.AppId);
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected Member GetContextMember() { //TEST: BaseModifyFunc.GetContextMember()
			Member m = Tasks.GetValidMemberByContext(Context);

			if ( m == null ) {
				throw new FabMembershipFault(Context.AppId, Context.UserId);
			}

			return m;
		}

	}

}