using System;

namespace Fabric.Api.Paths.Steps {

	/*================================================================================================*/
	public interface IStep {

		long? TypeId { get; }
		Path Path { get; }
		Type DtoType { get; }
		string[] AvailableSteps { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void SetParams(string pParams);
		IStep ExecuteUriPart(string pUriPart);

	}

}