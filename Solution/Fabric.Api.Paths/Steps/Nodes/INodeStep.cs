namespace Fabric.Api.Paths.Steps.Nodes {
	
	/*================================================================================================*/
	public interface INodeStep : IStep {

		/*--------------------------------------------------------------------------------------------*/
		string TypeIdName { get; }
		bool TypeIdIsLong { get; }

	}

}