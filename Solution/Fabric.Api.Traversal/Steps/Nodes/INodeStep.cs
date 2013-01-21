namespace Fabric.Api.Traversal.Steps.Nodes {
	
	/*================================================================================================*/
	public interface INodeStep : IStep {

		/*--------------------------------------------------------------------------------------------*/
		string TypeIdName { get; }
		bool TypeIdIsLong { get; }

	}

}