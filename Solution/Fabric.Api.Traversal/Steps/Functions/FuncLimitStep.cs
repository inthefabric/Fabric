using System;
using Fabric.Api.Dto;
using Fabric.Api.Dto.Oauth;

namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	[Func("Limit")]
	public class FuncLimitStep : FuncStep, IFinalStep {

		public const string DefaultStepText = "Limit(0,20)";

		public bool UseLocalData { get { return false; } }

		[FuncParam(0, 0)]
		public long Index { get; private set; }

		[FuncParam(1, 0, 50)]
		public int Count { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncLimitStep(Path pPath) : base(pPath) {
			Path.AddSegment(this, "dedup");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);

			if ( Data.Params == null || Data.Params.Length != 2 ) {
				throw new StepException(StepException.Code.IncorrectParamCount, this,
					"Two parameters required.");
			}

			////

			try {
				Index = Data.ParamAt<long>(0);
			}
			catch ( InvalidCastException ex ) {
				throw new StepException(StepException.Code.IncorrectParamType, this,
					"Could not convert to type 'long'.", 0, ex);
			}

			if ( Index < 0 ) {
				throw new StepException(StepException.Code.IncorrectParamValue, this,
					"Cannot be less than 0.", 0);
			}

			////

			try {
				Count = Data.ParamAt<int>(1);
			}
			catch ( InvalidCastException ex ) {
				throw new StepException(StepException.Code.IncorrectParamType, this,
					"Could not convert to type 'int'.", 1, ex);
			}

			if ( Count <= 0 || Count > 50 ) {
				throw new StepException(StepException.Code.IncorrectParamValue, this,
					"Must be between 1 and 50.", 1);
			}

			////

			ProxyStep = Path.Segments[Path.Segments.Count-2].Step;
			Path.AppendToCurrentSegment("["+Index+".."+(Index+Count)+"]", false);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			if ( pDtoType == typeof(FabRoot) ) { return false; }
			if ( pDtoType == typeof(FabOauth) ) { return false; }
			return true;
		}

	}

}