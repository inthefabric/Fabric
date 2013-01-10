using System;
using Fabric.Api.Dto;

namespace Fabric.Api.Paths.Steps.Nodes {
	
	/*================================================================================================*/
	public abstract class NodeStep<T> : Step<T>, INodeStep where T : FabNode, new() {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected NodeStep(Path pPath) : base(pPath) {}

		/*--------------------------------------------------------------------------------------------*/
		public abstract string TypeIdName { get; }
		public abstract bool TypeIdIsLong { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);
			if ( Data.Params == null ) { return; }

			try {
				TypeId = Data.ParamAt<long>(0);
			}
			catch ( InvalidCastException ex ) {
				throw new StepException(StepException.Code.IncorrectParamType, this,
					"Could not convert to type 'long'.", 0, ex);
			}

			Path.AppendToCurrentSegment(
				"has('"+TypeIdName+"',Tokens.T.eq,"+TypeId+(TypeIdIsLong ? "L" : "")+")");
		}

		/*--------------------------------------------------------------------------------------------*/
		//TEST: NodeStep.GetKeyIndexScript()
		public override string GetKeyIndexScript() {
			return "g.V('"+TypeIdName+"',"+TypeId+(TypeIdIsLong ? "L" : "")+")";
		}

	}

}