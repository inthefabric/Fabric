using Fabric.New.Infrastructure.Faults;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public partial class CreateInstanceOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void VerifyCustomInstance() { }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void AfterSessionStart() {
			if ( NewDom.Name == null && NewDom.Disamb != null ) {
				throw new FabPropertyValueFault("Name", null,
					"Cannot be null when Disamb is specified.");
			}
		}
	}

}