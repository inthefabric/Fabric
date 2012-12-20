using Fabric.Api.Paths.Steps.Functions;

namespace Fabric.Api.Paths.Steps {

	/*================================================================================================*/
	public interface IStep : IBaseStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void SetDataAndUpdatePath(StepData pData);
		IStep GetNextStep(string pStepText, bool pSetData=true, IFuncStep pProxyForFunc=null);
		int GetPathIndex();

	}

}