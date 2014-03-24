using Fabric.Api.Objects;
using Fabric.Domain;

namespace Fabric.Operations.Create {


	/*================================================================================================*/
	public interface ICreateOperation<TDom, out TApi> where TDom : Vertex where TApi : FabVertex {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		TDom Execute(IOperationContext pOpCtx, ICreateOperationBuilder pBuild,
			CreateOperationTasks pTasks, string pJson);

		/*--------------------------------------------------------------------------------------------*/
		TApi ConvertResult(TDom pDom);

	}

}