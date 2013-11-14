﻿using System;
using Fabric.New.Api.Objects;
using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Domain.Names;
using Fabric.New.Infrastructure.Faults;
using Fabric.New.Operations.Traversal.Routing;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepActiveMember : TravStep<FabTravMemberRoot, FabMember> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepActiveMember() : base("Active") {}

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