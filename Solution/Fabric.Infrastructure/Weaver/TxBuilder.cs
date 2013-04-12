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
			Transaction = new WeaverTransaction();
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
			IWeaverQuery q = WeaverTasks.BeginPath(
				pNodeWithId.GetTypeIdProp<T>(), pNodeWithId.GetTypeId()).BaseNode.Next().End();
			q = WeaverTasks.StoreQueryResultAsVar(Transaction, q, out pNodeVar);
			Transaction.AddQuery(q);
			vVarHash.Add(pNodeVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void GetNodeByNodeId<T>(T pNodeWithNodeId, out IWeaverVarAlias<T> pNodeVar)
																		where T : class, INode, new() {
			IWeaverQuery q = WeaverTasks.BeginPath<T>(pNodeWithNodeId.Id).BaseNode.End();
			q = WeaverTasks.StoreQueryResultAsVar(Transaction, q, out pNodeVar);
			Transaction.AddQuery(q);
			vVarHash.Add(pNodeVar);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AddNode<T>(T pNode, bool pIncludeNulls, out IWeaverVarAlias<T> pNewNodeVar)
																					where T : INode {
			IWeaverQuery q = WeaverTasks.AddNode(pNode, pIncludeNulls);
			q = WeaverTasks.StoreQueryResultAsVar(Transaction, q, out pNewNodeVar);
			Transaction.AddQuery(q);
			vVarHash.Add(pNewNodeVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AddRel<TRel>(IWeaverVarAlias pFromVar, IWeaverVarAlias pToVar)
																		where TRel : IWeaverRel, new() {
			VerifyVar(pFromVar);
			VerifyVar(pToVar);

			Transaction.AddQuery(
				WeaverTasks.AddRel(pFromVar, new TRel(), pToVar)
			);
		}

	}

}