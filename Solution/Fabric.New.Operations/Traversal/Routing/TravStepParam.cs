using System;
using System.Collections.Generic;

namespace Fabric.New.Operations.Traversal.Routing {

	/*================================================================================================*/
	public class TravStepParam : ITravStepParam {

		public int ParamIndex { get; private set; }
		public string Name { get; private  set; }
		public Type DataType { get; private set; }
		public bool IsGenericDataType { get; internal set; }
		public int? Min { get; internal set; }
		public int? Max { get; internal set; }
		public int? LenMax { get; internal set; }
		public string ValidRegex { get; internal set; }
		public IList<string> AcceptedStrings { get; internal set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepParam(int pParamIndex, string pName, Type pDataType) {
			ParamIndex = pParamIndex;
			Name = pName;
			DataType = pDataType;
		}

	}

}