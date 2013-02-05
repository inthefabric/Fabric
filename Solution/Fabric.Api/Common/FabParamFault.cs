using System;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain;

namespace Fabric.Api.Common {

	/*================================================================================================*/
	public class FabParamFault : FabFault {

		public string ParamName { get; private set; }
		public Type ExpectType { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabParamFault(Code pCode, string pParamName, Type pExpectType, Exception pInner=null) :
																			base(pCode, "", pInner) {
			ParamName = pParamName;
			ExpectType = pExpectType;

			string msg = "Parameter '"+ParamName+"' ";

			switch ( pCode ) {
				case Code.IncorrectParamType:
					msg += "must be of type '"+SchemaHelperProp.GetTypeName(pExpectType)+"'.";
					break;

				case Code.IncorrectParamValue:
					msg += "is null or empty.";
					break;
			}

			AppendMessage(msg);
		}

	}

}