using System;
using System.Collections.Generic;
using Fabric.Domain;
using Weaver;
using Weaver.Interfaces;

namespace Fabric.Infrastructure.Weaver {

	/*================================================================================================*/
	public class TxBuilder { //TEST: TxBuilder

		public IWeaverTransaction Transaction { get; private set; }

		private readonly HashSet<IWeaverVarAlias> vVarHash;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TxBuilder() {
			Transaction = Weave.Inst.NewTx();
			vVarHash = new HashSet<IWeaverVarAlias>();
		}

		/*--------------------------------------------------------------------------------------------*/
		public IWeaverTransaction Finish() {
			Transaction.Finish();
			return Transaction;
		}

		/*--------------------------------------------------------------------------------------------*/
		public IWeaverTransaction Finish(IWeaverVarAlias pFinalOutput) {
			VerifyVar(pFinalOutput);
			Transaction.Finish(pFinalOutput);
			return Transaction;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void RegisterVarWithTxBuilder(IWeaverVarAlias pVar) {
			vVarHash.Add(pVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void VerifyVar(IWeaverVarAlias pVar) {
			if ( pVar == null || !vVarHash.Contains(pVar) ) {
				throw new Exception("No matching IWeaverVarAlias found with name '"+
					(pVar == null ? "<NULL>" : pVar.Name)+"'.");
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void GetNode<T>(T pNodeWithId, out IWeaverVarAlias<T> pNodeVar)
																		where T : class, INode, new() {
			IWeaverQuery q = Weave.Inst.BeginPath(
				pNodeWithId.GetTypeIdProp<T>(), pNodeWithId.GetTypeId()).BaseVertex.Next().End();
			q = Weave.Inst.StoreQueryResultAsVar(Transaction, q, out pNodeVar);
			Transaction.AddQuery(q);
			vVarHash.Add(pNodeVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void GetNodeByNodeId<T>(T pNodeWithNodeId, out IWeaverVarAlias<T> pNodeVar)
																		where T : class, INode, new() {
			IWeaverQuery q = Weave.Inst.BeginPath<T>(pNodeWithNodeId.Id).BaseVertex.End();
			q = Weave.Inst.StoreQueryResultAsVar(Transaction, q, out pNodeVar);
			Transaction.AddQuery(q);
			vVarHash.Add(pNodeVar);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddNode<T>(T pNode, bool pIncludeNulls, out IWeaverVarAlias<T> pNewNodeVar)
																					where T : INode {
			IWeaverQuery q = Weave.Inst.AddNode(pNode, pIncludeNulls);
			q = Weave.Inst.StoreQueryResultAsVar(Transaction, q, out pNewNodeVar);
			Transaction.AddQuery(q);
			vVarHash.Add(pNewNodeVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddRel<TRel>(IWeaverVarAlias pFromVar, IWeaverVarAlias pToVar)
																		where TRel : IWeaverEdge, new() {
			VerifyVar(pFromVar);
			VerifyVar(pToVar);

			Transaction.AddQuery(
				Weave.Inst.AddRel(pFromVar, new TRel(), pToVar)
			);
		}

	}

}