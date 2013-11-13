namespace Fabric.New.Infrastructure.Faults {

	/*================================================================================================*/
	public class FabArgumentNullFault : FabFault {
		
		public string ArgName { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabArgumentNullFault(string pArgName) : base(Code.ArgumentNullFault, "") {
			ArgName = pArgName;
			AppendMessage("The "+ArgName+" argument cannot be null.");
		}
		
	}

}