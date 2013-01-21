using System;
using System.Collections.Generic;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps {

	/*================================================================================================*/
	public interface IBaseStep {

		long? TypeId { get; }
		Path Path { get; }
		Type DtoType { get; }
		List<IStepLink> AvailableLinks { get; }
		List<string> AvailableFuncs { get; }
		IStepData Data { get; }

	}

}