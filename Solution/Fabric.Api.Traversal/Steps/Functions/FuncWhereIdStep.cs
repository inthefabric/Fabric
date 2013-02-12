using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal.Steps.Nodes;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Traversal;

namespace Fabric.Api.Traversal.Steps.Functions {

	/*================================================================================================*/
	public interface IFuncWhereIdStep : IFuncStep, IFinalStep {
		
		long Id { get; }

	}


	/*================================================================================================*/
	[Func("WhereId")]
	public class FuncWhereIdStep : FuncStep, IFuncWhereIdStep {

		public long Index { get { return 0; } }
		public int Count { get { return 1; } }
		public bool UseLocalData { get { return false; } }

		[FuncParam(0)]
		public long Id { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FuncWhereIdStep(Path pPath) : base(pPath) {
			Path.AddSegment(this, "has");
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

			ProxyStep = Path.Segments[Path.Segments.Count-2].Step;
			INodeStep ns = (INodeStep)ProxyStep;
			Path.AppendToCurrentSegment("('"+ns.TypeIdName+"',Tokens.T.eq,"+Id+"L)", false);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			if ( pDtoType == typeof(FabRoot) ) { return false; }
			return true;
		}

	}

}