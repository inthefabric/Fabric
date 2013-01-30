using System;

namespace Fabric.Infrastructure.Api.Faults {

	/*================================================================================================*/
	public class FabDuplicateFault : FabFault {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabDuplicateFault(Type pType, string pProp, string pValue) :
								base("The "+pType.Name+"."+pProp+" value '"+pValue+"' already exists; "+
														"duplicate values are not permitted.") {}

	}

}