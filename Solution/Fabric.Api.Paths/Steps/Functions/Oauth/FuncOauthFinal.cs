namespace Fabric.Api.Paths.Steps.Functions.Oauth {
	
	/*================================================================================================*/
	public abstract class FuncOauthFinal : FuncStep, IFinalStep {

		public bool UseLocalData { get { return true; } }
		public long Index { get { return 0; } }
		public int Count { get { return 1; } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected FuncOauthFinal(Path pPath) : base(pPath) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void SetDataAndUpdatePath(StepData pData) {
			base.SetDataAndUpdatePath(pData);

			if ( Data.Params != null ) {
				throw new StepException(StepException.Code.IncorrectParamCount, this,
					"This function does not allow parameters.");
			}
		}

	}

}