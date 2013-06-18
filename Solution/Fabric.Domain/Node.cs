using System;
using System.Linq.Expressions;
using Weaver.Core.Elements;

namespace Fabric.Domain {

	/*================================================================================================*/
	public abstract partial class Node : WeaverVertex, INode, INodeWithId {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected Node(NodeFabType pFabType) {
			FabType = (byte)pFabType;
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public abstract long GetTypeId();
		public abstract void SetTypeId(long pTypeId);
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual Expression<Func<T, object>> GetTypeIdProp<T>() where T : INode {
			return (x => x.Id);
		}

	}

}