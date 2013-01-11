namespace Fabric.Api.Paths.Steps {

	/*================================================================================================*/
	public interface IFinalStep : IBaseStep {

		bool UseLocalData { get; }
		long Index { get; }
		int Count { get; }

	}

}