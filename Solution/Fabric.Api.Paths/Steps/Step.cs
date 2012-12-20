using System;
using System.Collections.Generic;
using Fabric.Api.Dto;
using Fabric.Api.Paths.Steps.Functions;

namespace Fabric.Api.Paths.Steps {
	
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
		public virtual List<string> AvailableSteps {
			get { return new List<string>(); }
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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IStep GetNextStep(string pStepText, bool pSetData=true) {
			var sd = new StepData(pStepText);
			IStep next = GetNextStep(sd);

			if ( next == null ) {
				//NEXT: InvalidStep behaves incorrectly after a Back(x) step
				throw new StepException(StepException.Code.InvalidStep, this,
					"The attempted next step ('"+pStepText+"') is not supported by the current step.");
			}

			if ( pSetData ) {
				next.SetDataAndUpdatePath(sd);
			}

			return next;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual IStep GetNextStep(StepData pData) {
			IStep func = GetFunc(pData);
			if ( func != null ) { return func; }

			return null;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual IStep GetFunc(StepData pData) { //TEST: Step.GetFunc
			List<string> availFuncs = FuncRegistry.GetAvailableFuncs(this, false);

			foreach ( string comm in availFuncs ) {
				if ( comm != pData.Command ) { continue; }
				return FuncRegistry.GetFuncStep(comm, Path);
			}

			return null;
		}

	}

	/*================================================================================================*/
	public abstract class Step<T> : Step where T : FabNode, new() {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected Step(Path pPath) : base(pPath) {}

		/*--------------------------------------------------------------------------------------------*/
		public override Type DtoType { get { return typeof(T); } }

	}

}