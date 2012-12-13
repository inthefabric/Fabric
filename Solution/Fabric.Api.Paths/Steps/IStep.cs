using System;

namespace Fabric.Api.Paths.Steps {

	/*================================================================================================*/
	public interface IStep {

		long? TypeId { get; }
		Path Path { get; }
		Type DtoType { get; }
		string[] AvailableSteps { get; }
		StepData Data { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void SetDataAndUpdatePath(StepData pData);
		IStep GetNextStep(string pStepText, bool pSetData=true);

	}

}