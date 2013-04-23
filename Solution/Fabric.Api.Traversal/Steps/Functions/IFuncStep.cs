namespace Fabric.Api.Traversal.Steps.Functions {
	
	/*================================================================================================*/
	public interface IFuncStep : IStep {

		IStep ProxyStep { get; set; }
		
	}

}