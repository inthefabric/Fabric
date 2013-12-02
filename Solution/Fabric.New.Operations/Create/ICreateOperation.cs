using Fabric.New.Api.Objects;
using Fabric.New.Infrastructure.Query;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public interface ICreateOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Create(IOperationContext pOpCtx, ITxBuilder pTxBuild, string pJson);

		/*--------------------------------------------------------------------------------------------*/
		FabObject GetResult();

	}

}