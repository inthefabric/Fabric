﻿namespace Fabric.Domain {

	/*================================================================================================*/
	public interface INodeWithId {

		long Id { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		long GetTypeId();

	}

}