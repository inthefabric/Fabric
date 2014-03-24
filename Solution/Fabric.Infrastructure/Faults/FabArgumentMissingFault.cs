namespace Fabric.Infrastructure.Faults {

	/*================================================================================================*/
	public class FabArgumentMissingFault : FabFault {
		
		public string ArgName { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabArgumentMissingFault(string pArgName) : base(Code.ArgumentMissingFault, "") {
			ArgName = pArgName;
			AppendMessage("Required argument '"+ArgName+"' is missing or null.");
		}
		
	}

}