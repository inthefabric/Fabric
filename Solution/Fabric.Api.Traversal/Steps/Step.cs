using System;
using System.Collections.Generic;
using Fabric.Api.Dto;
using Fabric.Api.Traversal.Steps.Functions;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps {
	
	/*================================================================================================*/
	public abstract class Step : IStep {

		public long? TypeId { get; protected set; }
		public Path Path { get; protected set; }
		public IStepData Data { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected Step(Path pPath) {
			Path = pPath;
		}

		/*--------------------------------------------------------------------------------------------*/
		public abstract Type DtoType { get; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual List<IStepLink> AvailableLinks {
			get { return new List<IStepLink>(); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual List<string> AvailableFuncs {
			get { return FuncRegistry.GetAvailableFuncs(this, true); }
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void SetDataAndUpdatePath(StepData pData) {
			if ( Data != null ) {
				throw new Exception("StepData is already set.");
			}

			Data = pData;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public int GetPathIndex() {
			return Path.GetSegmentIndexOfStep(this);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual string GetKeyIndexScript() {
			throw new Exception("Invalid use of GetKeyIndexScript().");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IStep GetNextStep(string pStepText, bool pSetData=true,
																		IFuncStep pProxyForFunc=null) {
			var sd = new StepData(pStepText);
			IStep next = GetNextStep(sd);

			if ( next == null ) {
				IStep step = (pProxyForFunc == null ? this : (IStep)pProxyForFunc);
				throw new FabStepFault(FabFault.Code.InvalidStep, step,
					"The attempted next step ('"+pStepText+"') is not supported by the current step.");
			}

			if ( pSetData ) {
				next.SetDataAndUpdatePath(sd);
			}

			return next;
		}

		/*--------------------------------------------------------------------------------------------*/
		private IStep GetNextStep(StepData pData) {
			IStep func = GetFunc(pData);
			return (func ?? GetLink(pData));
		}

		/*--------------------------------------------------------------------------------------------*/
		private IStep GetFunc(StepData pData) {
			List<string> availFuncs = FuncRegistry.GetAvailableFuncs(this, false);

			foreach ( string comm in availFuncs ) {
				if ( comm != pData.Command ) { continue; }
				return FuncRegistry.GetFuncStep(comm, Path);
			}

			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual IStep GetLink(StepData pData) {
			return null;
		}

	}

	/*================================================================================================*/
	public abstract class Step<T> : Step where T : IFabObject, new() {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected Step(Path pPath) : base(pPath) {}

		/*--------------------------------------------------------------------------------------------*/
		public override Type DtoType { get { return typeof(T); } }

	}

}