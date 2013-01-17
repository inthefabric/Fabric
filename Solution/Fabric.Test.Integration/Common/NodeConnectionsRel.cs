﻿using Fabric.Infrastructure.Db;

namespace Fabric.Test.Integration.Common {

	/*================================================================================================*/
	public class NodeConnectionRel {

		public IDbDto Rel { get; private set; }
		public bool IsOutgoing { get; private set; }
		public IDbDto TargetNode { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public NodeConnectionRel(IDbDto pRel, bool pIsOutgoing, IDbDto pTargetNode) {
			Rel = pRel;
			IsOutgoing = pIsOutgoing;
			TargetNode = pTargetNode;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override string ToString() {
			return (IsOutgoing ? "--> " : "<-- ")+TargetNode.Class+"["+TargetNode.Id+", "+
				TargetNode.Data[TargetNode.Class+"Id"]+"] / "+Rel.Class+"["+Rel.Id+"]";
		}

	}

}