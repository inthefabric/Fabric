namespace Fabric.Infrastructure.Api.Faults {

	/*================================================================================================*/
	public class FabArgumentLengthFault : FabFault {

		public string ArgName { get; private set; }
		public int MinChars { get; private set; }
		public int MaxChars { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabArgumentLengthFault(string pArgName, int pMaxChars) : 
																	base(Code.ArgumentLengthFault, "") {
			ArgName = pArgName;
			MinChars = 0;
			MaxChars = pMaxChars;
			AppendMessage(GetMessage());
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabArgumentLengthFault(string pArgName, int pMinChars, int pMaxChars) :
																	base(Code.ArgumentLengthFault, "") {
			ArgName = pArgName;
			MinChars = pMinChars;
			MaxChars = pMaxChars;
			AppendMessage(GetMessage());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private string GetMessage() {
			if ( MinChars == 0 ) {
				return ArgName+" length cannot exceed "+MaxChars+" characters.";
			}

			if ( MinChars == MaxChars ) {
				return ArgName+" length must be "+MinChars+" characters.";
			}

			return ArgName+" length must be between "+MinChars+" and "+MaxChars+" characters.";
		}
		
	}

}