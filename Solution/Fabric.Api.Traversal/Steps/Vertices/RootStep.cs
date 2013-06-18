using Fabric.Api.Dto.Traversal;

namespace Fabric.Api.Traversal.Steps.Vertices {

	/*================================================================================================*/
	public class RootStep : VertexStep<FabRoot>, IFinalStep {

		public bool UseLocalData { get { return true; } }
		public long Index { get { return 0; } }
		public int Count { get { return 1; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public RootStep(IPath pPath) : base(pPath) {
			pPath.AddSegment(this, "g");
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string TypeIdName { get { return null; } }
		public override bool TypeIdIsLong { get { return false; } }

	}

}