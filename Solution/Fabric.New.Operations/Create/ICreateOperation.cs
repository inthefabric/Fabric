﻿using Fabric.New.Api.Objects;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public interface ICreateOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Create(IOperationContext pOpCtx, string pJson);

		/*--------------------------------------------------------------------------------------------*/
		FabObject GetResult();

	}

}