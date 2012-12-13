using System;

namespace Fabric.Api.Paths.Steps.Functions {
	
	/*================================================================================================*/
	public class FuncBackStep : Step {

		public int Count { get; private set; }

		private IStep vParentStep;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncBackStep(Path pPath) : base(pPath) {}

		/*--------------------------------------------------------------------------------------------*/
		public override StepData Data {
			set {
				base.Data = value;
				if ( Data.Params == null ) { return; }

				string p = Data.Params[0];
				int segCount;

				if ( !int.TryParse(p, out segCount) ) {
					throw new Exception("Cannot convert parameter '"+p+"' to 'long'.");
				}

				if ( segCount <= 0 ) {
					throw new Exception("The 'Back' parameter cannot be less than 1: "+segCount);
				}

				////

				int numSegs = Path.Segments.Count;

				if ( numSegs-segCount <= 0 ) {
					throw new Exception("Too many 'Back' steps: "+segCount);
				}

				PathSegment seg;
				Count = -1;

				for ( int i = 0 ; i < segCount ; ++i ) {
					seg = Path.Segments[numSegs-i-1];
					Count += seg.SubstepCount;
				}

				seg = Path.Segments[numSegs-segCount-1];
				vParentStep = seg.Step;
				Path.AddSegment(this, "back("+Count+")");
			}
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
				next.Data = new StepData(pStepText);
			}

			return next;
		}

	}

}