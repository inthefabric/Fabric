namespace Fabric.Infrastructure.Api.Faults {

	/*================================================================================================*/
	public class FabArgumentValueFault : FabFault {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabArgumentValueFault(string pMessage) : base(Code.ArgumentInvalidValue, pMessage) {}

	}

}