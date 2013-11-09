namespace Fabric.New.Infrastructure.Faults {

	/*================================================================================================*/
	public class FabArgumentValueFault : FabFault {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabArgumentValueFault(string pMessage) : base(Code.ArgumentInvalidValue, pMessage) {}

		/*--------------------------------------------------------------------------------------------*/
		public FabArgumentValueFault(string pProp, long pNotEqualTo) : 
																base(Code.ArgumentInvalidValue, "") {
			AppendMessage(pProp+" cannot be equal to "+pNotEqualTo+".");
		}

	}

}