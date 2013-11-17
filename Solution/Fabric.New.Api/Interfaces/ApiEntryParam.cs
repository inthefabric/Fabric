using System;

namespace Fabric.New.Api.Interfaces {

	/*================================================================================================*/
	public class ApiEntryParam {

		public string Name { get; private set; }
		public Type ParamType { get; private set; }
		public bool Optional { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ApiEntryParam(string pName, Type pParamType, bool pOptional=false) {
			Name = pName;
			ParamType = pParamType;
			Optional = pOptional;
		}

	}

}