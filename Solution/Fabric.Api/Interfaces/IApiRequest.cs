using Fabric.Operations;

namespace Fabric.Api.Interfaces {

	/*================================================================================================*/
	public interface IApiRequest {

		IOperationContext OpCtx { get; }
		string Method { get; }
		string Path { get; }
		string IpAddress { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		string GetQueryValue(string pName, bool pRequired);

		/*--------------------------------------------------------------------------------------------*/
		string GetFormValue(string pName, bool pRequired);

	}

}