using System;

namespace Fabric.Api.Paths {

	/*================================================================================================*/
	public interface IPathBase {

		long? TypeId { get; }
		Path Path { get; }
		Type DtoType { get; }
		string[] AvailablePaths { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Id(long pTypeId);
		IPathBase ExecuteUriPart(string pUriPart);

	}

}