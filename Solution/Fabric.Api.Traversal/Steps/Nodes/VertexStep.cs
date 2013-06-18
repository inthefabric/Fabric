using Fabric.Api.Dto.Traversal;
using Weaver.Core.Query;

namespace Fabric.Api.Traversal.Steps.Vertices {
	
	/*================================================================================================*/
	public abstract class VertexStep<T> : Step<T>, IVertexStep where T : FabVertex, new() {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected VertexStep(IPath pPath) : base(pPath) {}

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