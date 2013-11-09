namespace Fabric.New.Infrastructure.Faults {

	/*================================================================================================*/
	public class FabArgumentOutOfRangeFault : FabFault {
		
		public string Property { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabArgumentOutOfRangeFault(string pMessage) : base(Code.ArgumentOutOfRange, pMessage) {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabArgumentOutOfRangeFault(string pProp, long pMin) : base(Code.ArgumentOutOfRange, "") {
			Property = pProp;
			AppendMessage("The '"+Property+"' value cannot be less than "+pMin+".");
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabArgumentOutOfRangeFault(string pProp, long pMin, long pMax) :
																	base(Code.ArgumentOutOfRange, "") {
			Property = pProp;
			AppendMessage("The '"+Property+"' value cannot be less than "+
				pMin+" or greater than "+pMax+".");
		}
		
	}

}