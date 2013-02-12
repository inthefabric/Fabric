using Fabric.Api.Traversal.Steps.Functions;

namespace Fabric.Api.Traversal.Steps {

	/*================================================================================================*/
	public interface IStep : IBaseStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void SetDataAndUpdatePath(StepData pData);
		IStep GetNextStep(string pStepText, bool pSetData=true, IFuncStep pProxyForFunc=null);
		int GetPathIndex();

	}

}