using System;

namespace Fabric.Api.Paths.Steps {

	/*================================================================================================*/
	public interface IBaseStep {

		long? TypeId { get; }
		Path Path { get; }
		Type DtoType { get; }
		string[] AvailableSteps { get; }
		IStepData Data { get; }

	}

}