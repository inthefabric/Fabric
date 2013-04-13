using System;
using System.Linq.Expressions;
using Weaver.Items;

namespace Fabric.Domain {

	/*================================================================================================*/
	public abstract class Node : WeaverNode, INode, INodeWithId {

		[WeaverItemProperty]
		public int FabType { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected Node(NodeFabType pFabType) {
			FabType = (int)pFabType;
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