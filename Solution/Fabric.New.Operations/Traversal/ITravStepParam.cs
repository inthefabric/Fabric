using System;
using System.Collections.Generic;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public interface ITravStepParam {

		int ParamIndex { get; }
		string Name { get; }
		Type DataType { get; }
		int? Min { get; }
		int? Max { get; }
		int? LenMin { get; }
		int? LenMax { get; }
		string ValidRegex { get; }
		IList<string> AcceptedStrings { get; }

	}

}