﻿using System;
using System.Collections.Generic;

namespace Fabric.Api.Paths.Steps {

	/*================================================================================================*/
	public interface IBaseStep {

		long? TypeId { get; }
		Path Path { get; }
		Type DtoType { get; }
		List<string> AvailableSteps { get; }
		IStepData Data { get; }

	}

}