namespace Fabric.Infrastructure.Traversal {
	
	/*================================================================================================*/
	public interface IStepLink {

		string EdgeType { get; }
		string Node { get; }
		bool IsOutgoing { get; }
		string Uri { get; }

	}

}