namespace Fabric.Infrastructure.Faults {

	/*================================================================================================*/
	public class FabPropertyValueFault : FabFault {

		public string Name { get; private set; }
		public string Value { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabPropertyValueFault(string pMessage) :
			base(Code.PropertyInvalidValue, "") {
			AppendMessage(pMessage);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabPropertyValueFault(string pName, string pValue, string pMessage) : 
																base(Code.PropertyInvalidValue, "") {
			Name = pName;
			Value = pValue;
			AppendMessage(PropStr(pName, pValue)+pMessage);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		internal static string PropStr(string pName, object pValue) {
			return "Property '"+pName+"' (with value '"+pValue+"') ";
		}

	}

}