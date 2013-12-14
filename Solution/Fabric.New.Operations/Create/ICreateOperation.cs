using Fabric.New.Api.Objects;
using Fabric.New.Domain;

namespace Fabric.New.Operations.Create {


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