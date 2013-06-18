namespace Fabric.Api.Traversal.Steps.Vertices {
	
	/*================================================================================================*/
	public interface IVertexStep : IStep {

		/*--------------------------------------------------------------------------------------------*/
		string TypeIdName { get; }
		bool TypeIdIsLong { get; }

		/*--------------------------------------------------------------------------------------------*/
		string GetKeyIndexScript(long pTypeId);

	}

}