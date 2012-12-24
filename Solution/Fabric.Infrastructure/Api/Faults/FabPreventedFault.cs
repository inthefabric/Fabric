namespace Fabric.Infrastructure.Api.Faults {

	/*================================================================================================*/
	public class FabPreventedFault : FabFault {
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabPreventedFault(string pNote) : base("This action was prevented. "+pNote) {}
		
	}

}