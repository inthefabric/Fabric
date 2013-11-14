using System;
using Fabric.New.Api.Objects;
using Fabric.New.Domain.Enums;
using Fabric.New.Domain.Names;

namespace Fabric.New.Operations.Traversal.Steps {

	/*================================================================================================*/
	public class TravStepTo<TFrom, TTo> : TravStep<TFrom, TTo>
														where TFrom : FabVertex where TTo : FabVertex {

		private readonly VertexDomainType.Id vType;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TravStepTo(string pCmd, VertexDomainType.Id pType) : base(pCmd) {
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