using System;
using System.Collections.Generic;

namespace Fabric.Operations.Traversal.Routing {

	/*================================================================================================*/
	public interface ITravStepParam {

		int ParamIndex { get; }
		string Name { get; }
		Type DataType { get; }
		bool IsGenericDataType { get; }
		long? Min { get; }
		long? Max { get; }
		int? LenMax { get; }
		string ValidRegex { get; }
		IList<string> AcceptedStrings { get; }

	}

}