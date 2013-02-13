using System;
using System.Collections.Generic;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	public abstract class FuncStep : Step, IFuncStep {

		public IStep ProxyStep { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected FuncStep(IPath pPath) : base(pPath) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override Type DtoType {
			get {
				return (ProxyStep != null ? ProxyStep.DtoType : null);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public override List<IStepLink> AvailableLinks { get { return ProxyStep.AvailableLinks; } }
		public override List<string> AvailableFuncs { get { return ProxyStep.AvailableFuncs; } }

		/*--------------------------------------------------------------------------------------------*/
		public override IStep GetNextStep(string pStepText, bool pSetData=true, 
																		IFuncStep pProxyForFunc=null) {
			if ( ProxyStep == null ) {
				throw new Exception("ProxyStep is null.");
			}

			IStep next = ProxyStep.GetNextStep(pStepText, false, this);

			if ( pSetData ) {
				next.SetDataAndUpdatePath(new StepData(pStepText));
			}

			return next;
		}

	}

}