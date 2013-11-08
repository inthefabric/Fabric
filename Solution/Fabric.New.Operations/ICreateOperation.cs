﻿using Fabric.New.Api.Objects;

namespace Fabric.New.Operations {

	/*================================================================================================*/
	public interface ICreateOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Create(object pApiCtx, string pJson);

		/*--------------------------------------------------------------------------------------------*/
		FabObject GetResult();

	}

}