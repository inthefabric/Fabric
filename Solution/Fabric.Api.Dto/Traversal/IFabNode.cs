﻿namespace Fabric.Api.Dto.Traversal {

	/*================================================================================================*/
	public interface IFabNode : IFabObject {

		string Uri { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		bool HasProperty(string pPropName);

	}

}