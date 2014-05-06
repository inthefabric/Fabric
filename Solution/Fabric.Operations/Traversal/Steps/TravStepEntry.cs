using System;
using Fabric.Api.Objects;
using Fabric.Api.Objects.Conversions;
using Fabric.Domain.Names;
using Fabric.Operations.Traversal.Routing;
using Fabric.Operations.Traversal.Util;

namespace Fabric.Operations.Traversal.Steps {

	/*================================================================================================*/
	public static class TravStepEntry {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void AddTypeFilterIfNecessary(ITravPath pPath, Type pStepType, Type pPathType) {
			if ( pStepType != typeof(FabVertex) || pPathType == typeof(FabVertex) ) {
				return;
			}
			
			pPath.AddScript(
				".has("+
					pPath.AddParam(DbName.Vert.Vertex.VertexType)+", "+
					GremlinUtil.GetStandardCompareOperation(GremlinUtil.Equal)+", "+
					pPath.AddParam((byte)ApiToDomain.GetVertexTypeId(pPathType))+
				")"
			);
		}

	}

}