using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Weaver;

namespace Fabric.Test.Integration.Common {

	/*================================================================================================*/
	public class VertexConnectionRel {

		public IDbDto Rel { get; private set; }
		public bool IsOutgoing { get; private set; }
		public IDbDto TargetVertex { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VertexConnectionRel(IDbDto pRel, bool pIsOutgoing, IDbDto pTargetVertex) {
			Rel = pRel;
			IsOutgoing = pIsOutgoing;
			TargetVertex = pTargetVertex;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string ToString() {
			return (IsOutgoing ? "--> " : "<-- ")+
				TargetVertex.Class+"["+TargetVertex.Id+", "+
				TargetVertex.Data[PropDbName.StrTypeIdMap[TargetVertex.Class]]+"] / "+
				Rel.Class+"["+Rel.Id+"]";
		}

	}

}