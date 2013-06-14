using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal.Steps.Nodes;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Traversal;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Query;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public abstract partial class FuncIdIndexStep : FuncStep, IFinalStep { //TEST: all FuncIdIndexSteps

		public long Index { get { return 0; } }
		public int Count { get { return 1; } }
		public bool UseLocalData { get { return false; } }

		protected byte? FabType { get; set; }

		[FuncParam(0)]
		public long Id { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncIdIndexStep(IPath pPath) : base(pPath) {
			Path.AddSegment(this, "V");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);
			ExpectParamCount(1);

			////

			try {
				Id = Data.ParamAt<long>(0);
			}
			catch ( InvalidCastException ex ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamType, this,
					"Could not convert to type 'long'.", 0, ex);
			}

			if ( Id == 0 ) {
				throw new FabStepFault(FabFault.Code.IncorrectParamValue, this, "Cannot be 0.", 0);
			}

			////

			INodeStep ns = (INodeStep)ProxyStep;
			string propParam = Path.AddParam(new WeaverQueryVal(ns.TypeIdName));
			string idParam = Path.AddParam(new WeaverQueryVal(Id));
			Path.AppendToCurrentSegment("("+propParam+","+idParam+")", false);

			if ( FabType != null ) {
				propParam = Path.AddParam(new WeaverQueryVal(PropDbName.Node_FabType));
				string ftParam = Path.AddParam(new WeaverQueryVal((byte)FabType));
				Path.AppendToCurrentSegment("has("+propParam+","+ftParam+")");
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private static bool AllowedForStep(Type pDtoType) {
			return (pDtoType == typeof(FabRoot));
		}

	}

}