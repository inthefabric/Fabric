namespace Fabric.Api.Traversal.Steps {

	/*================================================================================================*/
	public interface IFinalStep : IBaseStep {

		bool UseLocalData { get; }
		long Index { get; }
		int Count { get; }

	}

}