using System;

namespace Fabric.New.Infrastructure.Faults {

	/*================================================================================================*/
	public class FabDuplicateFault : FabFault {
	
		public Type ItemType { get; private set; }
		public string Prop { get; private set; }
		public string Value { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabDuplicateFault(Type pItemType, string pProp, string pValue, string pNote=null) :
															base(Code.UniqueConstraintViolation, "") {
			ItemType = pItemType;
			Prop = pProp;
			Value = pValue;
			AppendMessage("The "+ItemType.Name+"."+Prop+" value '"+Value+
				"' already exists; duplicate values are not permitted."+
				(pNote == null ? "" : " "+pNote));
		}

	}

}