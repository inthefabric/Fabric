using System;

namespace Fabric.Api.Paths {

	/*================================================================================================*/
	public interface IPathStep {

		long? TypeId { get; }
		Path Path { get; }
		Type DtoType { get; }
		string[] AvailableSteps { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void SetParams(string pParams);
		IPathStep ExecuteUriPart(string pUriPart);

	}

}