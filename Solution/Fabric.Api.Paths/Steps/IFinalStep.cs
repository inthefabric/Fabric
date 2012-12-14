namespace Fabric.Api.Paths.Steps {

	/*================================================================================================*/
	public interface IFinalStep : IBaseStep {

		long Index { get; }
		int Count { get; }

	}

}