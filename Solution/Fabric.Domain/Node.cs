using System;
using System.Linq.Expressions;
using Weaver.Core.Elements;

namespace Fabric.Domain {

	/*================================================================================================*/
	public abstract partial class Node<T> : WeaverVertex<T>, INode<T>, INodeWithId 
																		where T : class, IWeaverVertex{


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
		public virtual Expression<Func<T, object>> GetTypeIdProp() {
			return (x => x.Id);
		}

	}

}