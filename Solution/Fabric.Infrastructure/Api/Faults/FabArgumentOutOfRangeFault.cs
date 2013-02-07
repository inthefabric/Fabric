namespace Fabric.Infrastructure.Api.Faults {

	/*================================================================================================*/
	public class FabArgumentOutOfRangeFault : FabFault {
		
		public string ArgName { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabArgumentOutOfRangeFault(string pArgName) : base(Code.ArgumentOutOfRange, "") {
			ArgName = pArgName;
			//TODO: improve FabArgumentOutOfRangeFault message for full sentences
			AppendMessage("Value "+ArgName+" is out of range.");
		}
		
	}

}