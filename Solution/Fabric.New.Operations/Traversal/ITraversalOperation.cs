using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public interface ITraversalOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void Perform(IOperationContext pOpCtx, string pPath);

		/*--------------------------------------------------------------------------------------------*/
		IList<FabElement> GetResult();

		/*--------------------------------------------------------------------------------------------*/
		IList<FabTravStep> GetResultSteps();

	}

}