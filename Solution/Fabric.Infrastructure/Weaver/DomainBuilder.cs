using System;
using Fabric.Domain;
using Weaver.Interfaces;

namespace Fabric.Infrastructure.Weaver {
	
	/*================================================================================================*/
	public class DomainBuilder<T> where T : INode, new() { //TEST: DomainBuilder

		public TxBuilder TxBuild { get; private set; }
		public T Node { get; private set; }

		public IWeaverVarAlias<T> NodeVar { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DomainBuilder(TxBuilder pTx, T pNode) {
			TxBuild = pTx;
			Node = pNode;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public DomainBuilder(TxBuilder pTx) : this(pTx, new T()) {}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddNode(bool pIncludeNulls=false) {
			IWeaverVarAlias<T> nodeVar;
			TxBuild.AddNode(Node, pIncludeNulls, out nodeVar);
			NodeVar = nodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void SetNodeVar(IWeaverVarAlias<T> pNodeVar) {
			if ( NodeVar != null ) {
				throw new Exception("NodeVar is already set.");
			}

			NodeVar = pNodeVar;
			TxBuild.RegisterVarWithTxBuilder(NodeVar);
		}
		
	}

}