using System;
using System.Collections.Generic;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	public abstract class Func : Step, IFunc {

		public IStep ProxyStep { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected Func(IPath pPath) : base(pPath) {}


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
																		IFunc pProxyForFunc=null) {
			if ( ProxyStep == null ) {
				throw new Exception("ProxyStep is null.");
			}

			IStep next = ProxyStep.GetNextStep(pStepText, false, this);

			if ( pSetData ) {
				next.SetDataAndUpdatePath(new StepData(pStepText));
			}

			return next;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected T ParamAt<T>(int pIndex) {
			try {
				return Data.ParamAt<T>(pIndex);
			}
			catch ( InvalidCastException ex ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamType, this,
					"Could not convert to type 'string'.", pIndex, ex);
			}
		}

	}

}