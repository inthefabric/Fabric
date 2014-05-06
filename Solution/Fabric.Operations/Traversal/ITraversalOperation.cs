using System.Collections.Generic;
using Fabric.Api.Objects;
using Fabric.Api.Objects.Traversal;

namespace Fabric.Operations.Traversal {

	/*================================================================================================*/
	public interface ITraversalOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IList<FabElement> Execute(IOperationContext pOpCtx, string pPathText);

		/*--------------------------------------------------------------------------------------------*/
		IList<FabTravStep> GetResultSteps();

	}

}