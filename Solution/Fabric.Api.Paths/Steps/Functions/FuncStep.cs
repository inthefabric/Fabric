using System;
using System.Collections.Generic;

namespace Fabric.Api.Paths.Steps.Functions {
	
	/*================================================================================================*/
	public abstract class FuncStep : Step, IFuncStep {

		protected IStep ProxyStep { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected FuncStep(Path pPath) : base(pPath) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override Type DtoType {
			get {
				return (ProxyStep != null ? ProxyStep.DtoType : null);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public override List<string> AvailableSteps { get { return ProxyStep.AvailableSteps; } }

		/*--------------------------------------------------------------------------------------------*/
		public override IStep GetNextStep(string pStepText, bool pSetData=true) {
			if ( ProxyStep == null ) {
				throw new Exception("BackToStep is null.");
			}

			IStep next = ProxyStep.GetNextStep(pStepText, false);

			if ( pSetData ) {
				next.SetDataAndUpdatePath(new StepData(pStepText));
			}

			return next;
		}

	}

}