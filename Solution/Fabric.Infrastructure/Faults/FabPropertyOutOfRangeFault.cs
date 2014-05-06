namespace Fabric.Infrastructure.Faults {

	/*================================================================================================*/
	public class FabPropertyOutOfRangeFault : FabFault {
		
		public string Name { get; private set; }
		public double Value { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabPropertyOutOfRangeFault(string pName, double pValue, string pMessage) :
																	base(Code.PropertyOutOfRange, "") {
			Name = pName;
			Value = pValue;
			AppendMessage(FabPropertyValueFault.PropStr(pName, pValue)+pMessage);
		}
		
	}

}