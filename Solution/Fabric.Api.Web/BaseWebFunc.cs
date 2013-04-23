using Fabric.Api.Web.Tasks;
using Fabric.Infrastructure.Api;

namespace Fabric.Api.Web {
	
	/*================================================================================================*/
	public abstract class BaseWebFunc<TReturn> : ApiFunc<TReturn> {

		protected IWebTasks Tasks { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected BaseWebFunc(IWebTasks pTasks) {
			Tasks = pTasks;
		}

	}

}