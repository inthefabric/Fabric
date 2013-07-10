namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	public interface IFunc : IStep {

		IStep ProxyStep { get; set; }
		
	}

}