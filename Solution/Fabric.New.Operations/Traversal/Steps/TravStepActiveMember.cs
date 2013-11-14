using System;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Domain.Names;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepActiveMember : TravStep<FabTravMemberRoot, FabMember> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepActiveMember() : base("Active") {}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath, Type pToType) {
			ConsumeFirstPathItem(pPath, pToType);

			pPath.AddScript(
				".has("+
					pPath.AddParam(DbName.Vert.Vertex.VertexId)+", "+
					pPath.AddParam(pPath.MemberId)+
				")"
			);
		}

	}

}