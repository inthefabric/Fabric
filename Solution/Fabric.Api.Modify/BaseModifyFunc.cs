using Fabric.Api.Modify.Tasks;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	public abstract class BaseModifyFunc<TReturn> : ApiFunc<TReturn> {

		protected IModifyTasks Tasks { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected BaseModifyFunc(IModifyTasks pTasks) {
			Tasks = pTasks;
		}

	}

}