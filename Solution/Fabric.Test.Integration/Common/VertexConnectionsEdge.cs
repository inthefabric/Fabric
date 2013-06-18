using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Weaver;

namespace Fabric.Test.Integration.Common {

	/*================================================================================================*/
	public class VertexConnectionEdge {

		public IDbDto Edge { get; private set; }
		public bool IsOutgoing { get; private set; }
		public IDbDto TargetVertex { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VertexConnectionEdge(IDbDto pEdge, bool pIsOutgoing, IDbDto pTargetVertex) {
			Edge = pEdge;
			IsOutgoing = pIsOutgoing;
			TargetVertex = pTargetVertex;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string ToString() {
			return (IsOutgoing ? "--> " : "<-- ")+
				TargetVertex.Class+"["+TargetVertex.Id+", "+
				TargetVertex.Data[PropDbName.StrTypeIdMap[TargetVertex.Class]]+"] / "+
				Edge.Class+"["+Edge.Id+"]";
		}

	}

}