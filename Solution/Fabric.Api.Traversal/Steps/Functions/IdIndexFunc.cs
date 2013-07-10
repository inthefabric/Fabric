using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public abstract partial class IdIndexFunc : ExactIndexFunc<long>, IFinalStep { //TEST: IdIndexFunc

		public long Index { get { return 0; } }
		public int Count { get { return 1; } }
		public bool UseLocalData { get { return false; } }

		[FuncParam(0)]
		public long Id { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IdIndexFunc(IPath pPath) : base(pPath) {}

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