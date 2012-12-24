namespace Fabric.Infrastructure.Api.Faults {

	/*================================================================================================*/
	public class FabArgumentLengthFault : FabFault {

		public string ArgName { get; private set; }
		public int MinChars { get; private set; }
		public int MaxChars { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabArgumentLengthFault(string pArgName, int pMaxChars)
														: base(GetMessage(pArgName, 0, pMaxChars)) {
			ArgName = pArgName;
			MinChars = 0;
			MaxChars = pMaxChars;
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabArgumentLengthFault(string pArgName, int pMinChars, int pMaxChars)
												: base(GetMessage(pArgName, pMinChars, pMaxChars)) {
			ArgName = pArgName;
			MinChars = pMinChars;
			MaxChars = pMaxChars;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static string GetMessage(string pArgName, int pMinChars, int pMaxChars) {
			if ( pMinChars == 0 ) {
				return pArgName+" length cannot exceed "+pMaxChars+" characters.";
			}

			if ( pMinChars == pMaxChars ) {
				return pArgName+" length must be "+pMinChars+" characters.";
			}

			return pArgName+" length must be between "+pMinChars+" and "+pMaxChars+" characters.";
		}
		
	}

}