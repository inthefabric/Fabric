namespace Fabric.Infrastructure.Traversal {
	
	/*================================================================================================*/
	public interface IStepLink {

		string EdgeType { get; }
		string Vertex { get; }
		bool IsOutgoing { get; }
		string Uri { get; }

	}

}