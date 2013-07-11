using Fabric.Infrastructure.Api.Faults;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public abstract partial class IdIndexFunc : ExactIndexFunc<long> { //TEST: IdIndexFunc


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IdIndexFunc(IPath pPath) : base(pPath) {}

		/*--------------------------------------------------------------------------------------------*/
		protected override void GetValue() {
			base.GetValue();

			if ( Value == 0 ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamValue, this, "Cannot be 0.", 0);
			}
		}

	}

}