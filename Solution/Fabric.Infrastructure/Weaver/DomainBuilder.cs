using Fabric.Domain;
using Weaver.Interfaces;

namespace Fabric.Infrastructure.Weaver {
	
	/*================================================================================================*/
	public class DomainBuilder<T> where T : INode, new() { //TEST: DomainBuilder

		public IWeaverTransaction Transaction { get; private set; }
		public T Node { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DomainBuilder(IWeaverTransaction pTx, T pNode) {
			Transaction = pTx;
			Node = pNode;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public DomainBuilder(IWeaverTransaction pTx) : this(pTx, new T()) {}
		
	}

}