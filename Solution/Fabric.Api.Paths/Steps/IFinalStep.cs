namespace Fabric.Api.Paths.Steps {

	/*================================================================================================*/
	public interface IFinalStep : IBaseStep {

		bool UseLocalData { get; } //TEST: IFinalStep.UseLocalData scenarios
		long Index { get; }
		int Count { get; }

	}

}