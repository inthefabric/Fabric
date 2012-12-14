﻿namespace Fabric.Api.Paths.Steps {

	/*================================================================================================*/
	public interface IStep : IBaseStep {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void SetDataAndUpdatePath(StepData pData);
		IStep GetNextStep(string pStepText, bool pSetData=true);
		int GetPathIndex();

	}

}