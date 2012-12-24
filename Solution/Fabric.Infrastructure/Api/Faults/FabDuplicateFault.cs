namespace Fabric.Infrastructure.Api.Faults {

	/*================================================================================================*/
	public class FabDuplicateFault : FabFault {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabDuplicateFault(string pItemDotProp, string pValue)
								: base("The "+pItemDotProp+" value '"+pValue+"' already exists; "+
														"duplicate values are not permitted.") {}

		/*--------------------------------------------------------------------------------------------*/
		public FabDuplicateFault(string pKeyComboItem)
							: base("There is already a "+pKeyComboItem+" with this key combination; "+
														"duplicate values are not permitted.") {}

	}

}