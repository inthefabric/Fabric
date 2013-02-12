namespace Fabric.Infrastructure.Api.Faults {

	/*================================================================================================*/
	public class FabArgumentOutOfRangeFault : FabFault {
		
		public string Property { get; private set; }
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabArgumentOutOfRangeFault(string pProp) : base(Code.ArgumentOutOfRange, "") {
			Property = pProp;
			AppendMessage("The '"+Property+"' value is out of range.");
		}
		
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