using System;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Spec;
using Fabric.Api.Paths.Steps.Spec;

namespace Fabric.Api.Paths.Steps.Functions.Spec {
	
	/*================================================================================================*/
	[Func("Spec", typeof(FabSpec))]
	public class FuncSpecStep : FuncStep, IFinalStep { //TEST: FuncSpecStep
		
		public bool UseLocalData { get { return true; } }
		public long Index { get { return 0; } }
		public int Count { get { return 1; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncSpecStep(Path pPath) : base(pPath) { }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);
			ProxyStep = new SpecStep(Path);
			
			if ( Data.Params != null ) {
				throw new StepException(StepException.Code.IncorrectParamCount, this,
					"This function does not allow parameters.");
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabRoot));
		}

	}

}