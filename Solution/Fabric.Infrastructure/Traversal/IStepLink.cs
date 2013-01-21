namespace Fabric.Infrastructure.Traversal {
	
	/*================================================================================================*/
	public interface IStepLink {

		string RelType { get; }
		string Node { get; }
		bool IsOutgoing { get; }
		string Uri { get; }

	}

}