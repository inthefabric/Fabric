namespace Fabric.New.Infrastructure.Faults {

	/*================================================================================================*/
	public class FabPropertyLengthFault : FabFault {

		public string Name { get; private set; }
		public string Value { get; private set; }
		public bool IsMin { get; private set; }
		public int Chars { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabPropertyLengthFault(string pName, string pValue, bool pIsMin, int pChars) : 
																	base(Code.PropertyLengthFault, "") {
			Name = pName;
			Value = pValue;
			IsMin = pIsMin;
			Chars = pChars;
			AppendMessage(FabPropertyValueFault.PropStr(pName, pValue)+" cannot be "+
				(IsMin ? "less" : "more")+" than "+pChars+" characters.");
		}
		
	}

}