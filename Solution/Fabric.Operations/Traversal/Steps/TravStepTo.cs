using System;
using Fabric.Api.Objects;
using Fabric.Domain.Enums;
using Fabric.Domain.Names;
using Fabric.Infrastructure.Spec;
using Fabric.Operations.Traversal.Routing;
using Fabric.Operations.Traversal.Util;

namespace Fabric.Operations.Traversal.Steps {

	/*================================================================================================*/
	[SpecStep("To")]
	public class TravStepTo<TFrom, TTo> : TravStep<TFrom, TTo>
														where TFrom : FabVertex where TTo : FabVertex {

		private readonly VertexType.Id vType;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepTo(string pCmd, VertexType.Id pType) : base(pCmd) {
			vType = pType;
			FromExactType = true;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void ConsumePath(ITravPath pPath, Type pToType) {
			ConsumeFirstPathItem(pPath, pToType);

			pPath.AddScript(
				".has("+
					pPath.AddParam(DbName.Vert.Vertex.VertexType)+", "+
					GremlinUtil.GetStandardCompareOperation(GremlinUtil.Equal)+", "+
					pPath.AddParam(vType)+
				")"
			);
		}

	}

}