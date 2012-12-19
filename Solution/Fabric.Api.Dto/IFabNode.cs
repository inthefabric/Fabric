using System.Collections.Generic;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public interface IFabNode : IFabDto {

		long NodeId { get; set; }
		string NodeUri { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		bool HasProperty(string pPropName);

	}

}