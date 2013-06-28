using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Weaver;

namespace Fabric.Test.Integration.Common {

	/*================================================================================================*/
	public class VertexConnectionEdge {

		public IDataDto Edge { get; private set; }
		public bool IsOutgoing { get; private set; }
		public IDataDto TargetVertex { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VertexConnectionEdge(IDataDto pEdge, bool pIsOutgoing, IDataDto pTargetVertex) {
			Edge = pEdge;
			IsOutgoing = pIsOutgoing;
			TargetVertex = pTargetVertex;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string ToString() {
			return (IsOutgoing ? "--> " : "<-- ")+
				TargetVertex.Class+"["+TargetVertex.Id+", "+
				TargetVertex.Properties[PropDbName.StrTypeIdMap[TargetVertex.Class]]+"] / "+
				Edge.Class+"["+Edge.Id+"]";
		}

	}

}