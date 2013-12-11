using Fabric.New.Api.Objects;
using Fabric.New.Domain;

namespace Fabric.New.Operations.Create {


	/*================================================================================================*/
	public interface ICreateOperation<out TDom, out TApi> where TDom : Vertex where TApi : FabVertex {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Create(IOperationContext pOpCtx, CreateOperationTasks pTasks, string pJson);
		
		/*--------------------------------------------------------------------------------------------*/
		TDom Execute();

		/*--------------------------------------------------------------------------------------------*/
		TApi GetResult();

	}

}