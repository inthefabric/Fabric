using Fabric.New.Operations;

namespace Fabric.New.Api.Interfaces {

	/*================================================================================================*/
	public interface IApiRequest {

		IOperationContext OpCtx { get; }
		string Method { get; }
		string Path { get; }
		string IpAddress { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		string GetQueryValue(string pName, bool pOptional=false);

		/*--------------------------------------------------------------------------------------------*/
		string GetFormValue(string pName, bool pOptional=false);

	}

}