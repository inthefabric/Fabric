using System;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Traversal.Steps.Nodes;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Traversal;
using Weaver;

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
		public FuncWhereIdStep(IPath pPath) : base(pPath) {
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

			ProxyStep = Path.GetSegmentBeforeLast(1).Step;
			INodeStep ns = (INodeStep)ProxyStep;
			string idParam = Path.AddParam(new WeaverQueryVal(Id));
			Path.AppendToCurrentSegment("('"+ns.TypeIdName+"',Tokens.T.eq,"+idParam+")", false);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static bool AllowedForStep(Type pDtoType) {
			if ( pDtoType == typeof(FabRoot) ) { return false; }
			return true;
		}

	}

}