using System;
using Fabric.Api.Dto;
using Fabric.Api.Paths.Steps.Functions;

namespace Fabric.Api.Paths.Steps {
	
	/*================================================================================================*/
	public abstract class Step : IStep {

		public static readonly string[] AvailSteps = new[] { "/Back", "/Limit" };

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
		public virtual string[] AvailableSteps { get { return Step.AvailSteps; } }


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

			if ( next == null ) { //TODO: test Step's new StepException usage
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
			switch ( pData.Command ) {
				case "back": return new FuncBackStep(Path);
				case "limit": return new FuncLimitStep(Path);
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