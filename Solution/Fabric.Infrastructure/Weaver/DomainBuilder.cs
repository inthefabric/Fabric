using Fabric.Domain;
using Weaver.Interfaces;
using Weaver.Items;

namespace Fabric.Infrastructure.Weaver {
	
	/*================================================================================================*/
	public class DomainBuilder<T, TRootRel> where T : INode, new()
							where TRootRel : WeaverRel<Root, Contains, T>, new() { //TEST: DomainBuilder

		public TxBuilder TxBuild { get; private set; }
		public T Node { get; private set; }

		public IWeaverVarAlias<T> NodeVar { get; private set; }
		public IWeaverVarAlias<Root> InRootContains { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DomainBuilder(TxBuilder pTx, T pNode) {
			TxBuild = pTx;
			Node = pNode;
			
			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<T> nodeVar;
			TxBuild.AddNode<T, TRootRel>(Node, out rootVar, out nodeVar);
			InRootContains = rootVar;
			NodeVar = nodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public DomainBuilder(TxBuilder pTx) : this(pTx, new T()) {}
		
	}

}