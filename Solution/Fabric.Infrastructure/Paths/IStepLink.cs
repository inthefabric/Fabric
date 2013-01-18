namespace Fabric.Infrastructure.Paths {
	
	/*================================================================================================*/
	public interface IStepLink {

		string RelType { get; }
		string Node { get; }
		bool IsOutgoing { get; }
		string Uri { get; }

	}

}