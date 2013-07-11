using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public abstract partial class IdIndexFunc : ExactIndexFunc<long> { //TEST: IdIndexFunc

		[FuncParam(0)]
		public long Id { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IdIndexFunc(IPath pPath) : base(pPath) {}

		/*--------------------------------------------------------------------------------------------*/
		protected override void GetValue() {
			base.GetValue();

			if ( IdParam == 0 ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamValue, this, "Cannot be 0.", 0);
			}
		}

	}

}