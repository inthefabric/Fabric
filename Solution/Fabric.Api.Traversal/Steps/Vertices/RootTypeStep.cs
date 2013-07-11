using Fabric.Api.Dto.Traversal;

namespace Fabric.Api.Traversal.Steps.Vertices {

	/*================================================================================================*/
	public class RootTypeStep<T> : VertexStep<T>, IFinalStep where T : FabVertex, new() {

		public bool UseLocalData { get { return true; } }
		public long Index { get { return 0; } }
		public int Count { get { return 1; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootTypeStep(IPath pPath) : base(pPath) {}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return null; } }
		public override bool TypeIdIsLong { get { return false; } }

	}

}