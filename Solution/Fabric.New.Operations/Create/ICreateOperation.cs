using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Query;

namespace Fabric.New.Operations.Create {


	/*================================================================================================*/
	public interface ICreateOperation<TDom, TApi> where TDom : Vertex where TApi : FabVertex {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Create(IOperationContext pOpCtx, ITxBuilder pTxBuild, string pJson);
		
		/*--------------------------------------------------------------------------------------------*/
		TDom Execute();

		/*--------------------------------------------------------------------------------------------*/
		TApi GetResult();

	}

}