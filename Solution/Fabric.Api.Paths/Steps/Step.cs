using System;
using Fabric.Api.Dto;
using Fabric.Api.Paths.Steps.Functions;

namespace Fabric.Api.Paths.Steps {
	
	/*================================================================================================*/
	public abstract class Step : IStep {

		public static readonly string[] AvailSteps = new[] { "/Back", "/Limit" };

		public long? TypeId { get; protected set; }
		public Path Path { get; protected set; }
		public StepData Data { get; private set; }


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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual IStep GetNextStep(string pStepText, bool pSetData=true) {
			var sd = new StepData(pStepText);
			IStep next = GetNextStep(sd);

			if ( next == null ) {
				throw new Exception("'"+pStepText+"' is not a valid step for "+GetType().Name+".");
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