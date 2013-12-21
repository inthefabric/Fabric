using System.Collections.Generic;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;

namespace Fabric.New.Operations.Traversal {

	/*================================================================================================*/
	public interface ITraversalOperation {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		IList<FabElement> Execute(IOperationContext pOpCtx, string pPathText);

		/*--------------------------------------------------------------------------------------------*/
		IList<FabTravStep> GetResultSteps();

	}

}