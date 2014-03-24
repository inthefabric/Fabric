using System;

namespace Fabric.Infrastructure.Faults {

	/*================================================================================================*/
	public class FabNotFoundFault : FabFault {
	
		public Type ItemType { get; private set; }
		public string Criteria { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabNotFoundFault(Type pItemType, string pCriteria) : base(Code.ObjectNotFound, "") {
			ItemType = pItemType;
			Criteria = pCriteria;
			AppendMessage("No "+ItemType.Name+" was found with the criteria ("+Criteria+").");
		}
		
	}

}