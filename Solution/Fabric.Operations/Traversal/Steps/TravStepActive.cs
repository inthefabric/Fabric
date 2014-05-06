using System;
using Fabric.Api.Objects;
using Fabric.Api.Objects.Traversal;
using Fabric.Domain.Names;
using Fabric.Infrastructure.Faults;
using Fabric.Infrastructure.Spec;
using Fabric.Operations.Traversal.Routing;

namespace Fabric.Operations.Traversal.Steps {

	/*================================================================================================*/
	[SpecStep("Active")]
	public class TravStepActive : TravStep<FabTravMemberRoot, FabMember> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepActive() : base("Active") {}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath, Type pToType) {
			ITravPathItem item = ConsumeFirstPathItem(pPath, pToType);

			if ( pPath.MemberId == null ) {
				throw item.NewStepFault(FabFault.Code.InvalidStep, "There is no active Member.");
			}

			pPath.AddScript(
				".has("+
					pPath.AddParam(DbName.Vert.Vertex.VertexId)+", "+
					pPath.AddParam(pPath.MemberId)+
				")"
			);
		}

	}

}