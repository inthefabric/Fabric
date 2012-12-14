using System;

namespace Fabric.Api.Paths.Steps.Functions {
	
	/*================================================================================================*/
	public class FuncLimitStep : FuncStep, IFinalStep { //TODO: test FuncLimitStep

		public const string DefaultStepText = "Limit(0,20)";

		public long StartI { get; private set; }
		public int RangeLen { get; private set; }


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
				StartI = Data.ParamAt<long>(0);
			}
			catch ( InvalidCastException ex ) {
				throw new StepException(StepException.Code.FailedParamConversion, this,
					"Could not convert to type 'long'.", 0, ex);
			}

			if ( StartI < 0 ) {
				throw new StepException(StepException.Code.IncorrectParamValue, this,
					"Cannot be less than 0.", 0);
			}

			////

			try {
				RangeLen = Data.ParamAt<int>(1);
			}
			catch ( InvalidCastException ex ) {
				throw new StepException(StepException.Code.FailedParamConversion, this,
					"Could not convert to type 'int'.", 1, ex);
			}

			if ( RangeLen <= 0 || RangeLen > 50 ) {
				throw new StepException(StepException.Code.IncorrectParamValue, this,
					"Must be between 1 and 50.", 1);
			}

			////

			ProxyStep = Path.Segments[Path.Segments.Count-2].Step;
			Path.AppendToCurrentSegment("["+StartI+".."+(StartI+RangeLen)+"]", false);
		}

	}

}