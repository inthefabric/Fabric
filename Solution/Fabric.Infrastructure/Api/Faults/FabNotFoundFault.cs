using System;

namespace Fabric.Infrastructure.Api.Faults {

	/*================================================================================================*/
	public class FabNotFoundFault : FabFault {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabNotFoundFault(Type pType, string pCriteria) :
							base("No "+pType.Name+" was found with the criteria ("+pCriteria+").") {}
		
	}

}