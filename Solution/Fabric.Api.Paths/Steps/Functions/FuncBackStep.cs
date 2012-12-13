using System;

namespace Fabric.Api.Paths.Steps.Functions {
	
	/*================================================================================================*/
	public class FuncBackStep : Step {

		public int Count { get; private set; }

		private IStep vParentStep;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncBackStep(Path pPath) : base(pPath) {
			Path.AddSegment(this, "back");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);

			if ( Data.Params == null || Data.Params.Length != 1 ) {
				throw new StepException(this, "One integer parameter required.");
			}

			int segCount;

			try {
				segCount = Data.ParamAt<int>(0);
			}
			catch ( InvalidCastException ex ) {
				throw new StepException(this, "Could not convert to type 'int'.", 0, ex);
			}

			if ( segCount <= 0 ) {
				throw new StepException(this, "Cannot be less than 1.", 0);
			}

			////

			int numSegs = Path.Segments.Count;

			if ( numSegs-segCount <= 0 ) {
				throw new StepException(this, "Exceeds the maximum 'back' steps "+
					"("+(numSegs-1)+") for the current path.", 0);
			}

			PathSegment seg;
			Count = -1;

			for ( int i = 0 ; i < segCount ; ++i ) {
				seg = Path.Segments[numSegs-i-1];
				Count += seg.SubstepCount;
			}

			seg = Path.Segments[numSegs-segCount-1];
			vParentStep = seg.Step;
			Path.AppendToCurrentSegment("("+Count+")", false);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override Type DtoType {
			get {
				return (vParentStep != null ? vParentStep.DtoType : null);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string[] AvailableSteps { get { return vParentStep.AvailableSteps; } }

		/*--------------------------------------------------------------------------------------------*/
		public override IStep GetNextStep(string pStepText, bool pSetData=true) {
			if ( vParentStep == null ) {
				throw new Exception("ParentStep is null.");
			}

			IStep next = vParentStep.GetNextStep(pStepText, false);

			if ( pSetData ) {
				next.SetDataAndUpdatePath(new StepData(pStepText));
			}

			return next;
		}

	}

}