using Fabric.Api.Dto.Traversal;
using Weaver;

namespace Fabric.Api.Traversal.Steps.Nodes {
	
	/*================================================================================================*/
	public abstract class NodeStep<T> : Step<T>, INodeStep where T : FabNode, new() {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected NodeStep(IPath pPath) : base(pPath) {}

		/*--------------------------------------------------------------------------------------------*/
		public abstract string TypeIdName { get; }
		public abstract bool TypeIdIsLong { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);
			ExpectParamCount(0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public string GetKeyIndexScript(long pTypeId) {
			string idVal = Path.AddParam(new WeaverQueryVal(pTypeId));
			return "g.V('"+TypeIdName+"',"+idVal+")";
		}

	}

}