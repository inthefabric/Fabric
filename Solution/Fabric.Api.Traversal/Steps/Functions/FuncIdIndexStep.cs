using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {

	//TEST: all FuncIdIndexSteps

	/*================================================================================================*/
	public abstract partial class FuncIdIndexStep : FuncExactIndexStep<long>, IFinalStep {

		public long Index { get { return 0; } }
		public int Count { get { return 1; } }
		public bool UseLocalData { get { return false; } }

		[FuncParam(0)]
		public long Id { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncIdIndexStep(IPath pPath) : base(pPath) {}

		/*--------------------------------------------------------------------------------------------*/
		protected override void GetValue() {
			base.GetValue();
			Id = Value;

			if ( Id == 0 ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamValue, this, "Cannot be 0.", 0);
			}
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabRoot));
		}

	}

}