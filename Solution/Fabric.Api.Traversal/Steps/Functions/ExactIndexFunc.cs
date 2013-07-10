using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Query;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public abstract partial class ExactIndexFunc : Func { //TEST: ExactIndexFunc


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected ExactIndexFunc(IPath pPath) : base(pPath) {
			Path.AddSegment(this, "V");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabRoot));
		}

	}


	/*================================================================================================*/
	public abstract partial class ExactIndexFunc<T> : ExactIndexFunc {

		public T Value { get; private set; }

		protected string PropName { get; set; }
		protected byte? FabType { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected ExactIndexFunc(IPath pPath) : base(pPath) {
			Path.AddSegment(this, "V");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);
			GetValue();

			////

			string propParam = Path.AddParam(new WeaverQueryVal(PropName));
			string idParam = Path.AddParam(new WeaverQueryVal(Value));
			Path.AppendToCurrentSegment("("+propParam+","+idParam+")", false);

			if ( FabType != null ) {
				propParam = Path.AddParam(new WeaverQueryVal(PropDbName.Vertex_FabType));
				string typeParam = Path.AddParam(new WeaverQueryVal((byte)FabType));
				Path.AppendToCurrentSegment("has("+propParam+","+typeParam+")");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void GetValue() {
			ExpectParamCount(1);

			try {
				Value = Data.ParamAt<T>(0);
			}
			catch ( InvalidCastException ex ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamType, this,
					"Could not convert to type "+typeof(T).Name+".", 0, ex);
			}
		}

	}

}