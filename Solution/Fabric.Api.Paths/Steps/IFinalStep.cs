namespace Fabric.Api.Paths.Steps {

	/*================================================================================================*/
	public interface IFinalStep : IBaseStep {

		long StartI { get; }
		int RangeLen { get; }

	}

}