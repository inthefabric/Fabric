using Fabric.New.Api.Objects;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public class TravOperation : ITravOperation {

		protected IOperationContext OpCtx { get; set; }
		protected ITravPath Path { get; set; }

		private FabObject vResult;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Perform(IOperationContext pOpCtx, string pPath) {
			OpCtx = pOpCtx;
			Path = new TravPath(pPath, OpCtx.MemberId);
		}

		/*--------------------------------------------------------------------------------------------*/
		public FabObject GetResult() {
			return vResult;
		}

	}

}